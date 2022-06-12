using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_1.resources.classes
{
    class Assignment
    {
        private String name;
        private List<Customer> customers;
        private List<Dish> availableDishes;
        private DateTime startDate;
        private DateTime endDate;

        public Assignment (String name, DateTime startDate, DateTime endDate)
        {
            this.name = name;
            this.customers = new List<Customer>();
            this.availableDishes = new List<Dish>();
            this.startDate = startDate;
            this.endDate = endDate;
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

        //public void addCustomer(Customer cust)
        //{
        //    this.customers.Add(cust);
        //}

        //public void removeCustomer(Customer cust) 
        //{
        //    foreach (Customer tmpCust in this.customers)
        //    {
        //        if (cust.Equals(tmpCust))
        //        {
        //            this.customers.Remove(tmpCust);
        //        }
        //    }
        //}

        //public void addDish(Dish dish)
        //{
        //    this.availableDishes.Add(dish);
        //}

        //public void removeDish(Dish dish)
        //{
        //    foreach (Dish tmpDish in this.availableDishes)
        //    {
        //        if (dish.Equals(tmpDish))
        //        {
        //            this.availableDishes.Remove(tmpDish);
        //        }
        //    }
        //}

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }
            set 
            {
                this.startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
            }
        }

        // start other methods
        public float calculateRevenue()
        {
            return 1;
        }

        public float calculateAverageRevenue(DateTime date)
        {
            return 1;
        }

        public Customer getBiggestConsumer()
        {
            return null;
        }

        public List<Customer> getAppetizerCustomer()
        {
            return null;
        }

        public List<Customer> getAboveAverageCustomers()
        {
            return null;
        }

        public List<Dish> sellDishes(List<String> dishName, DateTime orderDate)
        {
            return null;
        }
    }
}
