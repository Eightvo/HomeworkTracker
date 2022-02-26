using System;
using System.Collections.Generic;

namespace HomeworkTracker
{
    public class Assignment
    {
        static int _nxtAssignmentId = 1;
        public int Id { get; private set; } = _nxtAssignmentId++;
        public String Description { get; set; }
        public bool Completed { get; set; }
        public DateTime DueDate { get; set; }

        public override string ToString()
        {
            return $"{Description}";
        }
    }
}
