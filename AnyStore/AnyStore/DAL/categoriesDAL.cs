using AnyStore.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStore.DAL{
    class categoriesDAL
    {
        //static string for database connection string
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Select Method
        public DataTable Select()
        {
            // Creating database connectiom
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                // Writing SQL query to get all the data from database
                string sql = "SELECT*FROM tbl_categories";
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter();
                //Open database connection
                conn.Open();

                // Adding the value from adapter to data table dt
                adapter.Fill(dt);



            }
            catch (Exception ex) {


                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return dt;
        }
        #endregion
        #region Insert New CAtegory
        public bool Insert(categoriesBLL c)
        {
            //Creating A boolean Variable and set its default value to false
            bool isSucces = false;
            // Connecting  A Database
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                // Writing Query 
                string sql = "INSERT INTO tbl_categories(title,description,added_date,added_by) VALUES(@title,@description,@added_date,@added_by)";
                //Creating SQL Command to pass value in our query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing values through parameter
                cmd.Parameters.AddWithValue("@title", c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);
                // Open Database Connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                // if the query is executed successfully then its value will be greater than 0 else it will be less than 0
                if(rows>)
                {
                    // Query Executed Successfully
                    isSucces = true;
                }
                else
                {
                    //Failed to Execute Query
                    isSucces = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                //closing Database Connection
                conn.Close();
            }

            return isSucces;
        }
        #endregion

    }
}