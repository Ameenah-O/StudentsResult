using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsResult
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string ClassFilePath;
        string ResultFilePath;
        List<string> Classes;
        string SelectedClass;
        Logic log = new Logic();
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Excel Files|*.xlsx";
            openFileDialog1.Title = "Select an Excel File";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ClassFilePath = openFileDialog1.FileName;
                Classes = log.ClassWorksheet(ClassFilePath);
                ClassFile.Text = ClassFilePath;
                ClassDropDown.Visible = true;
                ClassDropDown.Items.AddRange(Classes.ToArray());
            }

            // log.GetStudents();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        private void ClassDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedClass = ClassDropDown.SelectedItem.ToString();
            if (log.ValidateClass(SelectedClass))
            {
                //validate for missing data
                ClassNotValid.Visible = false;
                log.GetStudents();
                SelectResults.Enabled = true;
            }
            else ClassNotValid.Visible = true;
        }

        private void SelectResults_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter = "Excel Files|*.xlsx";
            openFileDialog2.Title = "Select an Excel File";

            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ResultFilePath = openFileDialog2.FileName;
                ResultFile.Text = ResultFilePath;
                //validate result admission number column and names
                //validate for missing data
                //generate students results
                log.studentSubjects(ResultFilePath);
                //generate pdf
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ClassNotValid_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            log.generate(@"C:\Users\Aminat\Documents\Ameenah\Result.pdf");
        }
    }
}
