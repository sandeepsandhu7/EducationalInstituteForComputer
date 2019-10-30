using EducationalInstituteForComputer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationalInstituteForComputer.Bussiness
{
    public class Teacher_Bussiness
    {
        EducationalInstituteEntities _db = new EducationalInstituteEntities();
        public List<Teacher> GetTeachers()//This is Teachers list method
        {
            try
            {
                List<Teacher> obj_Teacher = null;
                obj_Teacher = (from o in _db.Teachers select o).ToList();
                return obj_Teacher;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SaveTeachers(Teacher Obj_Teacher_Save)//This is Add method.
        {
            try
            {
                using (EducationalInstituteEntities db = new EducationalInstituteEntities())
                {
                    db.Teachers.Add(Obj_Teacher_Save);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<Teacher> GetTeacherDetails(string selectedValue)
        {
            try
            {
                List<Teacher> Obj_Teacher_Detail = null;
                using (EducationalInstituteEntities db = new EducationalInstituteEntities())
                {
                    Obj_Teacher_Detail = (from c in db.Teachers where c.ID.ToString() == selectedValue select c).ToList();
                }
                return Obj_Teacher_Detail
;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateTeacher(Teacher Obj_Teacher_Update)
        {
            try
            {
                using (EducationalInstituteEntities db = new EducationalInstituteEntities())
                {
                    //Lambda expression

                    Teacher c = db.Teachers.SingleOrDefault(x => x.ID == Obj_Teacher_Update.ID);
                    c.Name = Obj_Teacher_Update.Name;
                    c.FatherName = Obj_Teacher_Update.FatherName;
                    c.Address = Obj_Teacher_Update.Address;
                    c.Email = Obj_Teacher_Update.Email;
                    c.Mobile = Obj_Teacher_Update.Mobile;
                    db.SaveChanges();
                    return Obj_Teacher_Update.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteTeacher(string Obj_Teacher_Delete)
        {
            try
            {
                using (EducationalInstituteEntities db = new EducationalInstituteEntities())
                {
                    //Lambda expression
                    Teacher c = db.Teachers.SingleOrDefault(x => x.ID.ToString().Trim() == Obj_Teacher_Delete.Trim());
                    if (c != null)
                    {
                        db.Teachers.Remove(c);
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
