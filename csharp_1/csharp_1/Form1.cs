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
            MySql.Data.MySqlClient.MySqlConnection conn = initDbConn("UserId=root;Host=localhost;password=root;Database=csharp");

            
        }

        public void startSplashScreen() {
            Application.Run(new splashScreen());
        }

        public MySql.Data.MySqlClient.MySqlConnection initDbConn(String dbString)
        {
            db.Conn = dbString;
            try
            {
                MySql.Data.MySqlClient.MySqlConnection conn = (MySql.Data.MySqlClient.MySqlConnection)db.Conn;
                return conn;
            } 
            catch (Exception e)
            {
                MessageBox.Show($"Error! failed to convert {e}");
            }
            return null;
        }

        private void showAboutMenu(object sender, EventArgs e)
        {
            AboutBox a = new AboutBox();
            a.Show();
        }

        private void showPageOne(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(0);
        }

        private void showPageTwo(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(1);
        }

        private void showPageThree(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(2);
        }

        private void openMinimizedApp(object sender, EventArgs e)
        {
            this.Show();
        }

        private void closeApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
