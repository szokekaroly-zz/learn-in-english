using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Learn.Model
{
    /// <summary>
    /// Tanfolyamok tároló osztálya
    /// </summary>
    class CoursesRepository
    {
        private readonly List<Course<Lesson<Word>>> _courseList;
        /// <summary>
        /// Konstruktor
        /// </summary>
        public CoursesRepository()
        {
            Directory = string.Empty;
            _courseList = new List<Course<Lesson<Word>>>();
        }
        /// <summary>
        /// Tanfolyam fájlok könyvtára
        /// </summary>
        public string Directory
        {
            get;
            set;
        }
        /// <summary>
        /// Tanfolyamok listája
        /// </summary>
        public List<Course<Lesson<Word>>> CourseList
        {
            get { return _courseList; }
        }
        /// <summary>
        /// Paraméterben kapott tanfolyam mentése
        /// </summary>
        /// <param name="course">Tanfolyam</param>
        private void Save(Course<Lesson<Word>> course)
        {
            if (course.FileName != string.Empty)
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(Directory,course.FileName)))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Course<Lesson<Word>>));
                    serializer.Serialize(writer, course);
                    writer.Close();
                }
            }
        }
        /// <summary>
        /// Elmenti az összes tanfolyamot
        /// </summary>
        public void SaveAll()
        {
            int i = 0;
            foreach (var course in CourseList)
            {
                if (course.FileName==string.Empty)
                {
                    do
                    {
                        course.FileName = Path.Combine(Directory, string.Format("course{0}.xml", i++));
                    } while (File.Exists(course.FileName));
                }
                Save(course);
            }
        }
        /// <summary>
        /// Paraméterben kapott fájlnevű lecke betöltése
        /// </summary>
        /// <param name="FileName">Fájlnév</param>
        /// <returns></returns>
        private void Load(string FileName)
        {
            if (FileName != null)
            {
                using (StreamReader reader = new StreamReader(Path.Combine(Directory,FileName)))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Course<Lesson<Word>>));
                    Course<Lesson<Word>> course = (Course<Lesson<Word>>)serializer.Deserialize(reader);
                    reader.Close();
                    CourseList.Add(course);
                }
            }
            return null;
        }

        public void LoadAll()
        {
            foreach (var file in System.IO.Directory.GetFiles(Directory,"*.xml"))
            {
                Load(file);
            }
        }
    }
}
