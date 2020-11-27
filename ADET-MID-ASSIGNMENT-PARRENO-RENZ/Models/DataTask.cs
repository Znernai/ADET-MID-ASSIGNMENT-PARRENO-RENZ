using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class DataTask
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime What_Date { get; set; }
        [DataType(DataType.Date)]
        public DateTime Start_Date { get; set; }
        [DataType(DataType.Date)]
        public DateTime Finish_Date { get; set; }
        public float Total_Of_Hours { get; set; }

    }
}
