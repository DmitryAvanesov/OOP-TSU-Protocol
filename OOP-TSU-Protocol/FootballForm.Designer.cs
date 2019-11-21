namespace OOP_TSU_Protocol
{
    partial class FootballForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MinuteInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.EventTypeLabel = new System.Windows.Forms.Label();
            this.EventTypeInput = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DateLabel = new System.Windows.Forms.Label();
            this.DateInput = new System.Windows.Forms.DateTimePicker();
            this.HomeTeamLabel = new System.Windows.Forms.Label();
            this.GuestTeamLabel = new System.Windows.Forms.Label();
            this.HomeTeamInput = new System.Windows.Forms.ComboBox();
            this.GuestTeamInput = new System.Windows.Forms.ComboBox();
            this.PlayerInput = new System.Windows.Forms.ComboBox();
            this.PlayerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MinuteInput)).BeginInit();
            this.SuspendLayout();
            // 
            // MinuteInput
            // 
            this.MinuteInput.Enabled = false;
            this.MinuteInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinuteInput.Location = new System.Drawing.Point(20, 313);
            this.MinuteInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinuteInput.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.MinuteInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinuteInput.Name = "MinuteInput";
            this.MinuteInput.Size = new System.Drawing.Size(131, 38);
            this.MinuteInput.TabIndex = 0;
            this.MinuteInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Minute";
            // 
            // EventTypeLabel
            // 
            this.EventTypeLabel.AutoSize = true;
            this.EventTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EventTypeLabel.Location = new System.Drawing.Point(199, 263);
            this.EventTypeLabel.Name = "EventTypeLabel";
            this.EventTypeLabel.Size = new System.Drawing.Size(207, 46);
            this.EventTypeLabel.TabIndex = 2;
            this.EventTypeLabel.Text = "Event type";
            // 
            // EventTypeInput
            // 
            this.EventTypeInput.Enabled = false;
            this.EventTypeInput.FormattingEnabled = true;
            this.EventTypeInput.Location = new System.Drawing.Point(207, 325);
            this.EventTypeInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EventTypeInput.MaxDropDownItems = 100;
            this.EventTypeInput.Name = "EventTypeInput";
            this.EventTypeInput.Size = new System.Drawing.Size(199, 24);
            this.EventTypeInput.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(781, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 853);
            this.panel1.TabIndex = 4;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateLabel.Location = new System.Drawing.Point(15, 137);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(104, 46);
            this.DateLabel.TabIndex = 5;
            this.DateLabel.Text = "Date";
            // 
            // DateInput
            // 
            this.DateInput.Enabled = false;
            this.DateInput.Location = new System.Drawing.Point(23, 187);
            this.DateInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DateInput.Name = "DateInput";
            this.DateInput.Size = new System.Drawing.Size(183, 22);
            this.DateInput.TabIndex = 6;
            // 
            // HomeTeamLabel
            // 
            this.HomeTeamLabel.AutoSize = true;
            this.HomeTeamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HomeTeamLabel.Location = new System.Drawing.Point(12, 9);
            this.HomeTeamLabel.Name = "HomeTeamLabel";
            this.HomeTeamLabel.Size = new System.Drawing.Size(226, 46);
            this.HomeTeamLabel.TabIndex = 7;
            this.HomeTeamLabel.Text = "Home team";
            // 
            // GuestTeamLabel
            // 
            this.GuestTeamLabel.AutoSize = true;
            this.GuestTeamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GuestTeamLabel.Location = new System.Drawing.Point(244, 9);
            this.GuestTeamLabel.Name = "GuestTeamLabel";
            this.GuestTeamLabel.Size = new System.Drawing.Size(225, 46);
            this.GuestTeamLabel.TabIndex = 8;
            this.GuestTeamLabel.Text = "Guest team";
            // 
            // HomeTeamInput
            // 
            this.HomeTeamInput.FormattingEnabled = true;
            this.HomeTeamInput.Location = new System.Drawing.Point(20, 59);
            this.HomeTeamInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HomeTeamInput.Name = "HomeTeamInput";
            this.HomeTeamInput.Size = new System.Drawing.Size(217, 24);
            this.HomeTeamInput.TabIndex = 9;
            this.HomeTeamInput.SelectedIndexChanged += new System.EventHandler(this.HomeTeamInput_SelectedIndexChanged);
            // 
            // GuestTeamInput
            // 
            this.GuestTeamInput.FormattingEnabled = true;
            this.GuestTeamInput.Location = new System.Drawing.Point(252, 59);
            this.GuestTeamInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GuestTeamInput.Name = "GuestTeamInput";
            this.GuestTeamInput.Size = new System.Drawing.Size(217, 24);
            this.GuestTeamInput.TabIndex = 10;
            this.GuestTeamInput.SelectedIndexChanged += new System.EventHandler(this.GuestTeamInput_SelectedIndexChanged);
            // 
            // PlayerInput
            // 
            this.PlayerInput.Enabled = false;
            this.PlayerInput.FormattingEnabled = true;
            this.PlayerInput.Location = new System.Drawing.Point(20, 459);
            this.PlayerInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PlayerInput.Name = "PlayerInput";
            this.PlayerInput.Size = new System.Drawing.Size(199, 24);
            this.PlayerInput.TabIndex = 12;
            // 
            // PlayerLabel
            // 
            this.PlayerLabel.AutoSize = true;
            this.PlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayerLabel.Location = new System.Drawing.Point(12, 398);
            this.PlayerLabel.Name = "PlayerLabel";
            this.PlayerLabel.Size = new System.Drawing.Size(133, 46);
            this.PlayerLabel.TabIndex = 11;
            this.PlayerLabel.Text = "Player";
            // 
            // FootballForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1581, 853);
            this.Controls.Add(this.PlayerInput);
            this.Controls.Add(this.PlayerLabel);
            this.Controls.Add(this.GuestTeamInput);
            this.Controls.Add(this.HomeTeamInput);
            this.Controls.Add(this.GuestTeamLabel);
            this.Controls.Add(this.HomeTeamLabel);
            this.Controls.Add(this.DateInput);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.EventTypeInput);
            this.Controls.Add(this.EventTypeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MinuteInput);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FootballForm";
            this.Text = "Football";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.MinuteInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown MinuteInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label EventTypeLabel;
        private System.Windows.Forms.ComboBox EventTypeInput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.DateTimePicker DateInput;
        private System.Windows.Forms.Label HomeTeamLabel;
        private System.Windows.Forms.Label GuestTeamLabel;
        private System.Windows.Forms.ComboBox HomeTeamInput;
        private System.Windows.Forms.ComboBox GuestTeamInput;
        private System.Windows.Forms.ComboBox PlayerInput;
        private System.Windows.Forms.Label PlayerLabel;
    }
}