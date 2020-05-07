using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClubApi.Models
{
    public class Attendance
    {
        [Key]
        public long AttendanceId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool SeasonTicket { get; set; }
        [Required]
        public float Payment { get; set; }
        [Required]
        public long MemberId { get; set; }
        public virtual Member Member { get; set; }
        public long? RifleId { get; set; }
        public virtual Rifle Rifle { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public Attendance(bool seasonTicket, float payment)
        {
            Date = DateTime.Now;
            SeasonTicket = seasonTicket;
            Payment = payment;
        }
    }
}
