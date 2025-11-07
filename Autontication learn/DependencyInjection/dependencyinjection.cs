using Autontication_learn.DBcontext;
using Autontication_learn.InputModel;
using Autontication_learn.Interface;
using Autontication_learn.Mailservices;


namespace Autontication_learn.DependencyInjection
{
    public static class dependentProvide
    {

        public static void depeatableProvide(this IServiceCollection services)
        {

            services.AddScoped<Login, LoginDbcontext>();
            services.AddTransient<Mailservicescs>();
            services.AddSingleton<CalculateDelegae>((x, y) => x + y);

        }
    }
}
