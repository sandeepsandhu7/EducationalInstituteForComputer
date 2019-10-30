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
    public partial class StudentMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CourseFill();
                TeacherFill();
                Student_Fill();
            }
        }
        private void CourseFill()
        {
            Course_Bussiness Obj_Teach = new Course_Bussiness();
            List<Course> Obj_Course_ID = Obj_Teach.GetCourses();

            if (Obj_Course_ID != null && Obj_Course_ID.Count > 0)
            {
                for (int i = 0; i < Obj_Course_ID.Count; i++)
                {
                    ddl_Course.Items.Add(Obj_Course_ID[i].ID.ToString());
                }
                ddl_Course.Items.Insert(0, new ListItem("Select Course", " "));
            }
            else
            {
                ddl_Course.Items.Clear();
            }
        }
        private void TeacherFill()
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

        protected void Submit_Click(object sender, EventArgs e)
        {
            Student Obj_Add_Teacher = new Student
            {
                Name = txtStudentName.Text,
                FatherName = txtFatherName.Text,
                Address = txtAddress.Text,
                Mobile = txtMobile.Text,
                Email = txtEmail.Text,
                DOB = txtDOB.Text,
                CourseID = Convert.ToInt32(ddl_Course.SelectedValue),
                TeacherID = Convert.ToInt32(ddl_Teacher.SelectedValue),
            };
            Student_Bussiness.SaveStudents(Obj_Add_Teacher);
            Student_Fill();
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentMaster.aspx");
        }
        private void Student_Fill()
        {
            Student_Bussiness Obj_Student = new Student_Bussiness();
            List<Student> Obj_St = Obj_Student.GetStudents();
            if (Obj_St != null && Obj_St.Count > 0)
            {
                grd.DataSource = Obj_St;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
    }
}