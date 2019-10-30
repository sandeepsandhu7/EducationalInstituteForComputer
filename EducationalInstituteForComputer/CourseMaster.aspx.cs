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
    public partial class CourseMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Course_Fill();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            Course Obj_Add_Cour = new Course
            {
                CourseName = txtCourseName.Text,
            };
            Course_Bussiness.SaveCourses(Obj_Add_Cour);
            Course_Fill();
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseMaster.aspx");

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
    }
}