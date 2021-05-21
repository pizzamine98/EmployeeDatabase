
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EmployeeDatabase
{
    class EmpFileManager
    {
        public string filepath;
        public void LoadJson()
        {

        }
        public void CreateJson()
        {
            emps = new List<Employee>();
            emps.Add(new Employee());
            emps[0].Name = "Joshua Smith";
            emps[0].JobTitle = "Intern";
            emps[0].Id = 1;
            string json = JsonConvert.SerializeObject(emps);
            System.IO.File.WriteAllText(filepath, json);
        }
        public void WriteJson()
        {
            string json = JsonConvert.SerializeObject(emps);
            System.IO.File.WriteAllText(filepath, json);
        }
        public List<Employee> emps;
        public int nemps;
        public void ReadJson()
        {
            string json = System.IO.File.ReadAllText(filepath);
            emps = JsonConvert.DeserializeObject<List<Employee>>(json);
            nemps = emps.Count;
        }
    }
}
