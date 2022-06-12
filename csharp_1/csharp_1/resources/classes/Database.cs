using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_1.resources.classes
{
    class Database
    {
        private MySql.Data.MySqlClient.MySqlConnection conn;
        public object Conn
        {
            get
            {
                return this.conn;
            }
            set
            {
                try
                {
                    this.conn = new MySql.Data.MySqlClient.MySqlConnection($"{value}");
                    this.conn.Open();
                    MessageBox.Show($"Connected!");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"failed to connect to the database! {e.Message}");
                };
            }
        }


        // close the database connection
        public Boolean dbClose()
        {
            try
            {
                this.conn.Close();
                MessageBox.Show($"Connection closed!");
            }
            catch (Exception e)
            {
                MessageBox.Show($"failed to close db connection! {e.Message}");
                return false;
            }
            return true;
        }

        public List<List<String>> selectQuery(String query, MySql.Data.MySqlClient.MySqlConnection conn)
        {
            List<List<String>> records = new List<List<String>>();
            try
            {
                // instantiate the command and add the query to the command class
                MySql.Data.MySqlClient.MySqlCommand command = conn.CreateCommand();
                command.CommandText = query;

                // execute the reader (retrieve results)
                MySql.Data.MySqlClient.MySqlDataReader reader = command.ExecuteReader();

                // assign the values to the records list
                while (reader.Read())
                {
                    List<String> tempList = new List<String>();
                    tempList.Add(reader["id"].ToString());
                    tempList.Add(reader["naam"].ToString());
                    tempList.Add(reader["kwaliteit"].ToString());
                    tempList.Add(reader["beschrijving"].ToString());
                    tempList.Add(reader["bedrag"].ToString());
                    records.Add(tempList);
                }
                return records;
            }
            catch (Exception e)
            {
                MessageBox.Show($"ERROR: query failed! {e.Message}");
                return null;
            }
        }

        public Boolean executeQuery(String query, MySql.Data.MySqlClient.MySqlConnection conn, Dictionary<String, String> parameters)
        {
            // instantiate the command object and add a query
            MySql.Data.MySqlClient.MySqlCommand command = conn.CreateCommand();
            command.CommandText = query;

            // temporary save all keys from the parameters parameter
            List<String> keys = new List<String>(parameters.Keys);

            // add all parameters (note that column name must match, and must be at the same spot as the column name in the query)
            foreach (String key in keys)
            {
                command.Parameters.Add($"@{key}", parameters[key]);
            }

            // prepare the query
            command.Prepare();

            // execute query
            if (command.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
