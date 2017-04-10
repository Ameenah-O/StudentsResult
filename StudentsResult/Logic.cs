using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace StudentsResult
{
    public class Logic
    {
        Workbook AllStudents;
        Worksheet SelectedClass;
        Application classxlApp = new Application();
        List<Student> ClassStudents;
        Workbook AllSubjects;
        Document doc = new Document();
        List<Subject> subjectsResults = new List<Subject>();
        Dictionary<string, List<StudentSubjectScore>> allStudentSubjectScore = new Dictionary<string, List<StudentSubjectScore>>();
        public void quitXlApp()
        {
            classxlApp.Quit();
            AllStudents.Close();
        }
        public void generate(string filepath)
        {
            using (var filestream= new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                PdfWriter.GetInstance(doc, filestream);
                doc.Open();
                GeneratePDFResult result = new GeneratePDFResult();
                foreach (var student in ClassStudents)
                {
                    result.WriteResultTable(student, doc, allStudentSubjectScore);
                }
                doc.Close();
            }
           
        }
        public Dictionary<string,List<StudentSubjectScore>> studentSubjects(string filepath)
        {
            
            AllSubjects = classxlApp.Workbooks.Open(filepath, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            var subjects = GetSheetNames(AllSubjects);
            foreach (var item in subjects)
            {
               subjectsResults.Add(GetSubject(AllSubjects.Sheets[item]));
            }
            foreach (var item in subjectsResults)
            {
                List<StudentSubjectScore> SSS = new List<StudentSubjectScore>();
                foreach (var admno in item.CA.Keys)
                {
                    var sss = new StudentSubjectScore();
                    sss.Subject = item;
                    sss.AdmissionNumber = admno;
                    sss.CA = item.CA[admno];
                    sss.Exam = item.Exam[admno];
                    sss.Total = sss.CA + sss.Exam;
                    SSS.Add(sss);
                }
                allStudentSubjectScore.Add(item.SubjectName, SSS);
            }
            return allStudentSubjectScore;
        }
        public void ClassData(string StudentsFilePath, string SubjectStudentsFilePath)
        {

            Application xlApp;
            Workbook SubjectWorkBook;
            Workbook ClassWorkbook;
            xlApp = new Application();
            SubjectWorkBook = xlApp.Workbooks.Open(@SubjectStudentsFilePath, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            ClassWorkbook = xlApp.Workbooks.Open(@StudentsFilePath, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            var xlWorkSheetStudents = (Worksheet)ClassWorkbook.Worksheets.get_Item(1);
            //var students = GetStudents(xlWorkSheetStudents);
            //get sheetnamesand subjects list// method in workbook out subject list
            //method foreach subject, populate student.studentsubjectscore 
            //& student.%,position in&out students


            SubjectWorkBook.Close();
            xlApp.Quit();
        }
        public List<string> ClassWorksheet(string filepath)
        {
            //Workbook ClassWorkbook;
            AllStudents = classxlApp.Workbooks.Open(filepath, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            var classes = GetSheetNames(AllStudents);
            return classes;
        }
        public List<Student> GetStudents()
        {
            var students = new List<Student>();
            
            int NameCell = new int();
            var AdmNoCell = new int();
            
            var range = SelectedClass.UsedRange;
            int rowno = range.Rows.Count;
            int colno = range.Columns.Count;
            for (int i = 1; i < colno + 1; i++)
            {
                if (range.Cells[1, i].Value.ToString() == "Name")
                {
                    NameCell = i;
                }
                if (range.Cells[1, i].Value.ToString() == "Admission Number")
                {
                    AdmNoCell = i;
                }
            }
            for (int i = 2; i < rowno + 1; i++)
            {
                var student = new Student();
                student.Name = range.Cells[i, NameCell].Value.ToString();
                student.AdmissionNumber = range.Cells[i, AdmNoCell].Value.ToString();
                students.Add(student);
            }
            ClassStudents = students;
            return students;
        }
        public Subject GetSubject(Worksheet subjectResult)
        {
            var subject = new Subject();
            subject.CA = new Dictionary<string, float>();
            subject.Exam = new Dictionary<string, float>();
            subject.SubjectName = subjectResult.Name;
            Range range;

            int CACell = new int();
            var AdmNoCell = new int();
            var examCell = new int();

            range = subjectResult.UsedRange;
            int rowno = range.Rows.Count;
            int colno = range.Columns.Count;
            for (int i = 1; i < colno + 1; i++)
            {
                if (range.Cells[1, i].Value.ToString() == "C.A")
                {
                    CACell = i;
                }
                if (range.Cells[1, i].Value.ToString() == "Exam")
                {
                    examCell = i;
                }
                if (range.Cells[1, i].Value.ToString() == "Admission Number")
                {
                    AdmNoCell = i;
                }
            }
            for (int i = 2; i < rowno + 1; i++)
            {
               var CA = float.Parse(range.Cells[i, CACell].Value.ToString());
                var admNo = range.Cells[i, AdmNoCell].Value.ToString();
                var exam = float.Parse(range.Cells[i, examCell].Value.ToString());

                subject.CA.Add(admNo, CA);
                subject.Exam.Add(admNo, exam);
            }
            return subject;
        }
        public List<string> GetSheetNames(Workbook xlWorkBook)
        {
            var names = new List<string>();
            foreach (Worksheet worksheet in xlWorkBook.Worksheets)
            {
                names.Add(worksheet.Name);
            }
            return names;
        }
        public bool ValidateClass(string selectedClass)
        {
            SelectedClass = AllStudents.Sheets[selectedClass];
            Range range;

            int NameCell = new int();
            var AdmNoCell = new int();

            range = SelectedClass.UsedRange;
            int rowno = range.Rows.Count;
            int colno = range.Columns.Count;
            for (int i = 1; i < colno + 1; i++)
            {
                if (range.Cells[1, i].Value.ToString() == "Names")
                {
                    NameCell = i;
                }
                if (range.Cells[1, i].Value.ToString() == "Admission Number")
                {
                    AdmNoCell = i;
                }
            }
            if (NameCell != null && AdmNoCell != null)
            {
                return true;
            }
            else return false;
        }
    }
}
