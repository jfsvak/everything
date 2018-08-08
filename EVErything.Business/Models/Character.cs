using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVErything.Business.Models
{
    public class Character
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public String Name { get; set; }
        public Guid CharacterSetID { get; set; }
        [ForeignKey("CharacterSetID")]
        public CharacterSet CharacterSet { get; set; }
        public Token Token { get; set; }
        public Guid AccountID { get; set; }
        [ForeignKey("AccountID")]
        public Account Account { get; set; }
    }
}
