using System;
using System.Collections.Generic;
using System.Text;

namespace ADB2020MidTerm
{
   public class Project
    {
        // attributes
        public int PNumber { get; set; }
        public string PName { get; set; }
        public string Location { get; set; }
        // relationships
        public Department ControlledBy { get; set; }
        public List<WorksOn> WorksOn { get; set; }
    }
}
