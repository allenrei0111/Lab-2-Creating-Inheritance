using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace object_oriented_2_lab_2__inheritance_.Entities
{
    
    internal class Employee
    {
        
        protected string id;
        protected string name;


        public string Id
        {
            get { return id; }
        }

        public string Name
        {
            get => name;
        }

        public virtual double Pay
        {
            get
            {
                return 0;
            }
        }

        
        public Employee()
        {

        }

        
        public Employee(string id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}