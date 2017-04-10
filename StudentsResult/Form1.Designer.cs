namespace StudentsResult
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
            System.Windows.Forms.Button StudentsClass;
            //System.Windows.Forms.Button SelectResults;
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ClassFile = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ResultFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SelectResults = new System.Windows.Forms.Button();
            this.ClassDropDown = new System.Windows.Forms.ComboBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.OUPUT = new System.Windows.Forms.Label();
            this.ClassNotValid = new System.Windows.Forms.Label();
            StudentsClass = new System.Windows.Forms.Button();
            //SelectResults = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StudentsClass
            // 
            StudentsClass.Location = new System.Drawing.Point(33, 43);
            StudentsClass.Name = "StudentsClass";
            StudentsClass.Size = new System.Drawing.Size(75, 25);
            StudentsClass.TabIndex = 0;
            StudentsClass.Text = "Select File";
            StudentsClass.UseVisualStyleBackColor = true;
            StudentsClass.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // ClassFile
            // 
            this.ClassFile.Enabled = false;
            this.ClassFile.Location = new System.Drawing.Point(123, 46);
            this.ClassFile.Name = "ClassFile";
            this.ClassFile.ReadOnly = true;
            this.ClassFile.Size = new System.Drawing.Size(149, 20);
            this.ClassFile.TabIndex = 1;
            // 
            // ResultFile
            // 
            this.ResultFile.Enabled = false;
            this.ResultFile.Location = new System.Drawing.Point(123, 193);
            this.ResultFile.Name = "ResultFile";
            this.ResultFile.ReadOnly = true;
            this.ResultFile.Size = new System.Drawing.Size(149, 20);
            this.ResultFile.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "STUDENTS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "CLASS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "RESULT";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(165, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Generate Results";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SelectResults
            // 
            this.SelectResults.Enabled = false;
            this.SelectResults.Location = new System.Drawing.Point(33, 190);
            this.SelectResults.Name = "SelectResults";
            this.SelectResults.Size = new System.Drawing.Size(75, 25);
            this.SelectResults.TabIndex = 7;
            this.SelectResults.Text = "Select File";
            this.SelectResults.UseVisualStyleBackColor = true;
            this.SelectResults.Click += new System.EventHandler(this.SelectResults_Click);
            // 
            // ClassDropDown
            // 
            this.ClassDropDown.FormattingEnabled = true;
            this.ClassDropDown.Location = new System.Drawing.Point(123, 100);
            this.ClassDropDown.Name = "ClassDropDown";
            this.ClassDropDown.Size = new System.Drawing.Size(149, 21);
            this.ClassDropDown.TabIndex = 9;
            this.ClassDropDown.Visible = false;
            this.ClassDropDown.SelectedIndexChanged += new System.EventHandler(this.ClassDropDown_SelectedIndexChanged);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // OUPUT
            // 
            this.OUPUT.AutoSize = true;
            this.OUPUT.Location = new System.Drawing.Point(33, 268);
            this.OUPUT.Name = "OUPUT";
            this.OUPUT.Size = new System.Drawing.Size(35, 13);
            this.OUPUT.TabIndex = 10;
            this.OUPUT.Text = "label4";
            // 
            // ClassNotValid
            // 
            this.ClassNotValid.AutoSize = true;
            this.ClassNotValid.ForeColor = System.Drawing.Color.Red;
            this.ClassNotValid.Location = new System.Drawing.Point(30, 124);
            this.ClassNotValid.Name = "ClassNotValid";
            this.ClassNotValid.Size = new System.Drawing.Size(284, 13);
            this.ClassNotValid.TabIndex = 11;
            this.ClassNotValid.Text = "*Names\" or \"Admission Number\" not present in class sheet";
            this.ClassNotValid.Visible = false;
            this.ClassNotValid.Click += new System.EventHandler(this.ClassNotValid_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 293);
            this.Controls.Add(this.ClassNotValid);
            this.Controls.Add(this.OUPUT);
            this.Controls.Add(this.ClassDropDown);
            this.Controls.Add(this.button2);
            this.Controls.Add(SelectResults);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResultFile);
            this.Controls.Add(this.ClassFile);
            this.Controls.Add(StudentsClass);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox ClassFile;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox ResultFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3; 
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button SelectResults;
        private System.Windows.Forms.ComboBox ClassDropDown;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label OUPUT;
        private System.Windows.Forms.Label ClassNotValid;
    }
}

