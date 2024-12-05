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

            CarServiceScreen form = new CarServiceScreen();
            CarService carService = new CarService(form);

            Task.Run(async () => await carService.WorkAsync());

            Application.Run(form);
        }
    }
}
