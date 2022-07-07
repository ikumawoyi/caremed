namespace WebApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Username { get; set; }
		public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}