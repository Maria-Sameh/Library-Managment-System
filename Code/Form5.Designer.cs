
namespace Library
{
    partial class Form5
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.DeleteBookbutton = new System.Windows.Forms.Button();
            this.EditBookbutton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BookGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BookGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Tan;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 119);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(83, 623);
            this.panel3.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button3.BackColor = System.Drawing.Color.NavajoWhite;
            this.button3.Location = new System.Drawing.Point(808, 676);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(193, 52);
            this.button3.TabIndex = 6;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // DeleteBookbutton
            // 
            this.DeleteBookbutton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DeleteBookbutton.BackColor = System.Drawing.Color.NavajoWhite;
            this.DeleteBookbutton.Location = new System.Drawing.Point(505, 676);
            this.DeleteBookbutton.Name = "DeleteBookbutton";
            this.DeleteBookbutton.Size = new System.Drawing.Size(193, 52);
            this.DeleteBookbutton.TabIndex = 5;
            this.DeleteBookbutton.Text = "Delete";
            this.DeleteBookbutton.UseVisualStyleBackColor = false;
            this.DeleteBookbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // EditBookbutton
            // 
            this.EditBookbutton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.EditBookbutton.BackColor = System.Drawing.Color.NavajoWhite;
            this.EditBookbutton.Location = new System.Drawing.Point(210, 676);
            this.EditBookbutton.Name = "EditBookbutton";
            this.EditBookbutton.Size = new System.Drawing.Size(193, 52);
            this.EditBookbutton.TabIndex = 4;
            this.EditBookbutton.Text = "Edit";
            this.EditBookbutton.UseVisualStyleBackColor = false;
            this.EditBookbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Tan;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(493, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(260, 62);
            this.label7.TabIndex = 0;
            this.label7.Text = "View Book";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::Library.Properties.Resources._196c10f484874b30a2cad32166b992231;
            this.pictureBox1.Location = new System.Drawing.Point(257, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1218, 119);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1146, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(72, 623);
            this.panel2.TabIndex = 3;
            // 
            // BookGridView
            // 
            this.BookGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BookGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BookGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BookGridView.Location = new System.Drawing.Point(81, 119);
            this.BookGridView.Name = "BookGridView";
            this.BookGridView.RowHeadersWidth = 51;
            this.BookGridView.RowTemplate.Height = 29;
            this.BookGridView.Size = new System.Drawing.Size(1067, 541);
            this.BookGridView.TabIndex = 0;
            this.BookGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BookGridView_CellClick);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1218, 742);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.DeleteBookbutton);
            this.Controls.Add(this.EditBookbutton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BookGridView);
            this.MaximumSize = new System.Drawing.Size(1236, 789);
            this.MinimumSize = new System.Drawing.Size(1236, 789);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BookGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button DeleteBookbutton;
        private System.Windows.Forms.Button EditBookbutton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView BookGridView;
    }
}