using EducationalInstituteForComputer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationalInstituteForComputer.Bussiness
{
    public class Login_Business
    {
        EducationalInstituteEntities db = new EducationalInstituteEntities();

        public bool LoginUser(UserVM vmModel)//login method
        {
            bool isLogin = false;
            try
            {
                var record = (from a in db.Logins
                              where a.UserName == vmModel.UserName && a.Password == vmModel.Password
                              select a).Count() > 0 ? true : false;
                if (record)
                {
                    isLogin = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isLogin;
        }
    }
}