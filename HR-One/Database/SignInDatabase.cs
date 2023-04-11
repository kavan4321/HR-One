using HR_One.Table;
using SQLite;

namespace HR_One.Database
{
    public class SignInDatabase
    {
        private SQLiteAsyncConnection _connection;

        public string Email { get; set; }         
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<SignInTable> SignInDetails { get; set; }
        public void CreateDatabase()
        {
            var databaseName = "SignInDetails";
            var folderName=Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var databasePath=Path.Combine(folderName, databaseName);
            _connection=new SQLiteAsyncConnection(databasePath,true);
        }

        public async Task CreateTableAsync()
        {
            await _connection.CreateTableAsync<SignInTable>();
        }
        public async Task<List<SignInTable>> GetRegisterListAsync()
        {
            var list=await _connection.Table<SignInTable>().ToListAsync();
            SignInDetails = list;
            return list;
        }

        public async Task<bool> InsertAsync()
        {
            var table = new SignInTable
            {
                Email = Email,
                UserName = UserName,
                Password = Password,
            };
            try
            {
                var insertData = await _connection.InsertAsync(table);
                var result = insertData > 0;
                _ = GetRegisterListAsync();
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
