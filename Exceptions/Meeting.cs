namespace Exceptions
{
    internal class Meeting 
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public int OrganizerId { get; set; }
        public TimeSpan Duration { get; set; }

        public Meeting(string title, string address, DateTime date, int organizerId, TimeSpan duration)
        {
            Title = title;
            Address = address;
            Date = date;
            OrganizerId = organizerId;
            Duration = duration;
        }

        public override string ToString()=> $"Title: {Title} \nAddress: {Address} \nDate: {Date} " +
                                            $"\nOragazerId:{OrganizerId} \nDuration: {Duration}";
    }
}
