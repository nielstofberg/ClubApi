using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClubApi.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "bit")]
        public bool Fee { get; set; }

        public Activity(string title)
        {
            Title = title;
        }
    }
}
