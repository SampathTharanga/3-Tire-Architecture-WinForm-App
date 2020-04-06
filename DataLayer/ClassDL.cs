using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ClassDL
    {
        private string conn = ConfigurationManager.ConnectionStrings["ConnectionDB"].ToString();
        //String conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sampath\Desktop\THADIYA SERVAY DIPARTMENT\3 Tire Architecture\3TireArchitecture\DataLayer\Database3Tire.mdf;Integrated Security=True";
        public void InsertUpdateDeleteSQLString(string sqlstring)
        {
            SqlConnection objsqlcon = new SqlConnection(conn);
            objsqlcon.Open();
            SqlCommand objcmd = new SqlCommand(sqlstring, objsqlcon);
            objcmd.ExecuteNonQuery();
        }

        public object ExecuteSqlString(string sqlstring)
        {
            SqlConnection objsqlconn = new SqlConnection(conn);
            objsqlconn.Open();
            DataSet ds = new DataSet();
            SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
            SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
            objAdp.Fill(ds, "Table_Employee");
            return ds;
        }
        public void AddNewEmployeeDB(string email, string name)
        {
            string sql = "INSERT INTO Table_Employee (email, name) VALUES ('" + email + "', '" + name + "')";
            InsertUpdateDeleteSQLString(sql);
        }

        public void UpdateEmployeeDB(string email, string name)
        {
            string sql = "UPDATE Table_Employee SET name='" + name + "' WHERE email='" + email + "'";
            InsertUpdateDeleteSQLString(sql);
        }

        public void DeleteEmployeeDB(string email)
        {
            string sql = "DELETE FROM Table_Employee WHERE email='" + email + "'";
            InsertUpdateDeleteSQLString(sql);
        }

        public object LoadEmployeeDB()
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM Table_Employee";
            ds = (DataSet)ExecuteSqlString(sql);
            return ds;
        }
    }
}
