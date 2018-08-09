using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EVErything.Business.Models
{
    public class Token
    {
        [Key]
        public string CharacterID { get; set; }

        [ForeignKey("CharacterID")]
        public Character Character { get; set; }

        [Required]
        public string RefreshToken { get; set; }

        [Required]
        public string AccessToken { get; set; }

        [Required]
        public string TokenType { get; set; }

        public int? ExpiresIn { get; set; }
    }
}
