using Software2.Repositories.Implementation;
using Software2.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        private static CalendarEntities calendarEntities;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            var userRepository = new UserRepository(calendarEntities);
            var userService = new UserService(userRepository);
            Application.Run(new FormWrapper(calendarEntities, userService));
        }



        static void Bootstrap()
        {
            calendarEntities = new CalendarEntities();
            if(calendarEntities.users == null || calendarEntities.users.Count() == 0)
            {
                var user = new user();
                user.active = 1;
                user.createBy = "Devyn Coyer";
                user.createDate = DateTime.Now;
                user.lastUpdate = DateTime.Now;
                user.lastUpdatedBy = "Devyn Coyer";
                user.userId = 1;
                user.userName = "test";
                user.password = "test";

                calendarEntities.users.Add(user);
                calendarEntities.SaveChanges();
            }
        }
    }
}
