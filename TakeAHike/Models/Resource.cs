using System;
using System.Collections.Generic;


namespace TakeAHike.Models
{
    public class Resource
    {
        private static List<Resource> resources = new List<Resource>();
        public int ResourceID { get; set; }
        public string ResourceName { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

        //not sure about the list!
        public List<Resource> Resources { get { return resources; } }
    }
}
