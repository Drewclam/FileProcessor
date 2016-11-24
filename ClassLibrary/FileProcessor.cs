using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Xml;

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

                empList.Add(new Employee() { FirstName = textLine.Substring(0, 9), LastName = textLine.Substring(10, 9),
                    Department = textLine.Substring(20, 11), Age = Convert.ToInt32(textLine.Substring(40,2)), Sex = textLine.Substring(42,1),
                    Salary = Convert.ToInt32(textLine.Substring(44,5)) });               
            } while (reader.Peek() != -1);

            reader.Close();

        }

        public static void ProcessorCsvFile(FileUpload fu)
        {
            StreamReader reader = new StreamReader(fu.FileContent);

            do
            {
                string textLine = reader.ReadLine();
                string[] csvData = textLine.Split(',');

                empList.Add(new Employee()
                { FirstName = csvData[0], LastName = csvData[1], Department = csvData[2], Age = Convert.ToInt32(csvData[3]), Sex = csvData[4],  Salary = Convert.ToInt32(csvData[5])});
            } while (reader.Peek() != -1);

            reader.Close();
        }

        public static void ProcessorXmlFile(FileUpload fu)
        {
            string inputContent;
            using (StreamReader inputStreamReader = new StreamReader(fu.PostedFile.InputStream))
            {
                inputContent = inputStreamReader.ReadToEnd();
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(inputContent);

            // Create node lists by department
            XmlNodeList deptList = doc.DocumentElement.SelectNodes("/employees/department");

            // Loop through employees and extract data
            foreach (XmlNode node in deptList)
            {
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    empList.Add(new Employee()
                    {
                        FirstName = node.ChildNodes[i].ChildNodes[0].InnerText,
                        LastName = node.ChildNodes[i].ChildNodes[1].InnerText,
                        Age = Convert.ToInt32(node.ChildNodes[i].ChildNodes[2].InnerText),
                        Sex = node.ChildNodes[i].ChildNodes[3].InnerText,
                        Salary = Convert.ToInt32(node.ChildNodes[i].ChildNodes[4].InnerText),
                        Department = node.Attributes["name"].InnerText
                    });
                    
                }
            }


        }
    }
}
