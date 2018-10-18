using IronPdf;
using Seminar_Management_System.Classes.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_Management_System.Classes
{
    class NameTag
    {
        private const int NameTagsPerPage = 14;
        private const float Height = 65.0f;
        private const float Width = 200.0f;
        public Bitmap nameTag { get; set; }
        public string title { get; set; }

        public Seminar seminarReference { get; set; }
        public NameTag(Seminar seminarReference)
        {
            this.nameTag = new Bitmap(723, 962);
            this.title = seminarReference.Title + "-template.pdf";
            this.seminarReference = seminarReference;

        }
        public void Print()
        {
            // the url need to be changed before using
            // store the attendee whose status is going
            List<SeminarAttendee> goingAttendees = new List<SeminarAttendee>();
            // store the list of pdf, ready for merging
            List<PdfDocument> PDFs = new List<PdfDocument>();

            // set up for handling align
            int counter = 0;
            Image background = new Bitmap(Seminar_Management_System.Properties.Resources.nametag_template);

            //put attendees who with "going" into a list, ready for printing nametags
            foreach (var attendee in this.seminarReference.Attendees)
            {
                if (attendee.Status == "Going")
                {
                    goingAttendees.Add(attendee);
                }
            }
            if (goingAttendees.Count == 0)
            {
                MessageBox.Show("There are no attendees marked as 'Going' for this Seminar.\nNo nametags will be created.", "No Attendees Going", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // draw the background of first page
            using (Graphics g = Graphics.FromImage(nameTag))
            {
                g.DrawImage(background, 0, 0, 723, 962);
            }

            foreach (var attendee in goingAttendees)
            {
                //drawing the first page of name tags 
                if (goingAttendees.IndexOf(attendee) % NameTagsPerPage != 0 || goingAttendees.IndexOf(attendee) == 0)
                {
                    using (Graphics graphics = Graphics.FromImage(nameTag))
                    {
                        using (Font arialFont = new Font("Arial", 20))
                        {
                            // drawing the first column of name tags
                            if (IsOdd(goingAttendees.IndexOf(attendee)))
                            {
                                graphics.DrawString(attendee.Name + "   " + attendee.PhoneNumber, arialFont, Brushes.Black,
                                    new RectangleF(100, 55 + counter, Width, Height));
                            }
                            else // drawing the second column of name tags
                            {
                                graphics.DrawString(attendee.Name + "   " + attendee.PhoneNumber, arialFont, Brushes.Black,
                                    new RectangleF(400, 55 + counter, Width, Height));
                                counter += 135;
                            }
                        }
                        //   nameTag.Save(url);
                        ImageToPdfConvetrer.ImageToPdf(nameTag).SaveAs(this.title);
                    }
                    if (goingAttendees.IndexOf(attendee) == goingAttendees.Count - 1)
                    { PDFs.Add(PdfDocument.FromFile(this.title)); }
                }
                else
                {
                    // adding the pdf into pdf list, ready for merging
                    PDFs.Add(PdfDocument.FromFile(this.title));
                    counter = 0;

                    using (Graphics graphics = Graphics.FromImage(nameTag))
                    {
                        graphics.Clear(Color.White);
                        graphics.DrawImage(background, 0, 0, 723, 962);
                        using (Font arialFont = new Font("Arial", 20))
                        {
                            if (IsOdd(goingAttendees.IndexOf(attendee)))
                            {
                                graphics.DrawString(attendee.Name + "   " + attendee.PhoneNumber, arialFont, Brushes.Black,
                                    new RectangleF(100, 55 + counter, Width, Height));
                            }
                            else // drawing the second column of name tags
                            {
                                graphics.DrawString(attendee.Name + "   " + attendee.PhoneNumber, arialFont, Brushes.Black,
                                    new RectangleF(400, 55 + counter, Width, Height));
                                counter += 135;
                            }
                        }
                    }
                    ImageToPdfConvetrer.ImageToPdf(nameTag).SaveAs(this.title);
                    // print the next page if there is only one attendee 
                    if ((goingAttendees.Count - 1) % NameTagsPerPage == 0) { PDFs.Add(PdfDocument.FromFile(this.title)); }
                }
            }
            // merge multiple pdf files
            if (PDFs.Count != 0)
            {
                PdfDocument result = PdfDocument.Merge(PDFs);
                // save merged pdf in this location, need to be changed before use
                SaveFileDialog printFile = new SaveFileDialog();
                printFile.Filter = "Pdf Files (*.pdf) | *.pdf | All Files(*.*) | *.*";
                printFile.Title = "Save as";
                DialogResult dr = printFile.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    result.SaveAs(printFile.FileName);
                }
                MessageBox.Show("Your nametag template is ready.", "Nametags created successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public Boolean IsOdd(int num)
        {
            if (num % 2 == 0)
            { return true; }
            else { return false; }
        }
    }
}
