using SimpleInjector;
using Software2.Repositories.Implementation;
using Software2.Repositories.Interfaces;
using Software2.Services;
using Software2.Views.manager;
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
        private static Container container;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            Application.Run(container.GetInstance<HomeForm>());
        }



        static void Bootstrap()
        {
            container = new Container();
            calendarEntities = new CalendarEntities();
            container.RegisterInitializer<UserRepository>(repoToInitialize =>
            {
                repoToInitialize._db = calendarEntities;
            });

            container.Register<CustomerService>();
            container.Register<IUserRepository, UserRepository>();
            container.Register<UserService>();
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
