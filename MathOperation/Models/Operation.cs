using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MathOperation.Models
{
    public class Operation //Will be Math.Pow
    {
        public int Id { get; set; }
        public double First { get; set; }
        public double Second { get; set; }
        public double Result { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public Operation()
        {
            CreationDate = DateTime.Now;
        }

        public Operation(int id, double first, double second, double result, string description)
        {
            Id = id;
            First = first;
            Second = second;
            Result = result;
            Description = description;
            CreationDate = DateTime.Now;
        }

    }
}
