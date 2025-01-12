using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Doctor : User
    {
        public Doctor(string name, string email, string password, string address, enLevel level,double mark) : base(name, email, password, address)
        {

            Questions = new List<string>();
        }

        public List<string> Questions { get; set; }
        public enLevel Level { get; set; }

        public double Mark {  get; set; }  
        
    }
}
