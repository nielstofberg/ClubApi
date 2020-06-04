using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubApi.Models
{
    /// <summary>
    /// Firearms Certificate information
    /// </summary>
    public class Fac
    {
        [Key]
        public long FacId { get; set; }
        [Required]
        public string Type { get; set; } = "FAC";
        [Required]
        public string Number { get; set; }
        public string Authority { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Notes { get; set; }
        [Required]
        public long MemberId { get; set; }
        public virtual Member Member { get; set; }

        public Fac(long memberId, string type, string number)
        {
            MemberId = memberId;
            Type = type;
            Number = number;
        }
    }
}
