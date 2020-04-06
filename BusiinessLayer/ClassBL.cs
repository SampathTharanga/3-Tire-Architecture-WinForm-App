using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusiinessLayer
{
    public class ClassBL
    {
        public ClassDL objDataLayer = new ClassDL();

        public void AddNewEmployee(string email, string name)
        {
            objDataLayer.AddNewEmployeeDB(email, name);
        }

        public void UpdateEmployee(string email, string name)
        {
            objDataLayer.UpdateEmployeeDB(email, name);
        }

        public void DeleteEmployee(string email)
        {
            objDataLayer.DeleteEmployeeDB(email);
        }

        public object LoadEmployee()
        {
            return objDataLayer.LoadEmployeeDB();
        }
    }
}
