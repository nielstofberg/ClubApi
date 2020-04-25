using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClubApi.Models
{
    public class Member
    {
        [Key]
        public long MemberId { get; set; }

        [Required]
        public int MemberNo { get; set; }
        public string Pin { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string Middlename { get; set; }

        [Required]
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Picture { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool KeyHolder { get; set; } = false;
        public string FacNumber { get; set; }
        public string Notes { get; set; }
        [Required]
        public int MemberTypeId { get; set; }
        public virtual MemberType MemberType { get; set; }
        public virtual ICollection<Locker> Lockers { get; set; }
        public virtual ICollection<Rifle> Rifles { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }

        public Member(int memberNo, string firstName, string surname)
        {
            MemberNo = memberNo;
            FirstName = firstName;
            Surname = surname;
        }
    }
}
