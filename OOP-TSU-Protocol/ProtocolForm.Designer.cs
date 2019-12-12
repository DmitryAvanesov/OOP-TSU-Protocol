namespace OOP_TSU_Protocol
{
    partial class ProtocolForm<T1, T2>
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
            this.EventsPanel = new System.Windows.Forms.Panel();
            this.GameLabel = new System.Windows.Forms.Label();
            this.GameInput = new System.Windows.Forms.ComboBox();
            this.PlayerInput = new System.Windows.Forms.ComboBox();
            this.PlayerLabel = new System.Windows.Forms.Label();
            this.AddEventButton = new System.Windows.Forms.Button();
            this.SaveProtocolButton = new System.Windows.Forms.Button();
            this.AssistantInput = new System.Windows.Forms.ComboBox();
            this.AssistantLabel = new System.Windows.Forms.Label();
            this.ViewProtocolLabel = new System.Windows.Forms.Label();
            this.NewProtocolLabel = new System.Windows.Forms.Label();
            this.ProtocolInput = new System.Windows.Forms.ComboBox();
            this.ViewStatsLabel = new System.Windows.Forms.Label();
            this.StatsInput = new System.Windows.Forms.ComboBox();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MinuteInput)).BeginInit();
            this.SuspendLayout();
            // 
            // MinuteInput
            // 
            this.MinuteInput.Enabled = false;
            this.MinuteInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinuteInput.Location = new System.Drawing.Point(21, 419);
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
            this.label1.Location = new System.Drawing.Point(13, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Minute";
            // 
            // EventTypeLabel
            // 
            this.EventTypeLabel.AutoSize = true;
            this.EventTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EventTypeLabel.Location = new System.Drawing.Point(200, 369);
            this.EventTypeLabel.Name = "EventTypeLabel";
            this.EventTypeLabel.Size = new System.Drawing.Size(207, 46);
            this.EventTypeLabel.TabIndex = 2;
            this.EventTypeLabel.Text = "Event type";
            // 
            // EventTypeInput
            // 
            this.EventTypeInput.Enabled = false;
            this.EventTypeInput.FormattingEnabled = true;
            this.EventTypeInput.Location = new System.Drawing.Point(208, 431);
            this.EventTypeInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EventTypeInput.MaxDropDownItems = 100;
            this.EventTypeInput.Name = "EventTypeInput";
            this.EventTypeInput.Size = new System.Drawing.Size(199, 24);
            this.EventTypeInput.TabIndex = 3;
            this.EventTypeInput.SelectedIndexChanged += new System.EventHandler(this.EventTypeInput_SelectedIndexChanged);
            // 
            // EventsPanel
            // 
            this.EventsPanel.AllowDrop = true;
            this.EventsPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.EventsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.EventsPanel.Location = new System.Drawing.Point(682, 0);
            this.EventsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EventsPanel.Name = "EventsPanel";
            this.EventsPanel.Size = new System.Drawing.Size(900, 853);
            this.EventsPanel.TabIndex = 4;
            // 
            // GameLabel
            // 
            this.GameLabel.AutoSize = true;
            this.GameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GameLabel.Location = new System.Drawing.Point(13, 264);
            this.GameLabel.Name = "GameLabel";
            this.GameLabel.Size = new System.Drawing.Size(128, 46);
            this.GameLabel.TabIndex = 8;
            this.GameLabel.Text = "Game";
            // 
            // GameInput
            // 
            this.GameInput.FormattingEnabled = true;
            this.GameInput.Location = new System.Drawing.Point(21, 314);
            this.GameInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GameInput.Name = "GameInput";
            this.GameInput.Size = new System.Drawing.Size(217, 24);
            this.GameInput.TabIndex = 10;
            // 
            // PlayerInput
            // 
            this.PlayerInput.Enabled = false;
            this.PlayerInput.FormattingEnabled = true;
            this.PlayerInput.Location = new System.Drawing.Point(21, 565);
            this.PlayerInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PlayerInput.MaxDropDownItems = 36;
            this.PlayerInput.Name = "PlayerInput";
            this.PlayerInput.Size = new System.Drawing.Size(199, 24);
            this.PlayerInput.TabIndex = 12;
            // 
            // PlayerLabel
            // 
            this.PlayerLabel.AutoSize = true;
            this.PlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayerLabel.Location = new System.Drawing.Point(13, 504);
            this.PlayerLabel.Name = "PlayerLabel";
            this.PlayerLabel.Size = new System.Drawing.Size(133, 46);
            this.PlayerLabel.TabIndex = 11;
            this.PlayerLabel.Text = "Player";
            // 
            // AddEventButton
            // 
            this.AddEventButton.Enabled = false;
            this.AddEventButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddEventButton.Location = new System.Drawing.Point(13, 649);
            this.AddEventButton.Name = "AddEventButton";
            this.AddEventButton.Size = new System.Drawing.Size(139, 42);
            this.AddEventButton.TabIndex = 13;
            this.AddEventButton.Text = "Add event";
            this.AddEventButton.UseVisualStyleBackColor = true;
            this.AddEventButton.Click += new System.EventHandler(this.AddEventButton_Click);
            // 
            // SaveProtocolButton
            // 
            this.SaveProtocolButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SaveProtocolButton.Enabled = false;
            this.SaveProtocolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveProtocolButton.Location = new System.Drawing.Point(12, 799);
            this.SaveProtocolButton.Name = "SaveProtocolButton";
            this.SaveProtocolButton.Size = new System.Drawing.Size(207, 42);
            this.SaveProtocolButton.TabIndex = 14;
            this.SaveProtocolButton.Text = "Save protocol";
            this.SaveProtocolButton.UseVisualStyleBackColor = false;
            this.SaveProtocolButton.Click += new System.EventHandler(this.SaveProtocolButton_Click);
            // 
            // AssistantInput
            // 
            this.AssistantInput.FormattingEnabled = true;
            this.AssistantInput.Location = new System.Drawing.Point(253, 565);
            this.AssistantInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AssistantInput.MaxDropDownItems = 36;
            this.AssistantInput.Name = "AssistantInput";
            this.AssistantInput.Size = new System.Drawing.Size(199, 24);
            this.AssistantInput.TabIndex = 16;
            this.AssistantInput.Visible = false;
            // 
            // AssistantLabel
            // 
            this.AssistantLabel.AutoSize = true;
            this.AssistantLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AssistantLabel.Location = new System.Drawing.Point(245, 504);
            this.AssistantLabel.Name = "AssistantLabel";
            this.AssistantLabel.Size = new System.Drawing.Size(182, 46);
            this.AssistantLabel.TabIndex = 15;
            this.AssistantLabel.Text = "Assistant";
            this.AssistantLabel.Visible = false;
            // 
            // ViewProtocolLabel
            // 
            this.ViewProtocolLabel.AutoSize = true;
            this.ViewProtocolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewProtocolLabel.Location = new System.Drawing.Point(12, 9);
            this.ViewProtocolLabel.Name = "ViewProtocolLabel";
            this.ViewProtocolLabel.Size = new System.Drawing.Size(293, 51);
            this.ViewProtocolLabel.TabIndex = 17;
            this.ViewProtocolLabel.Text = "View protocol:";
            // 
            // NewProtocolLabel
            // 
            this.NewProtocolLabel.AutoSize = true;
            this.NewProtocolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewProtocolLabel.Location = new System.Drawing.Point(12, 162);
            this.NewProtocolLabel.Name = "NewProtocolLabel";
            this.NewProtocolLabel.Size = new System.Drawing.Size(285, 51);
            this.NewProtocolLabel.TabIndex = 18;
            this.NewProtocolLabel.Text = "New protocol:";
            // 
            // ProtocolInput
            // 
            this.ProtocolInput.FormattingEnabled = true;
            this.ProtocolInput.Location = new System.Drawing.Point(21, 73);
            this.ProtocolInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProtocolInput.Name = "ProtocolInput";
            this.ProtocolInput.Size = new System.Drawing.Size(280, 24);
            this.ProtocolInput.TabIndex = 19;
            // 
            // ViewStatsLabel
            // 
            this.ViewStatsLabel.AutoSize = true;
            this.ViewStatsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewStatsLabel.Location = new System.Drawing.Point(315, 9);
            this.ViewStatsLabel.Name = "ViewStatsLabel";
            this.ViewStatsLabel.Size = new System.Drawing.Size(231, 51);
            this.ViewStatsLabel.TabIndex = 20;
            this.ViewStatsLabel.Text = "View stats:";
            // 
            // StatsInput
            // 
            this.StatsInput.FormattingEnabled = true;
            this.StatsInput.Location = new System.Drawing.Point(324, 73);
            this.StatsInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StatsInput.Name = "StatsInput";
            this.StatsInput.Size = new System.Drawing.Size(280, 24);
            this.StatsInput.TabIndex = 21;
            this.StatsInput.SelectedIndexChanged += new System.EventHandler(this.StatsInput_SelectedIndexChanged);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.Location = new System.Drawing.Point(225, 799);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(118, 42);
            this.BackButton.TabIndex = 22;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ProtocolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.StatsInput);
            this.Controls.Add(this.ViewStatsLabel);
            this.Controls.Add(this.ProtocolInput);
            this.Controls.Add(this.NewProtocolLabel);
            this.Controls.Add(this.ViewProtocolLabel);
            this.Controls.Add(this.AssistantInput);
            this.Controls.Add(this.AssistantLabel);
            this.Controls.Add(this.SaveProtocolButton);
            this.Controls.Add(this.AddEventButton);
            this.Controls.Add(this.PlayerInput);
            this.Controls.Add(this.PlayerLabel);
            this.Controls.Add(this.GameInput);
            this.Controls.Add(this.GameLabel);
            this.Controls.Add(this.EventsPanel);
            this.Controls.Add(this.EventTypeInput);
            this.Controls.Add(this.EventTypeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MinuteInput);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProtocolForm";
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
        private System.Windows.Forms.Panel EventsPanel;
        private System.Windows.Forms.Label GameLabel;
        private System.Windows.Forms.ComboBox GameInput;
        private System.Windows.Forms.ComboBox PlayerInput;
        private System.Windows.Forms.Label PlayerLabel;
        private System.Windows.Forms.Button AddEventButton;
        private System.Windows.Forms.Button SaveProtocolButton;
        private System.Windows.Forms.ComboBox AssistantInput;
        private System.Windows.Forms.Label AssistantLabel;
        private System.Windows.Forms.Label ViewProtocolLabel;
        private System.Windows.Forms.Label NewProtocolLabel;
        private System.Windows.Forms.ComboBox ProtocolInput;
        private System.Windows.Forms.Label ViewStatsLabel;
        private System.Windows.Forms.ComboBox StatsInput;
        private System.Windows.Forms.Button BackButton;
    }
}