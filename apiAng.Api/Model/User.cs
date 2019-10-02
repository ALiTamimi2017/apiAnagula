namespace apiAng.Api.Model
{
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }


        public string Family { get; set; }

        public int   Age { get; set; }

        public byte[] PasswodHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}