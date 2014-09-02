using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Net;

namespace Website
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Cache["FilterWords"] == null)
                {
                    List<string> fileterWords = new List<string>();
                    foreach (String word in WebConfigurationManager.AppSettings["FilterWords"].Split(','))
                    {
                        fileterWords.Add(word);
                    }

                    Cache["FilterWords"] = fileterWords;
                }

                if (Session["NickName"] != null)
                    txtNickname.Text = Session["NickName"].ToString();

                if (Session["FontColor"] != null)
                    ddlFontColor.SelectedValue = Session["FontColor"].ToString();

                if (Session["FontSize"] != null)
                    ddlFontSize.SelectedValue = Session["FontSize"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Cache["FilterWords"] != null)
            {
                foreach (string word in (List<string>)Cache["FilterWords"])
                {
                    if (txtContent.Text.IndexOf(word) >= 0)
                    {
                        Response.Redirect("Errorword.htm");
                    }

                    if (txtNickname.Text.IndexOf(word) >= 0)
                    {
                        Response.Redirect("Errorword.htm");
                    }
                }

            }
            if (String.IsNullOrEmpty(txtContent.Text) || txtContent.Text.Length > 30)
                Response.Redirect("Default.aspx");


            Session["NickName"] = txtNickname.Text;
            Session["FontColor"] = ddlFontColor.SelectedValue;
            Session["FontSize"] = ddlFontSize.SelectedValue;

            string playContent = String.IsNullOrEmpty(txtNickname.Text) ? txtContent.Text : txtNickname.Text + "：" + txtContent.Text;
            int fontSizeIndex = Convert.ToInt32(ddlFontSize.SelectedValue);
            int fontColorIndex = Convert.ToInt32(ddlFontColor.SelectedValue);

            PlayStatus playStatus = PlayStatus.Success;
            try
            {
                Website.ServiceReference1.IMediaService mediaService  = new Website.ServiceReference1.MediaServiceClient();//      .ServiceClient().
                if (!mediaService.PlayByFont(playContent, fontSizeIndex, fontColorIndex))
                {
                    playStatus = PlayStatus.NotPlay;
                }
            }
            catch (Exception ex)
            {
                playStatus = PlayStatus.Failed;
            }
            finally
            {
                switch (playStatus)
                {
                    case PlayStatus.Failed:
                        Response.Redirect("Failed.htm");
                        break;
                    case PlayStatus.NotPlay:
                        Response.Redirect("NotPlay.htm");
                        break;
                    default:
                        Response.Redirect("Success.htm");
                        break;

                }
            }

            txtContent.Text = "";
        }
        
    }

    public enum PlayStatus
    { 
        Success,
        Failed,
        NotPlay
    }
}
