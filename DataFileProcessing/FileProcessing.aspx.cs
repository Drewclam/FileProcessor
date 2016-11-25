using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using System.IO;

namespace DataFileProcessing
{
    public partial class FileProcessing : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {           
            Label1.Text = "Process Employee File For ABC Company";
            Button1.Text = "Submit";
            ObjectDataSource1.SelectMethod = "GetEmployees";
            ObjectDataSource1.TypeName = "ClassLibrary.FileDisplay";
            GridView1.DataSourceID = "ObjectDataSource1";
            // GridView1.ItemTemplate = ObjectDataSource1;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                bool fileOK = false;
                string path = Server.MapPath("~/UploadedImages/");
                string fileExtension = "";
                if (FileUpload1.HasFile)
                {
                    fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                    string[] allowedExtensions = { ".xml", ".txt", ".csv" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }
                }

                FileDisplay initFileDisplay = new FileDisplay();
                // Use the appropriate processor to read the file
                if (fileOK == true)
                {
                    if (fileExtension == ".xml")
                    {
                        FileProcessor.ProcessorXmlFile(FileUpload1);
                        initFileDisplay.GetEmployees();
                    }

                    else if (fileExtension == ".txt")
                    {
                        FileProcessor.ProcessorTxtFile(FileUpload1);
                        initFileDisplay.GetEmployees();
                    }

                    else if (fileExtension == ".csv")
                    {
                        FileProcessor.ProcessorCsvFile(FileUpload1);
                        initFileDisplay.GetEmployees();
                    }
                }

                else
                {
                    Label1.Text = "Cannot accept files of this type.";
                }
            }
        }
    }
}