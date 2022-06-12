using System;
using System.Collections.Generic;

namespace csharp_1.resources.classes
{
    class Customer
    {

        private String name;
        private Dictionary<DateTime, List<Dish>> orderedDishes;

        public Customer(String name)
        {
            this.name = name;
            this.orderedDishes = new Dictionary<DateTime, List<Dish>>();
        }

        public String Name
        {
            set
            {
                if (value.Length > 0) {
                    this.name = value;
                };
            }

            get
            {
                return this.name;
            }
        }

        // start other methods
        public List<Dish> orderDish(String dishName, DateTime orderDate) {
            return null;
        }
    }
}
