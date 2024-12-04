using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarService
{
    public partial class Form1 : Form
    {
        public event Action UpdateButtonClicked;

        public Form1()
        {
            InitializeComponent();
            buttonAction.Click += ClickButton1;
        }

        internal string GroupBox1Text { get; private set; }

        internal void ClickButton1(object sender, EventArgs e)
        {
            buttonAction.Text = "Repair";
            UpdateButtonClicked?.Invoke();
        }

        internal async Task ReceiveCarNumber(int number)
        {
            await Task.Run(() =>
            {
                GroupBox1Text = "Car " + number;
                UpdateUI(() => carBox.Text = GroupBox1Text);
            });
        }

        internal async Task ShowCar(List<SparePart> receivedCar)
        {
            await Task.Run(() =>
            {
                UpdateUI(() =>
                {
                    carBox.Controls.Clear();

                    int positionY = 20;
                    int positionX = 10;
                    int changePosition = 30;
                    carBox.Text = GroupBox1Text;

                    if (receivedCar != null)
                    {
                        foreach (SparePart sparePart in receivedCar)
                        {
                            Label label = new Label
                            {
                                ForeColor = sparePart.IsIntact ? Color.DarkGreen : Color.DarkRed,
                                Location = new Point(positionX, positionY),
                                Text = sparePart.Name
                            };
                            positionY += changePosition;
                            carBox.Controls.Add(label);
                        }
                    }
                });
            });
        }

        internal async Task ShowMessage(string message)
        {
            await Task.Run(() =>
            {
                UpdateUI(() =>
                {
                    messageBox.Controls.Clear();

                    Label label = new Label
                    {
                        Location = new Point(10, 20),
                        AutoSize = true,
                        Text = message
                    };
                    messageBox.Controls.Add(label);
                });
            });
        }

        internal async Task ShowWallet(string message)
        {
            await Task.Run(() =>
            {
                UpdateUI(() =>
                {
                    walletBox.Controls.Clear();

                    Label label = new Label
                    {
                        Location = new Point(10, 20),
                        AutoSize = true,
                        Text = message
                    };
                    walletBox.Controls.Add(label);
                });
            });
        }

        private void UpdateUI(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
