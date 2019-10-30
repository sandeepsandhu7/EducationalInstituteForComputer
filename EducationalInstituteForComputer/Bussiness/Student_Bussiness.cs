using EducationalInstituteForComputer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationalInstituteForComputer.Bussiness
{
    public class Student_Bussiness
    {
        EducationalInstituteEntities _db = new EducationalInstituteEntities();
        public List<Student> GetStudents()//This is Students list method
        {
            try
            {
                List<Student> obj_Student = null;
                obj_Student = (from o in _db.Students select o).ToList();
                return obj_Student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SaveStudents(Student Obj_Student_Save)//This is Add method.
        {
            try
            {
                using (EducationalInstituteEntities db = new EducationalInstituteEntities())
                {
                    db.Students.Add(Obj_Student_Save);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<Student> GetStudentDetails(string selectedValue)
        {
            try
            {
                List<Student> Obj_Student_Detail = null;
                using (EducationalInstituteEntities db = new EducationalInstituteEntities())
                {
                    Obj_Student_Detail = (from c in db.Students where c.ID.ToString() == selectedValue select c).ToList();
                }
                return Obj_Student_Detail
;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateStudent(Student Obj_Student_Update)
        {
            try
            {
                using (EducationalInstituteEntities db = new EducationalInstituteEntities())
                {
                    //Lambda expression
                    Student c = db.Students.SingleOrDefault(x => x.ID == Obj_Student_Update.ID);
                    c.Name = Obj_Student_Update.Name;
                    c.FatherName = Obj_Student_Update.FatherName;
                    c.Address = Obj_Student_Update.Address;
                    c.Email = Obj_Student_Update.Email;
                    c.Mobile = Obj_Student_Update.Mobile;
                    c.DOB = Obj_Student_Update.DOB;
                    c.CourseID = Obj_Student_Update.CourseID;
                    c.TeacherID = Obj_Student_Update.TeacherID;
                    db.SaveChanges();
                    return Obj_Student_Update.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteStudent(string Obj_Student_Delete)
        {
            try
            {
                using (EducationalInstituteEntities db = new EducationalInstituteEntities())
                {
                    //Lambda expression
                    Student c = db.Students.SingleOrDefault(x => x.ID.ToString().Trim() == Obj_Student_Delete.Trim());
                    if (c != null)
                    {
                        db.Students.Remove(c);
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