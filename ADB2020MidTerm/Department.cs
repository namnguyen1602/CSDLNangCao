using System;
using System.Collections.Generic;
using System.Text;

namespace ADB2020MidTerm
{
    public class Department
    {
        // attributes
        public int DNumber { get; set; }
        public string DName { get; set; }
        public List<string> Locations { get; set; }
        // relationships
        public List<Employee> Employees { get; set; }
        public Employee Manager { get; set; }
        public List<Project> Projects { get; set; }
        // one-to-many relationship (manager) attribute
        public string MgrStartDate { get; set; }

        public static implicit operator Department(Department v)
        {
            throw new NotImplementedException();
        }
    }
}
