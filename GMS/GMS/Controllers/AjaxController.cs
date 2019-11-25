using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.Models;

namespace GMS.Controllers
{
    public class AjaxController : Controller
    {
        [HttpPost]
        public JsonResult upload_tempProfile_image(int crop_x, int crop_y, int crop_w, int crop_h)
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    string ff = "";
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;

                        }


                        ff = fname;
                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/assets/Uploads/temp_upload"), fname);

                        file.SaveAs(fname);
                        Bitmap croppedImage;
                        using (var originalImage = new Bitmap(fname))
                        {
                            Rectangle crop = new Rectangle(crop_x, crop_y, crop_w, crop_h);

                            // Here we capture another resource.
                            croppedImage = originalImage.Clone(crop, originalImage.PixelFormat);

                        } //
                        croppedImage.Save(fname);

                        // It is desirable release this resource too.
                        croppedImage.Dispose();
                    }
                    respo p = new respo
                    {
                        status = "True",
                        image = ff
                    };
                    // Returns message that successfully uploaded  
                    return Json(p);
                }
                catch (Exception ex)
                {
                    respo p = new respo
                    {
                        status = "False",
                        message = ex.ToString()
                    };
                    return Json(p);
                }
            }
            else
            {
                respo p = new respo
                {
                    status = "False",
                    message = "Image Not Selected"
                };
                return Json(p);
            }
        }
        public class respo
        {
            public string status { get; set; }
            public string image { get; set; }
            public string message { get; set; }
        }
    }

}