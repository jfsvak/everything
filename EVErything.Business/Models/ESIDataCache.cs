using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVErything.Business.Models
{
    public class ESIDataCache
    {
        /// <summary>
        /// ID of character
        /// </summary>
        public String CharacterID { get; set; }

        [ForeignKey("CharacterID")]
        public Character Character { get; set; }

        /// <summary>
        /// Key for the data saved in State.
        /// Examples:
        /// "attributes", "skillqueue" etc.
        /// </summary>
        public string Key { get; set; }

        [Column(TypeName = "text")]
        public string? State { get; set; }

        /// <summary>
        /// Timestamp for when this piece of data was last updated from the ESI source.
        /// </summary>
        public DateTime LastUpdateTimestamp { get; set; }

        /// <summary>
        /// Specifies wether the data is from tranquility or singularity
        /// </summary>
        public string ESISource { get; set; }

        /// <summary>
        /// The url for the ESI request used to get the data.
        /// Examples:
        /// "/characters/{character_id}"
        /// "/characters/{character_id}/fatigue"
        /// </summary>
        public string URL { get; set; }
    }
}
