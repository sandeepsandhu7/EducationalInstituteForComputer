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
    public partial class UpdateTeacherMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillTeacher();
            Teacher_Fill();
        }

        protected void ddl_Teacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Teacher> Obj_Teacher = Teacher_Bussiness.GetTeacherDetails(ddl_Teacher.SelectedValue);
            if (Obj_Teacher != null && Obj_Teacher.Count > 0)
            {
                for (int i = 0; i < Obj_Teacher.Count; i++)
                {
                    txtTeacherName.Text = Obj_Teacher[i].Name;
                    txtFatherName.Text = Obj_Teacher[i].FatherName;
                    txtAddress.Text = Obj_Teacher[i].Address;
                    txtEmail.Text = Obj_Teacher[i].Email;
                    txtMobile.Text = Obj_Teacher[i].Mobile;
                }
            }
        }
        private void FillTeacher()
        {
            Teacher_Bussiness Obj_Teach = new Teacher_Bussiness();
            List<Teacher> Obj_Teacher_ID = Obj_Teach.GetTeachers();

            if (Obj_Teacher_ID != null && Obj_Teacher_ID.Count > 0)
            {
                for (int i = 0; i < Obj_Teacher_ID.Count; i++)
                {
                    ddl_Teacher.Items.Add(Obj_Teacher_ID[i].ID.ToString());
                }
                ddl_Teacher.Items.Insert(0, new ListItem("Select Teacher", " "));
            }
            else
            {
                ddl_Teacher.Items.Clear();
            }
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

        protected void Submit_Click(object sender, EventArgs e)
        {
            Teacher Obj_Ins_Teach = new Teacher
            {
                ID = Convert.ToInt32(ddl_Teacher.SelectedValue),
                Name = txtTeacherName.Text,
                FatherName = txtFatherName.Text,
                Address = txtAddress.Text,
                Email = txtEmail.Text,
                Mobile = txtMobile.Text

            };
            Teacher_Bussiness.UpdateTeacher(Obj_Ins_Teach);
            Teacher_Fill();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            Teacher_Bussiness.DeleteTeacher(ddl_Teacher.SelectedValue);
            Teacher_Fill();
        }
    }
}