namespace Exceptions
{
    internal class Calendar
    {
        private List<Meeting> _meetings;
        public List<Meeting> Meetings 
        { 
            get { return _meetings;} 
            set { _meetings = value; }
        }
       
        public Calendar()
        {
            _meetings = new List<Meeting>();
        }

        public void AddMeeting(Meeting meeting)
        {
            if (meeting.Date < DateTime.Now)
                throw new InvalidDateException("The meeting's date is invalid");
            _meetings.Add(meeting);
        }

        public void ReadFromFile(string path)
        {
            StreamReader fr = null;
            try
            {
                fr = new StreamReader(path);
                Console.WriteLine("\nRead from file " + path);
                try
                {
                    while (!fr.EndOfStream)
                    {
                        string[] line = fr.ReadLine().Split(';');
                        string[] date = line[2].Split(',');
                        string[] interval = line[4].Split(',');
                        Meeting m = new Meeting(line[0], line[1], new DateTime(Int32.Parse(date[0]), Int32.Parse(date[1]),
                            Int32.Parse(date[2])), Int32.Parse(line[3]), new TimeSpan(Int32.Parse(interval[0]), 
                            Int32.Parse(interval[1]), Int32.Parse(interval[2])));
                        AddMeeting(m);
                    } 
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch(InvalidDateException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                finally
                {
                    Console.WriteLine("\nFinally block");
                    fr.Close();
                }
            }

            catch(ArgumentNullException ex)
            {
                throw ex;
            } 

            catch (FileNotFoundException ex)
            {
             throw ex;
            }
        }  
    }
}
