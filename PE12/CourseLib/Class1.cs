using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CourseLib
{
    public partial class Schedule
    {
        public DateTime startTime;
        public DateTime endTime;
        public List<DayOfWeek> daysOfWeek = new List<DayOfWeek>();
    }
    public partial class Course
    {
        public string courseCode;
        public string description;
        public string teacherEmail;
        public Schedule schedule;
        public Course()
        {
        }
        public Course(string courseCode, string description)
        {
            this.courseCode = courseCode;
            this.description = description;
        }
    }
    public class Courses
    {
        // the generic SortedList class uses a template <> to store indexed data
        // the first type is the data type to index on
        // the second type is the data type to store in the list
        // create a Sorted List indexed on email (string) and storing Person objects
        public SortedList<string, Course> sortedList = new SortedList<string, Course>();
        public Courses()
        {
            Course thisCourse;
            Schedule thisSchedule;
            Random rand = new Random();
            // generate courses IGME-200 through IGME-299
            for (int i = 200; i < 300; ++i)
            {
                // use constructor to create new course object with code and description
                thisCourse = new Course(($"IGME-{i}"), ($"Description for IGME-{i}"));
                // create a new Schedule object
                thisSchedule = new Schedule();
                for (int dow = 0; dow < 7; ++dow)
                {
                    // 50% chance of the class being on this day of week
                    if (rand.Next(0, 2) == 1)
                    {
                        // add to the daysOfWeek list
                        thisSchedule.daysOfWeek.Add((DayOfWeek)dow);
                        // select random hour of day
                        int nHour = rand.Next(0, 24);
                        // set start and end times of minute duration
                        // select fixed date to allow time calculations
                        thisSchedule.startTime = new DateTime(1, 1, 1, nHour, 0, 0);
                        thisSchedule.endTime = new DateTime(1, 1, 1, nHour, 50, 0);
                    }
                }
                // set the schedule for this course
                thisCourse.schedule = thisSchedule;
                // add this course to the SortedList
                this[thisCourse.courseCode] = thisCourse;
            }
        }
        public void Remove(string courseCode)
        {
            if (courseCode != null)
            {
                sortedList.Remove(courseCode);
            }
        }
        // indexer property allows array access to sortedList via the class object
        // and catching missing keys and duplicate key exceptions
        // notice the indexer property definition shows how it will be used in the calling code:
        // if we have:
        // Courses courses;
        // then we can call:
        // courses[courseCode] to access the Course object with that courseCode
        // and value will be the Course object (course) being added to the list in the case of:
        // courses[courseCode] = course;
        public Course this[string courseCode]
        {
            get
            {
                Course returnVal;
                try
                {
                    returnVal = (Course)sortedList[courseCode];
                }
                catch
                {
                    returnVal = null;
                }
                return (returnVal);
            }
            set
            {
                try
                {
                    // we can add to the list using these 2 methods
                    // sortedList.Add(courseCode, value);
                    sortedList[courseCode] = value;
                }
                catch
                {
                    // an exception will be raised if an entry with a duplicate key is added
                    // duplicate key handling
                }
            }

        }
    }
    public class Student : Person, IPerson, IStudent
    {
        public double gpa;
        public List<string> courseCodes = new List<string>();
        public void Eat()
        {
            Console.WriteLine("Order a pizza!");
        }
        public void Party()
        {
            Console.WriteLine("Party on dude");
        }
    }
}
