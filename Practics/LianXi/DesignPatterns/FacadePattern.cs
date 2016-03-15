using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
   internal class FacadePattern:PatternBase
    {
       public override void Main()
       {
           RegistrationFacade registrationFacade = new RegistrationFacade();
           registrationFacade.RegisterCourse("小李", "设计模式");
       }

        #region 外观模式
       /// <summary>
       /// 注册课程外观累
       /// </summary>
       public class RegistrationFacade
       {
           private CheckSystem  m_CheckSystem;
           private NotifySystem m_NotifySystem;

           public RegistrationFacade()
           {
               m_CheckSystem  = new CheckSystem();
               m_NotifySystem = new NotifySystem();
           }

           /// <summary>
           /// 注册课程
           /// </summary>
           /// <param name="szRegister"></param>
           /// <param name="szCourseName"></param>
           /// <returns></returns>
           public bool RegisterCourse(string szRegister,string szCourseName)
           {
               if (m_CheckSystem.CheckIfCanRegister(szCourseName))
               {
                   if (m_NotifySystem.NotifyStudent(szRegister))
                   {
                       Console.WriteLine("注册成功。");
                       return true;
                   }
                   else
                   {
                       return false;
                   }
               }
               else
               {
                   return false;
               }
           }
       }

        /// <summary>
        /// 检查系统
        /// </summary>
        public class CheckSystem
        {
            /// <summary>
            /// 检查是否可以注册课程
            /// </summary>
            public bool CheckIfCanRegister(string szCourseName)
            {
                Console.WriteLine("正在检查《{0}》是否人数已满。。。", szCourseName);
                return true;
            }
        }

        /// <summary>
        /// 通知系统
        /// </summary>
        public class NotifySystem
        {
            /// <summary>
            /// 通知学生
            /// </summary>
            public bool NotifyStudent(string szStudentName)
            {
                Console.WriteLine("正在向{0}发送通知。。。", szStudentName);
                return true;
            }
        }
        #endregion
    }
}
