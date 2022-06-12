using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_1.resources.classes
{
    class Dish
    {
        private float price;
        private String name;
        private Boolean appetizer;
        private Boolean mainCourse;
        private Boolean dessert;

        public Dish(float price, String name, Boolean appetizer, Boolean mainCourse, Boolean dessert)
        {
            this.price = price;
            this.name = name;
            this.appetizer = appetizer;
            this.mainCourse = mainCourse;
            this.dessert = dessert;
        }

        public float Price {
            get
            {
                return this.price;
            }
            set
            {
                if (value > 0)
                {
                    this.price = value;
                };
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length > 0)
                {
                    this.name = value;
                }
            }
        }

        public Boolean Appetizer
        {
            get
            {
                return this.appetizer;
            }
        }

        public Boolean MainCourse
        {
            get
            {
                return this.mainCourse;
            }
        }

        public Boolean Dessert
        {
            get
            {
                return this.dessert;
            }
        }
    }
}
