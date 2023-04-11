using SQLite;

namespace HR_One.Table
{
    [Table("SignInTable")]
    public class SignInTable
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Unique]
        [Column("Email")]
        public string Email { get; set; }
        
        [Column("UserName")]
        public string UserName { get; set; }

        [Column("Password")]
        public string Password { get; set; }
        

    }
}
