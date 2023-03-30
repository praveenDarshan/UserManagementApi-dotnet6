namespace UserManagementApi
{
    public class User
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Remark { get; set; } = string.Empty;
        //public UserImages UserImages { get; set; }
        //public int UserImageId { get; set; }

    }
}
