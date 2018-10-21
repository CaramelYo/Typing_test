namespace Typing_test
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.start_btn = new System.Windows.Forms.Button();
            this.restart_btn = new System.Windows.Forms.Button();
            this.HP_label = new System.Windows.Forms.Label();
            this.score_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.name_textbox = new System.Windows.Forms.TextBox();
            this.name_btn = new System.Windows.Forms.Button();
            this.clear_btn = new System.Windows.Forms.Button();
            this.log_textbox = new System.Windows.Forms.TextBox();
            this.deadline_textbox = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(29, 464);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(75, 23);
            this.start_btn.TabIndex = 0;
            this.start_btn.Text = "start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // restart_btn
            // 
            this.restart_btn.Location = new System.Drawing.Point(151, 464);
            this.restart_btn.Name = "restart_btn";
            this.restart_btn.Size = new System.Drawing.Size(75, 23);
            this.restart_btn.TabIndex = 1;
            this.restart_btn.Text = "restart";
            this.restart_btn.UseVisualStyleBackColor = true;
            this.restart_btn.Click += new System.EventHandler(this.restart_btn_Click);
            // 
            // HP_label
            // 
            this.HP_label.AutoSize = true;
            this.HP_label.Location = new System.Drawing.Point(255, 464);
            this.HP_label.Name = "HP_label";
            this.HP_label.Size = new System.Drawing.Size(22, 12);
            this.HP_label.TabIndex = 2;
            this.HP_label.Text = "HP:";
            // 
            // score_label
            // 
            this.score_label.AutoSize = true;
            this.score_label.Location = new System.Drawing.Point(321, 464);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(32, 12);
            this.score_label.TabIndex = 3;
            this.score_label.Text = "score:";
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Font = new System.Drawing.Font("PMingLiU", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.name_label.Location = new System.Drawing.Point(595, 19);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(64, 19);
            this.name_label.TabIndex = 4;
            this.name_label.Text = "player: ";
            // 
            // name_textbox
            // 
            this.name_textbox.Location = new System.Drawing.Point(801, 21);
            this.name_textbox.Name = "name_textbox";
            this.name_textbox.Size = new System.Drawing.Size(100, 22);
            this.name_textbox.TabIndex = 5;
            // 
            // name_btn
            // 
            this.name_btn.Location = new System.Drawing.Point(936, 19);
            this.name_btn.Name = "name_btn";
            this.name_btn.Size = new System.Drawing.Size(75, 23);
            this.name_btn.TabIndex = 6;
            this.name_btn.Text = "modify name";
            this.name_btn.UseVisualStyleBackColor = true;
            this.name_btn.Click += new System.EventHandler(this.name_btn_Click);
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(936, 464);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(75, 23);
            this.clear_btn.TabIndex = 7;
            this.clear_btn.Text = "clear scores";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // log_textbox
            // 
            this.log_textbox.Location = new System.Drawing.Point(599, 70);
            this.log_textbox.Multiline = true;
            this.log_textbox.Name = "log_textbox";
            this.log_textbox.ReadOnly = true;
            this.log_textbox.Size = new System.Drawing.Size(412, 367);
            this.log_textbox.TabIndex = 8;
            // 
            // deadline_textbox
            // 
            this.deadline_textbox.BackColor = System.Drawing.SystemColors.WindowText;
            this.deadline_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.deadline_textbox.Enabled = false;
            this.deadline_textbox.Location = new System.Drawing.Point(4, 422);
            this.deadline_textbox.Name = "deadline_textbox";
            this.deadline_textbox.Size = new System.Drawing.Size(589, 15);
            this.deadline_textbox.TabIndex = 9;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 521);
            this.Controls.Add(this.deadline_textbox);
            this.Controls.Add(this.log_textbox);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.name_btn);
            this.Controls.Add(this.name_textbox);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.score_label);
            this.Controls.Add(this.HP_label);
            this.Controls.Add(this.restart_btn);
            this.Controls.Add(this.start_btn);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button restart_btn;
        private System.Windows.Forms.Label HP_label;
        private System.Windows.Forms.Label score_label;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.TextBox name_textbox;
        private System.Windows.Forms.Button name_btn;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.TextBox log_textbox;
        private System.Windows.Forms.TextBox deadline_textbox;
        private System.Windows.Forms.Timer timer;
    }
}

