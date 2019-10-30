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
    public partial class UpdateCourseMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillCourses();
                Course_Fill();
            }
        }

        protected void ddl_Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Course> Obj_Course = Course_Bussiness.GetCourseDetails(ddl_Course.SelectedValue);
            if (Obj_Course != null && Obj_Course.Count > 0)
            {
                for (int i = 0; i < Obj_Course.Count; i++)
                {
                    txtCourseName.Text = Obj_Course[i].CourseName;
                }
            }
        }

        private void FillCourses()
        {
            Course_Bussiness Obj_Cour = new Course_Bussiness();
            List<Course> Obj_Course_ID = Obj_Cour.GetCourses();

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
        private void Course_Fill()
        {
            Course_Bussiness Obj_Course = new Course_Bussiness();
            List<Course> Obj_Cour = Obj_Course.GetCourses();
            if (Obj_Cour != null && Obj_Cour.Count > 0)
            {
                grd.DataSource = Obj_Cour;
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
            Course Obj_Ins_Cour = new Course
            {
                ID = Convert.ToInt32(ddl_Course.SelectedValue),
                CourseName = txtCourseName.Text,
                
            };
            Course_Bussiness.UpdateCourse(Obj_Ins_Cour);
            Course_Fill();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            Course_Bussiness.DeleteCourse(ddl_Course.SelectedValue);
            Course_Fill();
        }
    }
}