using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ADB2020MidTerm
{
   public class Database
    {
        public static string DbFileName { get; set; }
        public static IObjectContainer DB = null;
        public static void Open()
        {
            DB = Db4oEmbedded.OpenFile(DbFileName);
        }

        public static void Close()
        {
            DB.Close();
        }

        public static void Store<T>(T obj)
        {
            DB.Store(obj);
        }

        public static void Delete<T>(T obj)
        {
            DB.Delete(obj);
        }

        public static void CreateEmployees(IObjectContainer DB, string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader fin = new StreamReader(fs);
                int nEmps = int.Parse(fin.ReadLine());
                for (int i = 0; i < nEmps; i++)
                {
                    string line = fin.ReadLine();
                    if (line != null)
                    {
                        string[] fields = line.Split(':');
                        string fname = fields[0];
                        char minit = fields[1][0];
                        string lname = fields[2];
                        int ssn = int.Parse(fields[3]);
                        string bdate = fields[4];
                        string address = fields[5];
                        char sex = fields[6][0];
                        float salary = float.Parse(fields[7]);
                        Employee e = new Employee
                        {
                            Ssn = ssn,
                            FName = fname,
                            MInit = minit,
                            LName = lname,
                            Address = address,
                            BirthDate = bdate,
                            Salary = salary,
                            Sex = sex
                        };
                        DB.Store(e);
                    }
                }
                fin.Close();
                fs.Close();
            }
        }

        public static void CreateDependent(IObjectContainer DB, string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader fin = new StreamReader(fs);
                int nEmps = int.Parse(fin.ReadLine());
                for (int i = 0; i < nEmps; i++)
                {
                    string line = fin.ReadLine();
                    if (line != null)
                    {
                        string[] fields = line.Split(',');
                        string name = fields[0];
                        char sex = fields[1][0];
                        string bdate = fields[2];
                        string rela = fields[3];
                        
                        Dependent d = new Dependent
                        {
                            Name = name,
                            Sex = sex,
                            BirthDate = bdate,
                            Relationship = rela                           
                        };
                        DB.Store(d);
                    }
                }
                fin.Close();
                fs.Close();
            }
        }

        public static void CreateDepartment(IObjectContainer DB, string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader fin = new StreamReader(fs);
                int nEmps = int.Parse(fin.ReadLine());
                for (int i = 0; i < nEmps; i++)
                {
                    string line = fin.ReadLine();
                    if (line != null)
                    {
                        string[] fields = line.Split(':');
                        int dnumber = int.Parse(fields[0]);
                        string dname = fields[1];
                                                
                       
                        Department d = new Department
                        {
                            DNumber = dnumber,
                            DName = dname,

                        };
                        DB.Store(d);
                    }
                }
                fin.Close();
                fs.Close();
            }
        }

        public static void CreateProject(IObjectContainer DB, string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader fin = new StreamReader(fs);
                int nEmps = int.Parse(fin.ReadLine());
                for (int i = 0; i < nEmps; i++)
                {
                    string line = fin.ReadLine();
                    if (line != null)
                    {
                        string[] fields = line.Split(',');
                        int pnumber = int.Parse(fields[0]);
                        string pname = fields[1];
                        string location = fields[2];
                       Project p = new Project
                        {
                           PNumber = pnumber,
                           PName = pname,
                           Location = location
                        };
                        DB.Store(p);
                    }
                }
                fin.Close();
                fs.Close();
            }
        }

        public static void CreateWorksOn(IObjectContainer DB, string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader fin = new StreamReader(fs);
                int nEmps = int.Parse(fin.ReadLine());
                for (int i = 0; i < nEmps; i++)
                {
                    string line = fin.ReadLine();
                    if (line != null)
                    {
                        string[] fields = line.Split(',');
                        float hour = float.Parse(fields[2]);

                        WorksOn w = new WorksOn
                        {
                            Hours = hour
                        };
                        DB.Store(w);
                    }
                }
                fin.Close();
                fs.Close();
            }
        }
    }
}



