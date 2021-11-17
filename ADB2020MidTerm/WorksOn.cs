using System;
using System.Collections.Generic;
using System.Text;

namespace ADB2020MidTerm
{
    public class WorksOn
    {
        // attribute
        public float Hours { get; set; }
        //owner attributes
        public Employee Employee { get; set; }
        public Project Project { get; set; }
    }
}
