using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVErything.Web.Models.ESIViewModels
{
    public class VerifyViewModel
    {
        public string CharacterID { get; set; }
        public string CharacterName { get; set; }
        public string ExpiresOn { get; set; }
        public string Scopes { get; set; }
        public string TokenType { get; set; }
        public string CharacterOwnerHash { get; set; }
    }
}
