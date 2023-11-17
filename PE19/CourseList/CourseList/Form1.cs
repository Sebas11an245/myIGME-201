using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseLib;
using PeopleAppGlobals;



/************************************************************************ 
 * 1. Add a ListView with the following settings:

(Name): courseListView

Columns: [...]
	(Name): codeHdr
	DisplayIndex: 0
	Text: Code
	Width: 180

	(Name): descHdr
	DisplayIndex: 1
	Text: Description
	Width: 250

	(Name): instructorName
	DisplayIndex: 2
	Text: Instructor
	Width: 175

	(Name): dowHdr
	DisplayIndex: 3
	Text: Days
	Width: 100

	(Name): timeHdr
	DisplayIndex: 4
	Text: Time
	Width: 300

FullRowSelect: True
GridLines: False
Location: 1,2
MultiSelect: False
Size: 798,348
TabIndex: 1
View: Details

*************************************************************************/


namespace CourseList
{
    public partial class CourseListForm : Form
    {
        private System.Windows.Forms.ListView courseListView;
        private System.Windows.Forms.ColumnHeader codeHdr;
        private System.Windows.Forms.ColumnHeader descHdr;
        private System.Windows.Forms.ColumnHeader instructorName;
        private System.Windows.Forms.ColumnHeader dowHdr;
        private System.Windows.Forms.ColumnHeader timeHdr;

        private void InitializeListView()
        {
            this.courseListView = new System.Windows.Forms.ListView();
            this.codeHdr = new System.Windows.Forms.ColumnHeader();
            this.descHdr = new System.Windows.Forms.ColumnHeader();
            this.instructorName = new System.Windows.Forms.ColumnHeader();
            this.dowHdr = new System.Windows.Forms.ColumnHeader();
            this.timeHdr = new System.Windows.Forms.ColumnHeader();

            // 
            // courseListView
            // 
            this.courseListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.codeHdr,
            this.descHdr,
            this.instructorName,
            this.dowHdr,
            this.timeHdr});
            this.courseListView.FullRowSelect = true;
            this.courseListView.GridLines = false;
            this.courseListView.Location = new System.Drawing.Point(1, 2);
            this.courseListView.MultiSelect = false;
            this.courseListView.Name = "courseListView";
            this.courseListView.Size = new System.Drawing.Size(798, 348);
            this.courseListView.TabIndex = 1;
            this.courseListView.View = System.Windows.Forms.View.Details;

            // 
            // codeHdr
            // 
            this.codeHdr.DisplayIndex = 0;
            this.codeHdr.Text = "Code";
            this.codeHdr.Width = 180;

            // 
            // descHdr
            // 
            this.descHdr.DisplayIndex = 1;
            this.descHdr.Text = "Description";
            this.descHdr.Width = 250;

            // 
            // instructorName
            // 
            this.instructorName.DisplayIndex = 2;
            this.instructorName.Text = "Instructor";
            this.instructorName.Width = 175;

            // 
            // dowHdr
            // 
            this.dowHdr.DisplayIndex = 3;
            this.dowHdr.Text = "Days";
            this.dowHdr.Width = 100;

            // 
            // timeHdr
            // 
            this.timeHdr.DisplayIndex = 4;
            this.timeHdr.Text = "Time";
            this.timeHdr.Width = 300;

            this.Controls.Add(this.courseListView);
        }
        public CourseListForm()
        {
            InitializeComponent();

            InitializeListView();

            Globals.AddCoursesSampleData();

            this.courseListView.ItemActivate += new EventHandler(CourseListView__ItemActivate);

            this.courseListView.KeyDown += new KeyEventHandler(CourseListView__KeyDown);

            this.courseListView.SelectedIndexChanged += new EventHandler(CourseListView__SelectedIndexChanged);

            this.updateButton.Enabled = false;

            this.courseCodeTextBox.Enabled = false;

            this.courseDescriptionTextBox.Enabled = false;

            this.reviewRichTextBox.Enabled = false;

            this.courseListView.Focus();

            this.updateButton.Click += new EventHandler(UpdateButton__Click);
            this.exitButton.Click += new EventHandler(ExitButton__Click);

            PaintListView(null);
        }


        public void PaintListView(string firstCourseCode)
        {
            // redraws the ListView based on the current contents of courses
            // and whether to start the current page of courses with firstCourseCode
            // passed in as a parameter
            ListViewItem lvi = null;
            ListViewItem.ListViewSubItem lvsi = null;
            ListViewItem firstLVI = null;

            int nStartEl = 0;

            if(!string.IsNullOrEmpty(firstCourseCode))
            {
                nStartEl = Globals.courses.sortedList.IndexOfKey(firstCourseCode);

            }

            this.courseListView.Items.Clear();


            this.courseListView.BeginUpdate();


            int lviCntr = 0;

            foreach (KeyValuePair<string, Course> keyValuePair in Globals.courses.sortedList)
            {
                Course thisCourse = keyValuePair.Value;

                lvi = new ListViewItem();

                lvi.Text = thisCourse.courseCode;

                lvi.Tag = thisCourse.courseCode;


                // alternate row color
                if (lviCntr % 2 == 0)
                {
                    lvi.BackColor = Color.LightBlue;
                }
                else
                {
                    lvi.BackColor = Color.Beige;
                }


                lvsi = new ListViewItem.ListViewSubItem(lvi, thisCourse.description);

                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem(lvi, thisCourse.teacherEmail);

                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem(lvi, thisCourse.schedule.DaysOfWeek());

                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem(lvi, thisCourse.schedule.GetTimes());

                lvi.SubItems.Add(lvsi);



                if (lviCntr == nStartEl)
                {
                    lvi.Selected = true;

                    lvi.Focused = true;

                    firstLVI = lvi;
                }

                this.courseListView.Items.Add(lvi);

                lviCntr++;
            }


            this.courseListView.EndUpdate();


            this.courseListView.TopItem = firstLVI;

        }


        private void CourseListView__ItemActivate(object sender, EventArgs e)
        {
            // this is the Event Handler for the mouse double-click on a row of the ListView

            Course course = null;
            ListView lv = (ListView)sender;
            string courseCode = null;

            courseCode = lv.SelectedItems[0].Tag.ToString();


            course = Globals.courses[courseCode];


            if (course != null)
            {
                this.courseCodeTextBox.Text = course.courseCode;

                this.courseDescriptionTextBox.Text = course.description;

                this.reviewRichTextBox.Text = course.review;

                lv.Enabled = false;

                this.courseCodeTextBox.Enabled = true;

                this.courseDescriptionTextBox.Enabled = true;

                this.reviewRichTextBox.Enabled = true;

                this.updateButton.Enabled = true;

            }
        }


        private void CourseListView__KeyDown(object sender, KeyEventArgs e)
        {
            // this is the Event Handler for pressing Enter on a row of the ListView

            Course course = null;
            ListView lv = (ListView)sender;
            string courseCode = null;

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;


                try
                {
                    courseCode = lv.SelectedItems[0].Tag.ToString();


                    course = Globals.courses[courseCode];


                    if (course != null)
                    {
                        this.courseCodeTextBox.Text = course.courseCode;

                        this.courseDescriptionTextBox.Text = course.description;

                        this.reviewRichTextBox.Text = course.review;

                        lv.Enabled = false;

                        this.courseCodeTextBox.Enabled = true;

                        this.courseDescriptionTextBox.Enabled = true;

                        this.reviewRichTextBox.Enabled = true;

                        this.updateButton.Enabled = true;

                    }
                }
                catch
                {

                }
            }
        }


        private void CourseListView__SelectedIndexChanged(object sender, EventArgs e)
        {
            // this is the Event Handler for using the arrow keys or single-clicking on another row of the ListView

            Course course = null;
            ListView lv = (ListView)sender;
            string courseCode = null;

            try
            {
                courseCode = lv.SelectedItems[0].Tag.ToString();


                course = Globals.courses[courseCode];

            }
            catch
            {

            }

            if (course != null)
            {
                this.courseCodeTextBox.Text = course.courseCode;


                this.courseDescriptionTextBox.Text = course.description;


                this.reviewRichTextBox.Text = course.review;

            }
        }
        private void UpdateButton__Click(object sender, EventArgs e)
        {
            /// if the Update Button is pressed we need to 
            ///    1. fetch the selected Course object
            ///    2. Do a Deep Copy (Clone) of the Course object to fetch all original data into a new object
            ///    3. remove the selected Course object from courses
            ///    4. copy the text from the controls into the copied Course object
            ///    5. remove an existing Course from courses which has the updated courseCode, 
            ///       since the user may have edited it to be an existing courseCode


            Course origCourse = null;
            Course copyCourse = null;

            // get the original courseCode from the selected course in the courseListView
            string origCourseCode = this.courseListView.SelectedItems[0].Text;

            // fetch the original Course object
            origCourse = Globals.courses[origCourseCode];

            // if it's a valid object
            if (origCourse != null)
            {
                // do a Deep Copy of the original course object into a new object using the Clone() method
                copyCourse = (Course)origCourse.Clone();

                // remove the original Course from courses
                Globals.courses.Remove(origCourseCode);
            }

            copyCourse.courseCode = this.courseCodeTextBox.Text;


            copyCourse.description = this.courseDescriptionTextBox.Text;


            copyCourse.review = this.reviewRichTextBox.Text;


            // remove the updated courseCode from courses
            Globals.courses.Remove(copyCourse.courseCode);

            // insert the updated course into courses
            Globals.courses[copyCourse.courseCode] = copyCourse;

            this.courseListView.Enabled = true;


            // set the focus to the courseListView
            this.courseListView.Focus();

            this.courseCodeTextBox.Enabled = false;


            this.courseDescriptionTextBox.Enabled = false;


            this.reviewRichTextBox.Enabled = false;


            this.updateButton.Enabled = false;


            PaintListView(copyCourse.courseCode);

        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}