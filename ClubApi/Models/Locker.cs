using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClubApi.Models
{
    public class Locker
    {
        [Key]
        public int LockerId { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int LockerNumber { get; set; }
        public string Description { get; set; }
        public long OwnerMemberId { get; set; }
        public virtual Member Owner { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool Owned { get; set; } = false;
        [Required]
        public float AnnualFee { get; set; } = 0f;
        public string Notes { get; set; }

        public Locker(string location, int lockerNumber)
        {
            Location = location;
            LockerNumber = lockerNumber;
        }
    }
}
