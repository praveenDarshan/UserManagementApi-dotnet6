namespace UserManagementApi
{
    public class UserPasswordModel
    {
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; } 
    }
}
