using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class FileDisplay
    {
        // Loops through employee list in FileProcessor and creates DataTable object
        public DataTable GetEmployees()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("FirstName", typeof(String));
            dt.Columns.Add("LastName", typeof(String));
            dt.Columns.Add("Department", typeof(String));
            dt.Columns.Add("Sex", typeof(String));
            dt.Columns.Add("Age", typeof(int));
            dt.Columns.Add("Salary", typeof(int));
           
            for (int i = 0; i < FileProcessor.empList.Count; i++)
            {
                DataRow newRow = dt.NewRow();

                newRow["FirstName"] = FileProcessor.empList[i].FirstName;
                newRow["LastName"] = FileProcessor.empList[i].LastName;
                newRow["Department"] = FileProcessor.empList[i].Department;
                newRow["Sex"] = FileProcessor.empList[i].Sex;
                newRow["Age"] = FileProcessor.empList[i].Age;
                newRow["Salary"] = FileProcessor.empList[i].Salary;

                dt.Rows.Add(newRow);
            }
            return dt;
        }
    }
}
