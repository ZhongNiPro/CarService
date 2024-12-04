//using System;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace CarService
//{
//    internal static class Program
//    {
//        [STAThread]
//        static void Main()
//        {
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);
//            Form1 form = new Form1();
//            CarService carService = new CarService(form);
//            Task.Run(() => carService.Work());
//            //form.UpdateButtonClicked += carService.Work;
//            Application.Run(form);
//        }
//    }
//}
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarService
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new Form1();
            var carService = new CarService(form);

            // Запуск асинхронной логики сервиса
            Task.Run(async () => await carService.WorkAsync());

            Application.Run(form);
        }
    }
}
