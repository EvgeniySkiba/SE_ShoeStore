using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace jQueryUploadTest
{
    /// <summary>
    /// Summary description for Thumbnail1
    /// </summary>
    public class Thumbnail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string  dir = Directory.GetCurrentDirectory();
            string ept = Directory.GetDirectoryRoot(dir); 
            //context.Response.ContentType = "image/jpg";

            /*
             This must be converter
             */
            context.Response.WriteFile(context.Server.MapPath("/images/default_thumb.jpg"));
            //FilesStatus.
        }

        public bool IsReusable { get { return false; } }
    }
}
