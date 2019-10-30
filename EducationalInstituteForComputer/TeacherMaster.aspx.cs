using EducationalInstituteForComputer.Bussiness;
using EducationalInstituteForComputer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EducationalInstituteForComputer
{
    public partial class TeacherMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Teacher_Fill();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            Teacher Obj_Add_Teacher = new Teacher
            {
                Name = txtTeacherName.Text,
                FatherName = txtFatherName.Text,
                Address = txtAddress.Text,
                Mobile = txtMobile.Text,
                Email = txtEmail.Text,
            };
            Teacher_Bussiness.SaveTeachers(Obj_Add_Teacher);
            Teacher_Fill();
        }
        private void Teacher_Fill()
        {
            Teacher_Bussiness Obj_Teacher = new Teacher_Bussiness();
            List<Teacher> Obj_Teach = Obj_Teacher.GetTeachers();
            if (Obj_Teach != null && Obj_Teach.Count > 0)
            {
                grd.DataSource = Obj_Teach;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherMaster.aspx");
        }
    }
}