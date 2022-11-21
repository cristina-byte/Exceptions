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
            try
            {
                FileStream fr = File.OpenRead(path);
                try
                {
                    if (fr == null)
                        throw new FileNotFoundException("Could not find the file " + path);
                    Console.WriteLine("\nRead from file " + path);
                }
                catch (FileNotFoundException ex)
                {
                    throw ex;
                }
                finally
                {
                    fr.Close();
                }
            }
            catch(ArgumentNullException ex)
            {
                throw ex;
            } 
        }  
    }
}
