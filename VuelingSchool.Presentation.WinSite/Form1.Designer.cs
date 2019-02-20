namespace VuelingSchool.Presentation.WinSite
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
            this.btAdd = new System.Windows.Forms.Button();
            this.cbProvinces = new System.Windows.Forms.ComboBox();
            this.btUpdate = new System.Windows.Forms.Button();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.cbFileType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(24, 386);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(317, 52);
            this.btAdd.TabIndex = 0;
            this.btAdd.Text = "ADD";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // cbProvinces
            // 
            this.cbProvinces.FormattingEnabled = true;
            this.cbProvinces.Location = new System.Drawing.Point(316, 13);
            this.cbProvinces.Name = "cbProvinces";
            this.cbProvinces.Size = new System.Drawing.Size(432, 24);
            this.cbProvinces.TabIndex = 1;
            // 
            // btUpdate
            // 
            this.btUpdate.Location = new System.Drawing.Point(431, 386);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(317, 52);
            this.btUpdate.TabIndex = 2;
            this.btUpdate.Text = "UPDATE";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // dgvStudents
            // 
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(26, 42);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowTemplate.Height = 24;
            this.dgvStudents.Size = new System.Drawing.Size(722, 338);
            this.dgvStudents.TabIndex = 3;
            // 
            // cbFileType
            // 
            this.cbFileType.FormattingEnabled = true;
            this.cbFileType.Location = new System.Drawing.Point(26, 13);
            this.cbFileType.Name = "cbFileType";
            this.cbFileType.Size = new System.Drawing.Size(284, 24);
            this.cbFileType.TabIndex = 4;
            this.cbFileType.SelectedIndexChanged += new System.EventHandler(this.cbFileType_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 450);
            this.Controls.Add(this.cbFileType);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.cbProvinces);
            this.Controls.Add(this.btAdd);
            this.Name = "Form1";
            this.Text = "Students";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.ComboBox cbProvinces;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.ComboBox cbFileType;
    }
}

