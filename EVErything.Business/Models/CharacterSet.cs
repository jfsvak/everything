using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EVErything.Business.Models
{
    public class CharacterSet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string MainCharacterID { get; set; }
        [ForeignKey("MainCharacterID")]
        public Character MainCharacter { get; set; }
    }
}
