#define SUPPORTFILES
using System.Diagnostics;
using System.IO;

namespace Exceptions
{
    internal class Program
    {
        public static void ReadData(Calendar calendar,string path)
        {
            try
            {
                calendar.ReadFromFile(path);
            }

            catch (FileNotFoundException ex)
            {
                Console.WriteLine("From Program.cs");
                Console.WriteLine(ex.Message);
                Debug.WriteLine("The name of the file is " + path);

            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
           
         Calendar calendar = new Calendar();
            calendar.Meetings = new List<Meeting>
            {
                new Meeting("Web site restructuring", "online", new DateTime(2022, 11, 23, 12, 0, 0), 1, new TimeSpan(2, 0, 0)),
                new Meeting("Career Expo Event", "online", new DateTime(2022, 12, 2, 10, 30, 0), 5, new TimeSpan(1, 30, 0)),
                new Meeting("Internship Lecture", "online", new DateTime(2022, 12, 2, 15, 0, 0), 2, new TimeSpan(2, 30, 0)),
                new Meeting("Meeting with client", "online", new DateTime(2022, 12, 2, 19, 45, 0), 6, new TimeSpan(0, 30, 0))
            };

            #if SUPPORTFILES
            Console.WriteLine("\nOperations with files are supported");

            //read data from a file
            ReadData(calendar,"meetings.txt");

            //add a new meeting
            try
            {
                calendar.AddMeeting(new Meeting("Meeting with partners", "online", new DateTime(2020, 12, 2, 19, 45, 0), 6, 
                    new TimeSpan(0, 30, 0)));
            }
            catch (InvalidDateException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //upload a file
            User user = new User("Cristina Sisacnu");
            try
            {
                user.UploadFile("boom");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (FileSizeException ex)
            {
                Console.WriteLine(ex.Message, ex.Size);
                Debug.WriteLine("The size of the file is "+ex.Size);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
         #endif        

           
            
        








        }
    }
}