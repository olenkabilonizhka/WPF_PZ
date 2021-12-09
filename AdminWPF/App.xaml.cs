using BLL;
using DAL;
using System.Configuration;
using System.Windows;
using Unity;
using Unity.Injection;

namespace AdminWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnityContainer container;
        static string conn;

        protected override void OnStartup(StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            base.OnStartup(e);
            conn = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            ConfigureUnity();

            LoginPage loginPage = container.Resolve<LoginPage>();
            loginPage.Show();
        }

        private static void ConfigureUnity()
        {
            container = new UnityContainer();
            container.RegisterInstance<string>("conn", conn);
            container.RegisterType<IPersonDAL, PersonDAL>(new InjectionConstructor(new ResolvedParameter("conn")))
                    .RegisterType<IPersonManager, PersonManager>()
                    .RegisterType<IAuthManager, AuthManager>();
        }
    }
}
