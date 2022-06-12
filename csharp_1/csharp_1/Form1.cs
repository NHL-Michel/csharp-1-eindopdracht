using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

// local imports
using csharp_1.resources.classes;

namespace csharp_1
{
    public partial class Form1 : Form
    {
        Database db;
        MySql.Data.MySqlClient.MySqlConnection conn;
        List<List<String>> dbCustomers; // all customers related to an assignment (in this case assignment 10)
        List<List<String>> dbDishes; // all dishes related to an assignment (in this case assignment 10)
        List<List<String>> dbDates; //
        public Form1()
        {
            // -- start splashscreen
            Thread t = new Thread(new ThreadStart(startSplashScreen)); // create a new thread with the splashScreen
            t.Start(); // start the thread
            Thread.Sleep(5000); // wait 5 seconds
            InitializeComponent();
            this.ContextMenuStrip = contextMenuStrip2;
            t.Abort(); // stop the thread

            // create db connection
            db = new Database();
            conn = initDbConn("UserId=root;Host=localhost;password=root;Database=csharp");

            // customers & dishes used on tab 1
            this.dbCustomers = db.selectQuery("SELECT DISTINCT customer.id, customer.name " +
                                                "FROM customer " +
                                                "INNER JOIN orderr " +
                                                "ON customer.id = orderr.customer_id " +
                                                "INNER JOIN assignment " +
                                                "ON orderr.assignment_id " +
                                                "WHERE assignment.id = 10 ", new List<String> { "id", "name" });
            conn.Close();
            conn.Open();
            this.dbDishes = db.selectQuery("SELECT DISTINCT dish.id, dish.price, dish.name, dish.appetizer, dish.maincourse, dish.dessert " +
                                            "FROM dish " +
                                            "INNER JOIN dish_assignment " +
                                            "ON dish.id = dish_assignment.dish_id " +
                                            "INNER JOIN assignment " +
                                            "ON dish_assignment.assignment_id = assignment.id " +
                                            "where assignment.id = 10", new List<String> { "id", "price", "name", "appetizer", "maincourse", "dessert" });
            conn.Close();
            conn.Open();
            this.dbDates = db.selectQuery(@"SELECT DISTINCT order_date
                                             FROM orderr
                                             ORDER BY order_date DESC", new List<String> { "order_date"});

            conn.Close();
            // set the comboBoxes on tab one
            initTabOne();
            // tab two requires no initialization by a seperate script.
            // set three comboBox on tab three
            initTabThree();
        }

        // splashScreen
        private void startSplashScreen() {
            Application.Run(new splashScreen());
        }

        // initialize database connection
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
        public void initTabOne()
        {
            // init dishes
            foreach (List<String> dish in this.dbDishes) 
            {
                comboBox2.Items.Add($"{dish[0]}. {dish[2]}");
            }

            // init customers
            foreach (List<String> customer in this.dbCustomers)
            {
                comboBox3.Items.Add($"{customer[0]}. {customer[1]}");
            }
        }

        public void initTabThree() 
        {
            foreach (List<String> date in this.dbDates)
            {
                String[] unsortedDate = date[0].Split(' ')[0].Split('-');
                String sortedDate = $"{unsortedDate[2]}-{unsortedDate[1]}-{unsortedDate[0]}";
                comboBox1.Items.Add($"{sortedDate}");
            }
        }

        // ---- start context menu ----- //
        // shows the aboutbox
        private void showAboutMenu(object sender, EventArgs e)
        {
            AboutBox a = new AboutBox();
            a.Show();
        }

        // show tab 1 (0)
        private void showPageOne(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(0);
        }

        // show tab 2 (1)
        private void showPageTwo(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(1);
        }

        // show tab 3 (2)
        private void showPageThree(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(2);
        }

        // opens the app once it is minimized
        private void openMinimizedApp(object sender, EventArgs e)
        {
            this.Show();
        }

        // closes the entire application. Including the aboutBox, if it is open.
        private void closeApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // ---- end context menu ----- //

        private void generateData(object sender, EventArgs e)
        {
            //new Data();
        }

        // order a dish (tab 1) - als in bestellen van een gerecht, niet sorteren
        private void orderDish(object sender, EventArgs e)
        {
            String dishId = this.comboBox2.Text.Split('.')[0];
            String customerId = this.comboBox3.Text.Split('.')[0];
            if (!string.IsNullOrEmpty(dishId) && !string.IsNullOrEmpty(customerId))
            {
                conn.Open();
                db.executeQuery(@"INSERT INTO orderr (assignment_id, customer_id, dish_id, order_date)
                                VALUES (@assignment_id, @customer_id, @dish_id, @order_date )", new Dictionary<String, String>()
                                {
                                    ["assignment_id"] = "10",
                                    ["customer_id"] = $"{customerId}",
                                    ["dish_id"] = $"{dishId}",
                                    ["order_date"] = DateTime.Now.ToString("yyyy-MM-dd")
                                });
                MessageBox.Show("Your dish has been ordered!");
                conn.Close();
            } else
            {
                MessageBox.Show("Please fill both boxes with a value from the dropdown menu!");
            }
        }

        // show the biggest consumer (tab 2)
        private void showBiggestConsumer(object sender, EventArgs e)
        {
            conn.Open();
            List<List<String>> data = db.selectQuery(@"SELECT customer.name, COUNT(customer_id) as dishes
                                                        FROM orderr
                                                        INNER JOIN customer
                                                        ON orderr.customer_id = customer.id
                                                        GROUP BY orderr.customer_id
                                                        ORDER BY dishes desc
                                                        LIMIT 1", new List<String> { "name", "dishes" });
            this.label7.Text = $"The biggest consumer is {data[0][0]} with {data[0][1]} dishes";
            conn.Close();
        }

        // show all customers that have had an appetizer, but no dessert (tab 2)
        private void showAppetizerCustomers(object sender, EventArgs e)
        {
            conn.Open();
            List<List<String>> data = db.selectQuery(@"SELECT customer.name, MAX(dish.appetizer) as appetizer , MAX(dish.dessert) as dessert
                                                        FROM customer
                                                        INNER JOIN orderr
                                                        ON customer.id = orderr.customer_id
                                                        INNER JOIN dish
                                                        ON orderr.dish_id = dish.id
                                                        GROUP BY customer.name
                                                        HAVING dessert = 0; ", new List<String> { "name", "appetizer", "dessert" });
            this.label7.Text = "";
            foreach (List<String> record in data)
            {
                this.label7.Text += $"Customer {record[0]} has had appetizers, but no desserts";
            }
            conn.Close();
        }

        // show all customers that have spend above the average (tab 2)
        private void showAboveAverageCustomers(object sender, EventArgs e)
        {
            conn.Open();
            List<List<String>> data = db.selectQuery(@"SELECT customer.name, avg(dish.price) custAverage
                                                        FROM customer 
                                                        INNER JOIN orderr 
                                                        ON customer.id = orderr.customer_id 
                                                        INNER JOIN dish
                                                        ON orderr.dish_id = dish.id 
                                                        GROUP BY customer.name 
                                                        HAVING custAverage
                                                        >
                                                        (SELECT avg(dish.price)
                                                            FROM customer
                                                            INNER JOIN orderr
                                                            ON customer.id = orderr.customer_id
                                                            INNER JOIN dish
                                                            ON orderr.dish_id = dish.id)", new List<String> { "name", "custaverage" });

            this.label7.Text = "";
            foreach (List<String> record in data)
            {
                this.label7.Text += $"Customer {record[0]} has spend above average with a \nspend value of ${record[1]}\n\n";
            }
            conn.Close();
        }

        // calculate the total revenue made (tab 3)
        private void calculateTotalRevenue(object sender, EventArgs e)
        {
            conn.Open();
            List<List<String>> data = db.selectQuery(@"SELECT SUM(dish.price) as revenue
                                                        FROM dish 
                                                        INNER JOIN orderr 
                                                        ON orderr.dish_id = dish.id", new List<String> { "revenue" });
            conn.Close();
            this.label3.Text = $"The total revenue is ${data[0][0]}";
        }

        private void calculateAverageRevenueByDate(object sender, EventArgs e)
        {
            String date = comboBox1.Text;

            if (!string.IsNullOrEmpty(date))
            {
                conn.Open();
                List<List<String>> data = db.selectQuery($@"SELECT AVG(dish.price) as averageRevenue 
                                                        FROM dish
                                                        INNER JOIN orderr
                                                        ON orderr.dish_id = dish.id
                                                        GROUP BY order_date
                                                        HAVING orderr.order_date = '{date}'", new List<String> {"averageRevenue" });
                conn.Close();
                this.label3.Text = $"The average revenue made on {date} is \n${data[0][0]}";
            } else
            {
                MessageBox.Show("Please pick a legitimate date!");
            }
        }
    }
}
