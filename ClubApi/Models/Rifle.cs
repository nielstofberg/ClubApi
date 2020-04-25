using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClubApi.Models
{
    public class Rifle
    {
        [Key]
        public long RifleId { get; set; }
        [Required]
        public string SerialNo { get; set; }
        [Required]
        public string Make { get; set; }
        public string Model { get; set; }
        [Required]
        public string Calibre { get; set; }
        public string Notes { get; set; }
        public long OwnerMemberId { get; set; }
        public virtual Member Owner { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool ClubRifle { get; set; } = false;

        public Rifle(string serialNo, string make, string calibre)
        {
            SerialNo = serialNo;
            Make = make;
            Calibre = calibre;
        }
    }
}
