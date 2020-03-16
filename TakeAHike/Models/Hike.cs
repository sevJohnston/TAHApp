using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TakeAHike.Models
{
    public class Hike
    {
       //private List<Hike> hikes = new List<Hike>();
        
        public int HikeID { get; set; }     //creates a HikeID and maps it as the primary key

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string TrailName { get; set; }

        [Required(ErrorMessage = "You must select a region.")]
        public string Region { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        //public List<Hike> Hikes { get { return hikes; } }
    }
}
