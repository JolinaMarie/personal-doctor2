using Microsoft.EntityFrameworkCore;
using Backend_Personal_Doctor.Models.Users.Logic.Interface;
using Backend_Personal_Doctor.Models.Users.Logic;
using Backend_Personal_Doctor.Models.Users.Persistance.Interface;
using Backend_Personal_Doctor.Models.Users.Persistance;
using Backend_Personal_Doctor;
using Backend_Personal_Doctor.Contexts;
using Backend_Personal_Doctor.Models.Sessions.Persistance.Interface;
using Backend_Personal_Doctor.Models.Sessions.Persistance;
using Backend_Personal_Doctor.Models.Naehrwerte.Logic.Interface;
using Backend_Personal_Doctor.Models.Naehrwerte.Logic;
using Backend_Personal_Doctor.Models.Naehrwerte.Persistance.Interface;
using Backend_Personal_Doctor.Models.Naehrwerte.Persistance;

namespace personal_doctor
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddDbContext<PersonalDoctorContext>(options => options.UseMySql("Server=fs213.sepe21.de;Port=3306;Database=Projektseminar;User=root;Password=geheim;",
                                                                                        new MySqlServerVersion(new Version(8, 0, 26))));


            //Dependency Injection
            //Users
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IUserRepository, EfUsersRepository>();

            //Sessions
            services.AddScoped<ISessionContext, SessionContext>();
            services.AddScoped<ISessionsRepository, EfSessionsRepository>();

            //Naehrtwerte
            services.AddScoped<INaehrwertLogic, NaehrwertLogic>();
            services.AddScoped<INaehrwerteRepository, EfNaehrwerteRepository>();
        }
    }
}
