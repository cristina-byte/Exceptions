using System.Numerics;

namespace Exceptions
{
    internal class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public BigInteger Phone { get; set; }
        public BigInteger Cnp { get; set; }
        public DateTime BirthDay { get; set; }
       

        public User(string name,string password,string email, BigInteger phone,BigInteger cnp, DateTime birthDay)
        {
          
           Name= name;
           Password= password;
           Email= email;
           Phone= phone;
           Cnp= cnp;  
           BirthDay= birthDay;
        }

        public User(string name)
        {
            Name = name;
        }
     
        public override string ToString() => $"\nName:{Name} \nEmail:{Email} \nPhone:{Phone} \nBorned at:{BirthDay} \nCnp:{Cnp}";

        public void UploadFile(string path)
        {
          FileInfo fileInfo =new FileInfo(path);
             
          if (fileInfo == null)
              throw new FileNotFoundException("Could not find the file " + path);
          if (fileInfo.Length > 5000)
              throw new FileSizeException("The size of the file is to big",fileInfo.Length);
          Console.WriteLine("\nThe file was uploaded");
        }
    }
}
