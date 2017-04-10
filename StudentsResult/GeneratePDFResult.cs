using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace StudentsResult
{
    public class GeneratePDFResult
    {
        private iTextSharp.text.Image schoolLogo;
       
        public void WriteResultTable(Student student,Document doc, Dictionary<string, List<StudentSubjectScore>> data)
        {

            var mainTable = new PdfPTable(1);
            mainTable.SetTotalWidth(new float[] { 1000f });
            mainTable.HorizontalAlignment = Element.ALIGN_CENTER;
            mainTable.LockedWidth = true;

            AddResultTable(student,doc, data);
            // Will Add Psychomotor here for term results

           // doc.Add(new Paragraph("Grade Scale: " + data.GradeInfo, new Font(Font.FontFamily.TIMES_ROMAN, 7f)));
        }
        private void AddResultTable(Student student, Document doc, Dictionary<string, List<StudentSubjectScore>> data)
        {
            var columns = 5;
            var table = new PdfPTable(columns);


            var tableWidths = GetTableWidths(columns);
            table.SetTotalWidth(tableWidths);
            table.LockedWidth = true;

            table.HorizontalAlignment = Element.ALIGN_LEFT;

            var titleCell = new PdfPCell(new Phrase("", new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD)));
            titleCell.VerticalAlignment = Element.ALIGN_CENTER;
            titleCell.HorizontalAlignment = Element.ALIGN_CENTER;

            titleCell.Colspan = columns;
            table.AddCell(titleCell);

            var blankCell = new PdfPCell();
            blankCell.Colspan = 2;

            table.AddCell(blankCell);

            var thirdTermCell = new PdfPCell(new Phrase("3RD TERM"));
            thirdTermCell.Colspan = 5 - 2; // to account for blank
            thirdTermCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(thirdTermCell);

            //var annualCell = new PdfPCell(new Phrase("CUMULATIVE"));
            //annualCell.Colspan = data.AnnualResultHeaders.Count + 2; // to account for blank
            //annualCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //table.AddCell(annualCell);
           // var list =["CA", "exam", "total"];
            var headers = new List<string>();
            // headers.AddRange();
            //headers.AddRange(list);
            headers.Add("S/N");
            headers.Add("SUBJECT");
            headers.Add("CA");
            headers.Add("exam");
            headers.Add("Total");

            foreach (var header in headers)
            {
                var headerPhrase = new Phrase(header.ToUpper(), new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD));
                var headerCell = new PdfPCell(headerPhrase);
                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerCell.VerticalAlignment = Element.ALIGN_BOTTOM;
                if (header != "SUBJECT" && header != "S/N")
                {
                    headerCell.Rotation = 90;
                    headerCell.FixedHeight = 90f;
                    headerCell.HorizontalAlignment = Element.ALIGN_MIDDLE;
                    headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                }

                table.AddCell(headerCell);
            }

            var count = 1;
            foreach (var subjectResult in data.OrderBy(r => r.Key))
            {
                var serialNumber = new Phrase(count.ToString(), new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD));
                var serialCell = new PdfPCell(serialNumber);
                table.AddCell(serialCell);

                var subject = new Phrase(subjectResult.Key, new Font(Font.FontFamily.HELVETICA, 7f, Font.BOLD));
                var subjectCell = new PdfPCell(subject);
                table.AddCell(subjectCell);

                var entries = new List<string>();
                entries.Add(subjectResult.Value.Where(x=>x.AdmissionNumber==student.AdmissionNumber).FirstOrDefault().CA.ToString());
                entries.Add(subjectResult.Value.Where(x => x.AdmissionNumber == student.AdmissionNumber).FirstOrDefault().Exam.ToString());
                entries.Add(subjectResult.Value.Where(x => x.AdmissionNumber == student.AdmissionNumber).FirstOrDefault().Total.ToString());

                foreach (var entry in entries)
                {

                    var itemValue = new Phrase(entry, new Font(Font.FontFamily.HELVETICA, 7f));
                    var cell = new PdfPCell(itemValue);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }

                count++;
            }

            doc.Add(new Paragraph("  "));
            // doc.Add(new Paragraph("  "));

            doc.Add(table);


        }
        private float[] GetTableWidths(int columns)
        {
            var result = new float[columns];

            result[0] = 20f;

            if (columns <= 14)
            {
                result[1] = 220f;

            }
            else
            {
                result[1] = 180f;
            }


            for (int x = 2; x < columns - 1; x++)
            {
                if (columns >= 14)
                    result[x] = 21f;
                else
                    result[x] = 21f;
            }

            if (columns >= 14)
                result[columns - 1] = 52f;
            else
                result[columns - 1] = 54f;

            return result;
        }

    }

}
