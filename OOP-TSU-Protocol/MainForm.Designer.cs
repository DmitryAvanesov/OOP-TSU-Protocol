using System.Windows.Forms;

namespace OOP_TSU_Protocol
{
    partial class MainForm
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
            this.MainFormTitle = new System.Windows.Forms.Label();
            this.FootballButton = new System.Windows.Forms.Label();
            this.BasketballButton = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MainFormTitle
            // 
            this.MainFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainFormTitle.Location = new System.Drawing.Point(0, 0);
            this.MainFormTitle.Name = "MainFormTitle";
            this.MainFormTitle.Size = new System.Drawing.Size(1582, 500);
            this.MainFormTitle.TabIndex = 0;
            this.MainFormTitle.Text = "Easy Protocol";
            this.MainFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MainFormTitle.UseMnemonic = false;
            // 
            // FootballButton
            // 
            this.FootballButton.BackColor = System.Drawing.Color.GreenYellow;
            this.FootballButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.FootballButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FootballButton.ForeColor = System.Drawing.Color.Black;
            this.FootballButton.Location = new System.Drawing.Point(0, 500);
            this.FootballButton.Name = "FootballButton";
            this.FootballButton.Size = new System.Drawing.Size(1582, 130);
            this.FootballButton.TabIndex = 1;
            this.FootballButton.Text = "Football";
            this.FootballButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FootballButton.Click += new System.EventHandler(this.FootballButton_Click);
            // 
            // BasketballButton
            // 
            this.BasketballButton.BackColor = System.Drawing.Color.DarkOrange;
            this.BasketballButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.BasketballButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BasketballButton.ForeColor = System.Drawing.Color.Black;
            this.BasketballButton.Location = new System.Drawing.Point(0, 630);
            this.BasketballButton.Name = "BasketballButton";
            this.BasketballButton.Size = new System.Drawing.Size(1582, 130);
            this.BasketballButton.TabIndex = 2;
            this.BasketballButton.Text = "Basketball";
            this.BasketballButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.BasketballButton);
            this.Controls.Add(this.FootballButton);
            this.Controls.Add(this.MainFormTitle);
            this.Name = "MainForm";
            this.Text = "Protocol";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
        }

        #endregion

        private Label MainFormTitle;
        private Label FootballButton;
        private Label BasketballButton;
    }
}

