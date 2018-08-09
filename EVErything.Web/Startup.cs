using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebApplication2
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
        //private readonly IHttpClientFactory _clientFactory;

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory) //, IHttpClientFactory clientFactory)
        {
            //_clientFactory = clientFactory;
            Configuration = configuration;
            this.logger = loggerFactory.CreateLogger<Startup>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

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


            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/Account/Login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            //services.AddOidcStateDataFormatterCache("esi");

            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});


            //services.AddAuthentication(options => {
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //})
            services.AddAuthentication();
            //.AddCookie()
            //.AddOpenIdConnect("esi", options =>
            //    {
            //        //options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

            //        options.Authority = "https://sisilogin.testeveonline.com/";
            //        options.CallbackPath = new PathString("/esicallback");
            //        options.ResponseType = OpenIdConnectResponseType.Code;// "code";
                    
            //        options.SaveTokens = true;
            //        //options.GetClaimsFromUserInfoEndpoint = true;
            //        options.ClientId = "de2dbc0324ec4fc583a1aa0b18cfb08b";
            //        options.ClientSecret = "4NLiCtkhHBeo8bmXYICVBfur9Oq5yAuNcDbTJYCn";
            //        //options.ProtocolValidator = null;
            //        //SecurityTokenValidators.Add(new CustomJwtSecurityTokenHandler());
            //        //options.ClaimsIssuer = "esi";
            //        //options.TokenValidationParameters = new TokenValidationParameters
            //        //{
            //        //    ValidateIssuer = false,
            //        //    ValidateActor = false,
            //        //    ValidateIssuerSigningKey = false,
            //        //    ValidateAudience = false,
            //        //    ValidateLifetime = false,
            //        //    ValidateTokenReplay = false,

            //        //    //RoleClaimType = ClaimTypes.Role
            //        //};

            //        options.Scope.Clear();
            //        options.Scope.Add("characterAccountRead");

            //        options.Events = new OpenIdConnectEvents
            //        {
            //            //OnAuthorizationCodeReceived = this.OnAuthorizationCodeReceived2,
            //            OnTokenResponseReceived = this.OnTokenResponseReceived
            //            //,
            //            //OnRedirectToIdentityProvider = context =>
            //            //{
            //            //    context.ProtocolMessage.SetParameter("audience", "characterAccountRead");

            //            //    return Task.FromResult(0);
            //            //}

            //        };
            //    });
                //.AddJwtBearer(options =>
                //{
                //    options.SecurityTokenValidators.Add(new CustomJwtSecurityTokenHandler());
                //    options.TokenValidationParameters = new TokenValidationParameters
                //    {
                //        ValidateIssuer = false,
                //        ValidateActor = false,
                //        ValidateIssuerSigningKey = false,
                //        ValidateAudience = false,
                //        ValidateLifetime = false,
                //        ValidateTokenReplay = false,

                //        //RoleClaimType = ClaimTypes.Role
                //    };
                //});

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private async Task OnAuthorizationCodeReceived2(AuthorizationCodeReceivedContext context)
        {
            //var configuration = new ConfigurationOptions();
            //this.Configuration.Bind(configuration);

            var request = context.HttpContext.Request;
            var currentUri = UriHelper.BuildAbsolute(request.Scheme, request.Host, request.PathBase, request.Path);

            var clientCredential = new ClientCredential("de2dbc0324ec4fc583a1aa0b18cfb08b", "4NLiCtkhHBeo8bmXYICVBfur9Oq5yAuNcDbTJYCn");
            var authContext = new AuthenticationContext(
                "https://sisilogin.testeveonline.com/oauth", 
                false);

            var result = await authContext.AcquireTokenByAuthorizationCodeAsync(
                context.ProtocolMessage.Code, 
                new Uri(currentUri), 
                clientCredential,
                "/token");
            //this.logger.LogInformation(configuration.MicrosoftGraphApi.ResourceUri);

            // passed the access/id tokens into HandleCodeRedemption
            context.HandleCodeRedemption(result.AccessToken, result.IdToken);
        }

        private async Task OnAuthorizationCodeReceived(AuthorizationCodeReceivedContext context)
        {
            Console.WriteLine("Authorization code received:" + context.ProtocolMessage.Code);
            var client = new HttpClient(); // _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", context.TokenEndpointRequest.ClientId, context.TokenEndpointRequest.ClientSecret)))
            );
            //var request = context.HttpContext.Request;
            //var currentUri = UriHelper.BuildAbsolute(request.Scheme, request.Host, request.PathBase, request.Path);
            HttpResponseMessage response = await client.PostAsync(
                new Uri("https://sisilogin.testeveonline.com/oauth/token"), 
                new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("code", context.ProtocolMessage.Code)
                })).ConfigureAwait(false);
            //var response = await client.PostAsync("oauth/token", content);

            string contentResponse = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<AccessToken>(contentResponse);
            Console.WriteLine("Content: " + contentResponse);
            Console.WriteLine("Access_token: " + token.access_token);

            //var configuration = new ConfigurationOptions();
            //this.Configuration.Bind(configuration);

            //var request = context.HttpContext.Request;
            //var currentUri = UriHelper.BuildAbsolute(request.Scheme, request.Host, request.PathBase, request.Path);
            //var clientCredential = new ClientCredential(configuration.AzureActiveDirectory.ClientID, configuration.AzureActiveDirectory.ClientSecret);
            //var authContext = new AuthenticationContext(configuration.AzureActiveDirectory.Authority, AuthPropertiesTokenCache.ForCodeRedemption(context.Properties));

            //var result = await authContext.AcquireTokenByAuthorizationCodeAsync(context.ProtocolMessage.Code, new Uri(currentUri), clientCredential, configuration.MicrosoftGraphApi.ResourceUri);
            //this.logger.LogInformation(configuration.MicrosoftGraphApi.ResourceUri);

            //// passed the access/id tokens into HandleCodeRedemption
            //context.HandleCodeRedemption(result.AccessToken, result.IdToken);

            context.HandleCodeRedemption();
            context.HandleResponse();
        }

        private async Task OnTokenResponseReceived(TokenResponseReceivedContext context)
        {
            Console.WriteLine("Token response received");
            var tokenEndpointResponse = context.TokenEndpointResponse;
            Console.WriteLine("id_token", tokenEndpointResponse.IdToken);
        }
    }
}
