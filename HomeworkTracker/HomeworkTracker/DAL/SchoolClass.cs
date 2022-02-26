using System;
using System.Collections.Generic;

namespace HomeworkTracker
{
    public class SchoolClass
    {
        static int nxtSchoolClassId = 1;
        public int Id { get; private set; } = nxtSchoolClassId++;
        public String Name { get; set; }
        public List<Assignment> Assignments { get; set; }



        public static SchoolClass FromFile(String filename)
        {
            var sclass = Newtonsoft.Json.JsonConvert.DeserializeObject<SchoolClass>(System.IO.File.ReadAllText(filename));
            if (nxtSchoolClassId <= sclass.Id)
                nxtSchoolClassId = sclass.Id + 1;
            return sclass;
        }
        public void ToFile(String filename)
        {
            System.IO.File.WriteAllText(filename, Newtonsoft.Json.JsonConvert.SerializeObject(this));
        }
    }
}
