using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CRUDWebAPIwithStoredP.Models;

namespace CRUDWebAPIwithStoredP.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3NTN1LG\\SQLEXPRESS;Initial Catalog=EMPSPAPI;Integrated Security=True");


        public string EmployeeOpt(Employee emp)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("SP_Employee",con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID",emp.ID);
                com.Parameters.AddWithValue("@Email", emp.Email);
                com.Parameters.AddWithValue("@Emp_Name", emp.Emp_Name);
                com.Parameters.AddWithValue("@Designation", emp.Designation);
                com.Parameters.AddWithValue("@Type", emp.Type);
                con.Open();
             //   con.ExcuteNonQuery();
                con.Close();
                msg = "Success";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                
            }
            finally
            {
                if (con.State==ConnectionState.Open)
                {
                    con.Close();

                }
            }
            return msg;
        }


        //Get-Record : 
        public DataSet EmployeeGet(Employee emp , out string msg)
        {
             msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("SP_Employee", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", emp.ID);
                com.Parameters.AddWithValue("@Email", emp.Email);
                com.Parameters.AddWithValue("@Emp_Name", emp.Emp_Name);
                com.Parameters.AddWithValue("@Designation", emp.Designation);
                com.Parameters.AddWithValue("@Type", emp.Type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";

            }
            catch (Exception ex)
            {
                msg = ex.Message;

            }
            return ds;
        }

    }
}
