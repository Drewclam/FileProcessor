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

                // do your coding 
                //Loop trough txt file and add employees to FileProcessor.empList  
                Console.WriteLine(textLine);

            } while (reader.Peek() != -1);
            reader.Close();

        }
        public static void ProcessorCsvFile(FileUpload fu)
        {

        }
        public static void ProcessorXmlFile(FileUpload fu)
        {

        }
    }
}
