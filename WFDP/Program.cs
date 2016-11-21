using System;
using System.Windows.Forms;
using Microsoft.Practices.Unity;

namespace WFDP
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Unity контейнер
            var uc = new UnityContainer();
            // Регистрация типа IConverter с реализацией HtmlConverter
            uc.RegisterType<IConverter, HtmlConverter>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Instance. Cоздание экземпляра объекта через uc.Resolve
            //Application.Run(new MainForm());
            Application.Run(uc.Resolve<MainForm>());
        }
    }
}
