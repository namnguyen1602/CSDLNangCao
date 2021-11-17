using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ADB2020MidTerm
{
   public class Employee
    {
        // attributes
        public int Ssn { get; set; }
        public string FName { get; set; }
        public char MInit { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string BirthDate { get; set; }
        public float Salary { get; set; }
        public char Sex { get; set; }
        //relationships
        public Department WorksFor { get; set; }
        public Department Manages { get; set; }
        public List<WorksOn> WorksOn { get; set; }
        public List<Dependent> Dependents { get; set; }
        public Employee Supervisor { get; set; }
        public List<Employee> Supervisees { get; set; }

        public static void SetManagers(IObjectContainer db, string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader fin = new StreamReader(fs);
                int nMgrs = int.Parse(fin.ReadLine());
                for (int i = 0; i < nMgrs; i++)
                {
                    string line = fin.ReadLine();
                    string[] fields = line.Split(',');
                    int dno = int.Parse(fields[0]);
                    int essn = int.Parse(fields[1]);
                    string startDate = fields[2];
                    IList<Department> depts = db.Query(delegate (Department dept)
                    {
                        return (dept.DNumber == dno);
                    });
                    Department d = null;
                    if (depts != null)
                        d = depts[0];
                    IList<Employee> emps = db.Query(delegate (Employee emp)
                    {
                        return (emp.Ssn == essn);
                    });
                    Employee e = null;
                    if (emps != null && emps.Count != 0)
                        e = emps[0];
                    if (e != null && d != null)
                    {
                        d.MgrStartDate = startDate;
                        e.Manages = d;
                        d.Manager = e;
                        db.Store(d);
                        db.Store(e);
                    }
                }
            }
        }
    }
}
