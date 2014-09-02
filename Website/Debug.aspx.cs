using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class Debug : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Website.ServiceReference1.IMediaService mediaService = new Website.ServiceReference1.MediaServiceClient();//      .ServiceClient().
            mediaService.Play(txtNickname.Text + ": " + txtContent.Text);

        }
    }
}