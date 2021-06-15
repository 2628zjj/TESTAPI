using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student
    {
        [Key]
        public int id { set; get; }

        public string name { set; get; }

        public string sex { set; get; }

        public string grade { set; get; }

        public string address { set; get; }
    }
}
