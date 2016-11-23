using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ClassLibrary
{
    public static class FileProcessor
    {
        // Parse uploaded files and append to empList
        public static List<Employee> empList = new List<Employee>();
        public static void ProcessorTxtFile(FileUpload fu)
        {
            StreamReader reader = new StreamReader(fu.FileContent);
            do
            {
                string textLine = reader.ReadLine();
                // All information for each employee stored in whole string 
                string[] parseTextLine = textLine.Split('\n');
                foreach (string item in parseTextLine)
                {

                    empList.Add(new Employee() { FirstName = item.Substring(0, 9), LastName = item.Substring(10, 9),
                                                 Department = item.Substring(20, 11),
                                                 Age = Convert.ToInt32(item.Substring(40,2)), Sex = item.Substring(42,1),
                                                 Salary = Convert.ToInt32(item.Substring(44,5)) });
                }
                //string EmployeeInfo = "";

                //foreach (string item in textLineEmployee)
                //{
                //    string temp = "";
                //    for (int i = 0; i < item.Length; i++)
                //    {
                //        if (item[i].ToString() == " " && temp != "")
                //        {
                //            EmployeeInfo += temp +",";
                //            temp = ""; 
                //        }

                //        else if (item[i].ToString() != " ")
                //        {
                //            temp += item[i].ToString();
                //        }

                //        if (i == item.Length-1)
                //        {
                //            EmployeeInfo += temp;
                //        }
                //    }
                //}
                //string[] arr = EmployeeInfo.Split(',');
                //empList.Add(new Employee() { FirstName = arr[0], LastName = arr[1], Department = arr[2] });
            } while (reader.Peek() != -1);
            reader.Close();

        }
        public static void ProcessorCsvFile(FileUpload fu)
        {
            StreamReader reader = new StreamReader(fu.FileContent);
            do
            {
                string textLine = reader.ReadLine();

                // do your coding 
                string[] csvData = textLine.Split(',');
                //Loop trough txt file and add employees to FileProcessor.empList  

            } while (reader.Peek() != -1);
            reader.Close();


        }
        public static void ProcessorXmlFile(FileUpload fu)
        {

        }
    }
}
