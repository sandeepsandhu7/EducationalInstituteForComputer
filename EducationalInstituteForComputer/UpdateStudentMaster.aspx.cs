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
    public partial class UpdateStudentMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Student_Fill();
                FillStudents();
                CourseFill();
                TeacherFill();
            }
        }

        private void FillStudents()
        {
            Student_Bussiness Obj_Cour = new Student_Bussiness();
            List<Student> Obj_Student_ID = Obj_Cour.GetStudents();

            if (Obj_Student_ID != null && Obj_Student_ID.Count > 0)
            {
                for (int i = 0; i < Obj_Student_ID.Count; i++)
                {
                    ddl_Student.Items.Add(Obj_Student_ID[i].ID.ToString());
                }
                ddl_Student.Items.Insert(0, new ListItem("Select Student", " "));
            }
            else
            {
                ddl_Student.Items.Clear();
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
            Student Obj_Ins_St = new Student
            {
                ID = Convert.ToInt32(ddl_Student.SelectedValue),
                Name = txtStudentName.Text,
                Address = txtAddress.Text,
                Email = txtEmail.Text,
                Mobile = txtMobile.Text,
                FatherName = txtFatherName.Text,
                DOB = txtDOB.Text,
                CourseID = Convert.ToInt32(ddl_Course.SelectedValue),
                TeacherID = Convert.ToInt32(ddl_Teacher.SelectedValue)
            };
            Student_Bussiness.UpdateStudent(Obj_Ins_St);
            Student_Fill();
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
        protected void Delete_Click(object sender, EventArgs e)
        {
            Student_Bussiness.DeleteStudent(ddl_Student.SelectedValue);
            Student_Fill();
        }

        protected void ddl_Student_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Student> Obj_Student = Student_Bussiness.GetStudentDetails(ddl_Student.SelectedValue);
            if (Obj_Student != null && Obj_Student.Count > 0)
            {
                for (int i = 0; i < Obj_Student.Count; i++)
                {
                    txtStudentName.Text = Obj_Student[i].Name;
                    txtAddress.Text = Obj_Student[i].Address;
                    txtFatherName.Text = Obj_Student[i].FatherName;
                    txtMobile.Text = Obj_Student[i].Mobile;
                    txtEmail.Text = Obj_Student[i].Email;
                    txtDOB.Text = Obj_Student[i].DOB;
                    ddl_Course.SelectedValue = Convert.ToString(Obj_Student[i].CourseID);
                    ddl_Teacher.SelectedValue = Convert.ToString(Obj_Student[i].TeacherID);
                }
            }
        }
    }
}