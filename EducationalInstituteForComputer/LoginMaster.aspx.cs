using EducationalInstituteForComputer.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EducationalInstituteForComputer
{
    public partial class LoginMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                    Response.Redirect("Default.aspx?msg=Successfully Logged in.");
                }
            }
            if (Request.QueryString["msg"] != null)
            {
                Label1.Text = Request.QueryString["msg"];
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            UserVM vmModel = new UserVM();

            Response.Cookies["UserName"].Value = tbxUsername.Text.Trim();
            Response.Cookies["Password"].Value = tbxPassword.Text.Trim();
            vmModel.UserName = tbxUsername.Text.Trim();
            vmModel.Password = tbxPassword.Text.Trim();
            Login_Business login_Business = new Login_Business();
            bool msg = login_Business.LoginUser(vmModel);
            if (msg)
            {

                Response.Redirect("Default.aspx");
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Login ID and Password is invalid.";
            }

        }
       
    }
}