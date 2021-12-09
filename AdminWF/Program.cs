using BLL;
using DAL;
using System;
using System.Configuration;
using System.Windows.Forms;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace AdminWF
{
    static class Program
    {
        public static IUnityContainer container;
        private static string conn;

        [STAThread]
        static void Main()
        {
            conn = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            ConfigureUnity();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (LoginForm loginForm = container.Resolve<LoginForm>())
            {
                var temp = loginForm.ShowDialog();
                if (temp== DialogResult.OK)
                {
                    Application.Run(container.Resolve<StartPage>());
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private static void ConfigureUnity()
        {
            container = new UnityContainer();
            container.RegisterInstance<string>("conn", conn);
            container.RegisterType<IPersonDAL, PersonDAL>(new InjectionConstructor(new ResolvedParameter("conn")))
                    .RegisterType<IPersonManager, PersonManager>()
                    .RegisterType<IAuthManager,AuthManager>();
        }
    }
}
