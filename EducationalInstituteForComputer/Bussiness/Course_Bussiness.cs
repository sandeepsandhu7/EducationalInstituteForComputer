using EducationalInstituteForComputer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationalInstituteForComputer.Bussiness
{
    public class Course_Bussiness
    {
        EducationalInstituteEntities _db = new EducationalInstituteEntities();
        public List<Course> GetCourses()//This is courses list method
        {
            try
            {
                List<Course> obj_Course = null;
                obj_Course = (from o in _db.Courses select o).ToList();
                return obj_Course;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SaveCourses(Course Obj_Course_Save)//This is Add method.
        {
            try
            {
                using (EducationalInstituteEntities db = new EducationalInstituteEntities())
                {
                    db.Courses.Add(Obj_Course_Save);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<Course> GetCourseDetails(string selectedValue)
        {
            try
            {
                List<Course> Obj_Course_Detail = null;
                using (EducationalInstituteEntities db = new EducationalInstituteEntities())
                {
                    Obj_Course_Detail = (from c in db.Courses where c.ID.ToString() == selectedValue select c).ToList();
                }
                return Obj_Course_Detail
;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateCourse(Course Obj_Course_Update)
        {
            try
            {
                using (EducationalInstituteEntities db = new EducationalInstituteEntities())
                {
                    //Lambda expression

                    Course c = db.Courses.SingleOrDefault(x => x.ID == Obj_Course_Update.ID);
                    c.CourseName = Obj_Course_Update.CourseName;
                    db.SaveChanges();
                    return Obj_Course_Update.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteCourse(string Obj_Course_Delete)
        {
            try
            {
                using (EducationalInstituteEntities db = new EducationalInstituteEntities())
                {
                    //Lambda expression
                    Course c = db.Courses.SingleOrDefault(x => x.ID.ToString().Trim() == Obj_Course_Delete.Trim());
                    if (c != null)
                    {
                        db.Courses.Remove(c);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}