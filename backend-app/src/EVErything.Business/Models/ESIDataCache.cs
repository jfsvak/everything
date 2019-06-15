using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVErything.Business.Models
{
    public class ESIDataCache
    {
        /// <summary>
        /// Auto-generated primary key
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// ID of character
        /// </summary>
        [Required]
        public string CharacterID { get; set; }

        [ForeignKey("CharacterID")]
        public Character Character { get; set; }

        /// <summary>
        /// Specifies whether the data is from:
        /// * tranquility 
        /// * singularity
        /// </summary>
        [Required]
        public string ESISource { get; set; }

        /// <summary>
        /// The esi route for the ESI request used to get this piece of data.
        /// Examples:
        /// "/characters/{character_id}/"
        /// "/characters/{character_id}/fatigue/"
        /// "/corporations/{corporation_id}/assets/locations/"
        /// "/alliances/{alliance_id}/icons/"
        /// </summary>
        [Required]
        public string ESIRoute { get; set; }

        /// <summary>
        /// Timestamp for when this piece of data was last updated from the ESI source.
        /// </summary>
        [Required]
        public DateTime LastUpdateTimestamp { get; set; }

        /// <summary>
        /// The actual data stored in the cache
        /// </summary>
        public string Data { get; set; }
    }
}
