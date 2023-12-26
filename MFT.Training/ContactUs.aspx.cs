using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MFT.Training
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
            
            if(upl_avatar.HasFile)
            {
                string contentType = upl_avatar.PostedFile.ContentType;
                if(contentType!="image/jpeg" && contentType!="image/png")
                {
                    throw new ApplicationException("نوع فایل غیر قابل قبول هست");
                }
                if(upl_avatar.PostedFile.ContentLength> 3145728)
                {
                    throw new ApplicationException("حداکثر اندازه ی فایل مورد قبول 3 مکابایت می باشد");
                }
                string path = Server.MapPath("./");
                upl_avatar.SaveAs($"{path}/Media/Images/Avatars/{upl_avatar.PostedFile.FileName}");
            }
            
        }
    }
}