using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace csharp_1.resources.classes
{
    class Data
    {
        Database db;
        public Data() 
            {
            db = new Database();
            MySql.Data.MySqlClient.MySqlConnection conn = initDbConn("UserId=root;Host=localhost;password=root;Database=csharp");

            Assignment dummyAssignment = new Assignment("Rensenpark", new DateTime(2022, 6, 22), new DateTime(2022, 7, 28));
            List<Customer> dummyCustomers = new List<Customer>()
            {
                new Customer("Willem"),
                new Customer("Michel"),
                new Customer("Moniek"),
            };
            List<Dish> dummyDishes = new List<Dish>()
            {
                new Dish(3.0f, "Chateau Briand", false, true, false),
                new Dish(2.0f, "Tomatensoep", true, false, false),
                new Dish(2.0f, "Pavlova", false, false, true),
            };

            try
            {
                db.executeQuery("INSERT INTO assignment(name, startDate, endDate) VALUES (@name, @startDate, @endDate)", new Dictionary<String, String>()
                {
                    ["name"] = $"{dummyAssignment.Name}",
                    ["startDate"] = $"{dummyAssignment.StartDate.ToString("yyyy-MM-dd")}",
                    ["endDate"] = $"{dummyAssignment.EndDate.ToString("yyyy-MM-dd")}"
                });

                foreach (Customer c in dummyCustomers)
                {
                    db.executeQuery("INSERT INTO customer(name) VALUES (@name)", new Dictionary<String, String>()
                    {
                        ["name"] = $"{c.Name}",
                    });
                };

                foreach (Dish d in dummyDishes)
                {
                    db.executeQuery("INSERT INTO dish(price, name, appetizer, maincourse, dessert) VALUES (@price, @name, @appetizer, @maincourse, @dessert)", new Dictionary<String, String>()
                    {
                        ["price"] = $"{d.Price}",
                        ["name"] = $"{d.Name}",
                        ["appetizer"] = $"{Convert.ToInt32(d.Appetizer)}",
                        ["maincourse"] = $"{Convert.ToInt32(d.MainCourse)}",
                        ["dessert"] = $"{Convert.ToInt32(d.Dessert)}"
                    });
                };
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error!: {e}");
            }

            db.dbClose();
        }
        private MySql.Data.MySqlClient.MySqlConnection initDbConn(String dbString)
        {
            db.Conn = dbString;
            try
            {
                MySql.Data.MySqlClient.MySqlConnection conn = (MySql.Data.MySqlClient.MySqlConnection)db.Conn;
                return conn;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error! failed to convert: {e}");
            }
            return null;
        }
    }
}
