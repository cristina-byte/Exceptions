namespace Exceptions
{
    internal class FileSizeException:Exception
    {
        public long Size { get; set; }
        public FileSizeException(string message, long size) : base(message)
        {
            Size = size;
        }
    }
}
