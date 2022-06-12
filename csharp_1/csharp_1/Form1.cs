using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// local imports
using csharp_1.resources.classes;

namespace csharp_1
{
    public partial class Form1 : Form
    {
        Database db;
        MySql.Data.MySqlClient.MySqlConnection conn;
        List<List<String>> dbCustomers; // all customers related to an assignment
        List<List<String>> dbDishes; // all dishes related to an assignment

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
            initTabOne();
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

        public void initTabTwo() 
        { 
        
        }

        public void initTabThree() 
        { 
        
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

        private void orderDish(object sender, EventArgs e)
        {
            String dishId = this.comboBox2.Text.Split('.')[0];
            String customerId = this.comboBox3.Text.Split('.')[0];
            if (!string.IsNullOrEmpty(dishId) && !string.IsNullOrEmpty(customerId))
            {
                conn.Open();
                db.executeQuery("INSERT INTO orderr (assignment_id, customer_id, dish_id, order_date) " +
                                "VALUES (@assignment_id, @customer_id, @dish_id, @order_date )", new Dictionary<String, String>()
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
    }
}
