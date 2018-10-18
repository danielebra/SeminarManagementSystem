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
        string title = "fuck.pdf";
        public Seminar seminarReference { get; set; }
        public NameTag(Seminar seminarReference)
        {
            this.nameTag = new Bitmap(723, 962);
            this.seminarReference = seminarReference;

        }
        private Image getTemplate()
        {
            return new Bitmap(Seminar_Management_System.Properties.Resources.nametag_template);
        }
        private void PrintNameTags()
        {
            // Currently not being used
            List<SeminarAttendee> goingAttendees = this.seminarReference.Attendees.Where(a => a.Status == "Going").ToList();
            Image template = getTemplate();
            int distance = 135;
            int counter = 0;
            using (Graphics g = Graphics.FromImage(template))
            {
                foreach (SeminarAttendee attendee in goingAttendees)
                {
                    // Draw name tag to page
                    using (Font arial = new Font("Arial", 20))
                    {
                        if (counter % 2 == 0)
                        {
                            g.DrawString(attendee.Name + "   " + attendee.PhoneNumber, arial, Brushes.Black,
                            new RectangleF(100, 55 + distance, Width, Height));
                        }
                        else
                        {
                            g.DrawString(attendee.Name + "   " + attendee.PhoneNumber, arial, Brushes.Black,
                            new RectangleF(400, 55 + distance, Width, Height));
                            distance += 135;
                        }
                    }
                    if (counter % NameTagsPerPage == 0)
                    {
                        g.Clear(Color.White);
                        //g = Graphics.FromImage(getTemplate());
                    }
                    counter++;
                }
            }
        }
        public void Print()
        {
            // the url need to be changed before using
            // store the attendee whose status is going
            List<SeminarAttendee> goingAttendees = this.seminarReference.Attendees.Where(a => a.Status == "Going").ToList();
            // store the list of pdf, ready for merging
            List<PdfDocument> PDFs = new List<PdfDocument>();

            // set up for handling align
            int counter = 0;
            Image background = getTemplate();
            
            if (goingAttendees.Count == 0)
            {
                MessageBox.Show("There are no attendees marked as 'Going' for this Seminar.\nNo nametags will be created.", 
                    "No Attendees Going", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // draw the background of first page
            using (Graphics g = Graphics.FromImage(nameTag))
            {
                g.DrawImage(background, 0, 0, 723, 962);
            }
            int attendeesIteratedThrough = 0;
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
                    }
                }
                else
                {
                    // adding the pdf into pdf list, ready for merging
                    //PDFs.Add(PdfDocument.FromFile(this.title));
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
                }

                attendeesIteratedThrough++;
                if (attendeesIteratedThrough == goingAttendees.Count)
                {
                    var reached = true;
                }
                if (attendeesIteratedThrough % NameTagsPerPage == 0 || attendeesIteratedThrough == goingAttendees.Count)
                    PDFs.Add(ImageToPdfConvetrer.ImageToPdf(nameTag).CopyPage(0));
            }

            PdfDocument result = PdfDocument.Merge(PDFs);
            SaveFileDialog printFile = new SaveFileDialog();
            printFile.FileName = seminarReference.Title;
            printFile.Filter = "Pdf Files (*.pdf) | *.pdf | All Files(*.*) | *.*";
            printFile.Title = "Save as";
            DialogResult dr = printFile.ShowDialog();

            if (dr == DialogResult.OK)
            {
                try
                {
                    result.SaveAs(printFile.FileName);
                    MessageBox.Show("Your nametag template is ready and has been saved to \n\n" + printFile.FileName, "Nametags created successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed to Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
