using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace object_oriented_2_lab_2__inheritance_.Entities
{
   
    internal class Salaried : Employee
    {
        
        private readonly double salary;

        public double Salary
        {
            get
            {
                return salary;
            }
        }

        public override double Pay
        {
            get
            {
                return salary;
            }
        }

        
        public Salaried(string id, string name, double salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
        }
    }
}
