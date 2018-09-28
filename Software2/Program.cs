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
            container.RegisterInitializer<CustomerRepository>(repoToInitialize =>
            {
                repoToInitialize._db = calendarEntities;
            });
            container.RegisterInitializer<AddressRepository>(repoToInitialize =>
            {
                repoToInitialize._db = calendarEntities;
            });
            container.RegisterInitializer<CityRepository>(repoToInitialize =>
            {
                repoToInitialize._db = calendarEntities;
            });

            container.Register<IUserRepository, UserRepository>();
            container.Register<ICustomerRepository, CustomerRepository>();
            container.Register<IAddressRepository, AddressRepository>();
            container.Register<ICityRepository, CityRepository>();
            container.Register<ICountryRepository, CountryRepository>();
            container.Register<AuthRepository>(Lifestyle.Singleton);
            container.Register<IFormManager, FormManager>();


            container.Register<UserService>();
            container.Register<CustomerService>();
            container.Register<AddressService>();
            container.Register<CityService>();
            container.Register<CountryService>();

            if (calendarEntities.users == null || calendarEntities.users.Count() == 0)
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
            }
            if(calendarEntities.customers == null || calendarEntities.customers.Count() == 0)
            {
                var customer = new customer()
                {
                    active = true,
                    createDate = DateTime.Now,
                    lastUpdate = DateTime.Now,
                    createdBy = "Devyn Coyer",
                    lastUpdateBy = "Devyn Coyer",
                    customerName = "Bob Smith",
                    customerId = 1,
                    addressId = 1
                };

                calendarEntities.customers.Add(customer);
            }

            if(calendarEntities.cities == null || calendarEntities.cities.Count() == 0)
            {
                calendarEntities.cities.Add(new city()
                {
                    cityId = 1,
                    countryId = 1,
                    city1 = "Lancaster",
                    createDate = DateTime.Now,
                    createdBy = "Devyn Coyer",
                    lastUpdate = DateTime.Now,
                    lastUpdateBy = "Devyn Coyer"
                });
            }

            if(calendarEntities.countries == null || calendarEntities.countries.Count() == 0)
            {
                calendarEntities.countries.Add(new country()
                {
                    countryId =1,
                    country1 = "USA",
                    createDate = DateTime.Now,
                    createdBy = "Devyn Coyer",
                    lastUpdate = DateTime.Now,
                    lastUpdateBy = "Devyn Coyer"
                });
            }

            if(calendarEntities.addresses == null || calendarEntities.addresses.Count() == 0)
            {
                calendarEntities.addresses.Add(new address()
                {
                    cityId = 1,
                    address1 = "123 My Street",
                    address2 = "",
                    addressId = 1,
                    createDate = DateTime.Now,
                    lastUpdate = DateTime.Now,
                    lastUpdateBy = "Devyn Coyer",
                    createdBy = "Devyn  Coyer",
                    postalCode = "12345",
                    phone = "123-456-7890"
                });
            }

            calendarEntities.SaveChanges();
        }
    }
}
