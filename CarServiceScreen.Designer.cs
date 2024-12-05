using System.Windows.Forms;

namespace CarService
{
    partial class CarServiceScreen
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this._buttonAction = new System.Windows.Forms.Button();
            this._carBox = new System.Windows.Forms.GroupBox();
            this._messageBox = new System.Windows.Forms.GroupBox();
            this._walletBox = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();

            this._buttonAction.Location = new System.Drawing.Point(433, 362);
            this._buttonAction.Name = "buttonAction";
            this._buttonAction.Size = new System.Drawing.Size(150, 42);
            this._buttonAction.TabIndex = 0;
            this._buttonAction.Text = "Start";
            this._buttonAction.UseVisualStyleBackColor = true;

            this._carBox.Location = new System.Drawing.Point(12, 12);
            this._carBox.Name = "carBox";
            this._carBox.Size = new System.Drawing.Size(370, 404);
            this._carBox.TabIndex = 1;
            this._carBox.TabStop = false;
            this._carBox.Text = "Car";

            this._messageBox.Location = new System.Drawing.Point(12, 422);
            this._messageBox.Name = "messageBox";
            this._messageBox.Size = new System.Drawing.Size(647, 179);
            this._messageBox.TabIndex = 2;
            this._messageBox.TabStop = false;
            this._messageBox.Text = "Message";

            this._walletBox.Location = new System.Drawing.Point(388, 12);
            this._walletBox.Name = "walletBox";
            this._walletBox.Size = new System.Drawing.Size(271, 137);
            this._walletBox.TabIndex = 3;
            this._walletBox.TabStop = false;
            this._walletBox.Text = "Wallet";

            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 613);
            this.Controls.Add(this._walletBox);
            this.Controls.Add(this._messageBox);
            this.Controls.Add(this._carBox);
            this.Controls.Add(this._buttonAction);
            this.Name = "CarServiceScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Service";
            this.ResumeLayout(false);

        }

        #endregion

        private Button _buttonAction;
        private GroupBox _carBox;
        private GroupBox _messageBox;
        private GroupBox _walletBox;
    }
}

