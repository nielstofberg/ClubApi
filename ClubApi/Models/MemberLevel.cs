using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubApi.Models
{
    public class MemberLevel
    {
        [Key]
        public int MemberLevelId {get;set;}
        public string Title { get; set; }
        public string Description { get; set; }

        public MemberLevel(string title)
        {
            Title = title;
        }
    }
}
