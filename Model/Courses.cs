using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Learn.Model
{
    /// <summary>
    /// Tanfolyamok tároló osztálya
    /// </summary>
    public class Courses:Notifier
    {
        private void OnModified(object sender, EventArgs e)
        {
            IsModified=true;
        }
        private readonly CourseRepository _courses;
        /// <summary>
        /// Konstruktor
        /// </summary>
        public Courses(CourseRepository repository)
        {
            _courses = repository;
        }
        /// <summary>
        /// Tanfolyamok listája
        /// </summary>
        public ObservableCollection<Course> CourseList
        {
            get { return _courses.CourseList; }
        }

        public Course this[int idx]
        {
            get
            {
                if (idx >= 0 && idx < _courses.CourseList.Count)
                    return _courses[idx];
                else
                    throw new IndexOutOfRangeException("Indexhatár átlépés");
            }
            private set
            {
                if (idx >= 0 && idx < _courses.CourseList.Count)
                {
                    _courses[idx] = value;
                    IsModified = true;
                    NotifyPropertyChanged();
                    _courses[idx].Modified += OnModified;
                }
            }
        }
        private void ResetIsModified()
        {
            foreach (var course in _courses.CourseList)
            {
                foreach (var lesson in course.Items)
                {
                    foreach (var word in lesson.Items)
                    {
                        word.IsModified = false;
                    }
                    lesson.IsModified = false;
                }
                course.IsModified = false;
            }
            IsModified = false;
        }
        /// <summary>
        /// Elmenti az összes tanfolyamot
        /// </summary>
        public void SaveAll()
        {
            _courses.SaveAll();
            ResetIsModified();
        }

        public void LoadAll()
        {
            _courses.LoadAll();
            ResetIsModified();
            foreach (var course in _courses.CourseList)
            {
                course.Modified += OnModified;
                foreach (var lesson in course.Items)
                {
                    lesson.Modified += course.OnModified;
                    foreach (var word in lesson.Items)
                    {
                        word.Modified += lesson.OnModified;
                    }
                }
            }
        }

        public void Reload(Course course)
        {
            _courses.Reload(course);
            ResetIsModified();
        }

        public Course CreateCourse()
        {
            Course course = new Course();
            _courses.CourseList.Add(course);
            IsModified = true;
            NotifyPropertyChanged();
            course.Modified += OnModified;
            return course;
        }

        public void RemoveCourseAt(int idx)
        {
            _courses.CourseList[idx].Modified -= OnModified;
            _courses.CourseList.RemoveAt(idx);
            IsModified = true;
            NotifyPropertyChanged();
        }

        public void RemoveCourse(Course course)
        {
            if (_courses.CourseList.Contains(course))
            {
                course.Modified -= OnModified;
                _courses.CourseList.Remove(course);
                IsModified = true;
                NotifyPropertyChanged();
            }
        }
    }
}
