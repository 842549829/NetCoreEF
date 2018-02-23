using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DbDomain
{
    /// <summary>
    /// Sessions
    /// </summary>
    public class Sessions
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [Required]
        [MaxLength(900)]
        public string Id { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        [Required]
        [Column(TypeName = "varbinary(MAX)")]
        public string Value { get; set; }

        /// <summary>
        /// ExpiresAtTime
        /// </summary>
        [Required]
        [Column(TypeName = "datetimeoffset(7)")]
        public DateTime ExpiresAtTime { get; set; }

        /// <summary>
        /// SlidingExpirationInSeconds
        /// </summary>
        public long? SlidingExpirationInSeconds { get; set; }

        /// <summary>
        /// AbsoluteExpiration
        /// </summary>
        [Column(TypeName = "datetimeoffset(7)")]
        public DateTime? AbsoluteExpiration { get; set; }
    }
}