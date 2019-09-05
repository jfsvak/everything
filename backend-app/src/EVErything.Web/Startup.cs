using EVErything.Business.Data;
using EVErything.Business.Services;
using EVErything.Web.Data;
using EVErything.Web.Models;
using EVErything.Web.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EVErything
{
    public class AccessToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
    }

    public class Startup
    {
        private readonly ILogger<Startup> logger;
        private readonly string AllowAnyOrigins = "AllowAnyOrigins";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory) //, IHttpClientFactory clientFactory)
        {
            //_clientFactory = clientFactory;
            Configuration = configuration;
            this.logger = loggerFactory.CreateLogger<Startup>();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy(AllowAnyOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            Console.WriteLine("EVErything_Identity_Connection={0}", Environment.GetEnvironmentVariable("EVErything_Identity_Connection"));
            Console.WriteLine("EVErything_App_Connection={0}", Environment.GetEnvironmentVariable("EVErything_App_Connection"));

            services.AddDbContext<IdentityDbContext>(options => options.UseMySQL(Environment.GetEnvironmentVariable("EVErything_Identity_Connection")));
            services.AddDbContext<AppDbContext>(options => options.UseMySQL(Environment.GetEnvironmentVariable("EVErything_App_Connection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = false;
            });

            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            //    // If the LoginPath isn't set, ASP.NET Core defaults 
            //    // the path to /Account/Login.
            //    options.LoginPath = "/Account/Login";
            //    // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
            //    // the path to /Account/AccessDenied.
            //    options.AccessDeniedPath = "/Account/AccessDenied";
            //    options.SlidingExpiration = true;
            //});
            //services.ConfigureApplicationCookie(options =>
            //    {
            //    })
            //    .ConfigureExternalCookie(options =>
            //    {
            //    });

            services.AddAuthentication(options =>
                {
                    options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
                    //options.DefaultAuthenticateScheme = DefaultAuthenticationTypes.ApplicationCookie;// CookieAuthenticationDefaults.AuthenticationScheme;
                    //options.DefaultSignInScheme = DefaultAuthenticationTypes.ExternalCookie; //"ExternalCookie"; // CookieAuthenticationDefaults.AuthenticationScheme;
                    //options.DefaultChallengeScheme = "EVESSO";
                })
                //.AddCookie(DefaultAuthenticationTypes.ApplicationCookie)
                .AddCookie(DefaultAuthenticationTypes.ExternalCookie)
                //.AddApplicationCookie();
                .AddOAuth("EVESSO", options => 
                {
                    options.SignInScheme = "ExternalCookie";
                    options.ClientId = Environment.GetEnvironmentVariable("EVE_CLIENT_ID");
                    options.ClientSecret = Environment.GetEnvironmentVariable("EVE_SECRET_KEY");
                    options.CallbackPath = new Microsoft.AspNetCore.Http.PathString("/esicallback");

                    options.AuthorizationEndpoint = $"{Configuration["EVE:SSO.Url"]}/oauth/authorize";
                    options.TokenEndpoint = $"{Configuration["EVE:SSO.Url"]}/oauth/token";
                    options.UserInformationEndpoint = $"{Configuration["EVE:ESI.Url"]}/verify?datasource={Configuration["EVE:Cluster"]}";

                    options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "CharacterID");
                    options.ClaimActions.MapJsonKey(ClaimTypes.Name, "CharacterName");
                    options.ClaimActions.MapJsonKey("characterid", "CharacterID");
                    options.ClaimActions.MapJsonKey("charactername", "CharacterName");
                    options.SaveTokens = true;
                    options.Scope.Add("esi-skills.read_skillqueue.v1");
                    options.Scope.Add("esi-skills.read_skills.v1");

                    options.Events = new Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents
                    {
                        OnRedirectToAuthorizationEndpoint = context =>
                        {
                            Console.WriteLine($"OnRedirectToAuthorizationEndpoint triggered! Redirecting to {context.RedirectUri}");
                            context.Response.Redirect(context.RedirectUri);
                            return Task.CompletedTask;
                        },
                        OnCreatingTicket = async context =>
                        {
                            
                            //SignInManager<ApplicationUser>.SignInAsync();
                            Console.WriteLine("Creating ticket");
                            var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

                            var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                            response.EnsureSuccessStatusCode();

                            var json = JObject.Parse(await response.Content.ReadAsStringAsync());
                            Console.WriteLine($"User object: {json}");
                            context.RunClaimActions(json);
                            foreach(var claim in context.Principal.Claims) {
                                Console.WriteLine($"Claim: [{claim}]");
                            }

                            //context.
                            //var user = await Manager<ApplicationUser>.FindByNameAsync(verify.CharacterID);

                            //if (user == null)
                            //{
                            //    // If user not found for that CharacterID, create a new user 
                            //    user = new ApplicationUser
                            //    {
                            //        UserName = verify.CharacterID,
                            //        CharacterId = verify.CharacterID,
                            //        AccessToken = token.access_token,
                            //        RefreshToken = token.refresh_token,
                            //        CharacterName = verify.CharacterName
                            //    };

                            //    var identityResult = await _userManager.CreateAsync(user, verify.CharacterID);
                            //}
                            //await context.HttpContext.SignInAsync("Identity.Application", context.Principal);
                        },
                        OnTicketReceived = context =>
                        {
                            Console.WriteLine($"OnTicketReceived triggered! Principal: {context.Principal}");
                            return Task.CompletedTask;
                        }
                    };
                });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IEVEDataService, EVEDataService>();

            services.AddMvc();
            services.AddHttpClient();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "EVErything API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment() || env.IsEnvironment("DockerLocal"))
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    scope.ServiceProvider.GetService<AppDbContext>().Database.Migrate();
                    scope.ServiceProvider.GetService<IdentityDbContext>().Database.Migrate();
                }
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseCors(AllowAnyOrigins);
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contacts API v1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
