using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubApi.Models
{
    public class MemberType
    {
        [Key]
        public int MemberTypeId { get; set; }
        [Required]
        public string Description { get; set; }
        public float Sub { get; set; } = 0f;
        public float RangeFee { get; set; } = 0f;
        public string Notes { get; set; }

        public MemberType(string description)
        {
            Description = description;
        }
    }
}
