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


            if (IsPostBack)
            {
                bool fileOK = false;
                string path = Server.MapPath("~/UploadedImages/");
                if (FileUpload1.HasFile)
                {
                    string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                    string[] allowedExtensions = {".xml", ".txt", ".csv"};
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }
                }

                // Use the appropriate processor to read the file
                if (fileOK == true)
                {
                    if (Path.GetExtension(FileUpload1.FileName).ToLower() == ".xml")
                    {
                        FileProcessor.ProcessorXmlFile(FileUpload1);
                    }

                    else if (Path.GetExtension(FileUpload1.FileName).ToLower() == ".txt")
                    {
                        FileProcessor.ProcessorTxtFile(FileUpload1);
                    }

                    else if (Path.GetExtension(FileUpload1.FileName).ToLower() == ".csv")
                    {
                        FileProcessor.ProcessorCsvFile(FileUpload1);
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