using System.Data;
using Dapper;
using LoginSystemAPI.QueryConstant;

namespace LoginSystemAPI.Repository
{
    public class LoginRepository
    {
        private readonly IDbConnection dbConnection;
        public LoginRepository(IDbConnection _dbConnection) 
        { 
            dbConnection = _dbConnection;
        }

        public async Task<int> SignUp(string username, string password)
        {
            string sql_signup = HomeConstants.SIGNUP;
            string sql_exists = HomeConstants.EXISTS;
            try
            {
                if (dbConnection.State != ConnectionState.Open)
                    dbConnection.Open();
                int exists = await dbConnection.ExecuteScalarAsync<int>(sql_exists, new { username});
                if (exists == 0)
                {
                    
                    int rowsaffected = await dbConnection.ExecuteAsync(sql_signup, new { username, password });
                    return rowsaffected;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex) 
            {
                return 0;
            }
        }
    }
}
