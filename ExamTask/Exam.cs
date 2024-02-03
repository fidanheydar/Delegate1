using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTask
{
    public class Exam
    {
        public string Subject;
        public DateTime Date;
        public Exam(string subject, DateTime date)
        {
            Subject = subject;
            Date = date;
        }
        public override string ToString()
        {
            return $"{Subject}--{Date}";
        }
    }
}
