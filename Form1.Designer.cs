namespace CarService
{
    partial class Form1
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
            this.buttonAction = new System.Windows.Forms.Button();
            this.carBox = new System.Windows.Forms.GroupBox();
            this.messageBox = new System.Windows.Forms.GroupBox();
            this.walletBox = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // bAction
            // 
            this.buttonAction.Location = new System.Drawing.Point(433, 362);
            this.buttonAction.Name = "bAction";
            this.buttonAction.Size = new System.Drawing.Size(150, 42);
            this.buttonAction.TabIndex = 0;
            this.buttonAction.Text = "Start";
            this.buttonAction.UseVisualStyleBackColor = true;
            // 
            // carBox
            // 
            this.carBox.Location = new System.Drawing.Point(12, 12);
            this.carBox.Name = "carBox";
            this.carBox.Size = new System.Drawing.Size(370, 404);
            this.carBox.TabIndex = 1;
            this.carBox.TabStop = false;
            this.carBox.Text = "Car";
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(12, 422);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(647, 179);
            this.messageBox.TabIndex = 2;
            this.messageBox.TabStop = false;
            this.messageBox.Text = "Message";
            // 
            // walletBox
            // 
            this.walletBox.Location = new System.Drawing.Point(388, 12);
            this.walletBox.Name = "walletBox";
            this.walletBox.Size = new System.Drawing.Size(271, 137);
            this.walletBox.TabIndex = 3;
            this.walletBox.TabStop = false;
            this.walletBox.Text = "Wallet";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 613);
            this.Controls.Add(this.walletBox);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.carBox);
            this.Controls.Add(this.buttonAction);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Service";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAction;
        private System.Windows.Forms.GroupBox carBox;
        private System.Windows.Forms.GroupBox messageBox;
        private System.Windows.Forms.GroupBox walletBox;
    }
}

