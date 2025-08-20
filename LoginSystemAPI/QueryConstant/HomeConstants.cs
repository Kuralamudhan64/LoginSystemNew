namespace LoginSystemAPI.QueryConstant
{
    public class HomeConstants
    {
        internal const string SIGNUP = "INSERT INTO USERSS (USERNAME, [PASSWORD]) VALUES (@username,@password)";
        internal const string EXISTS = "SELECT COUNT(*) FROM USERSS WHERE USERNAME = @username";
        internal const string SIGNIN = "SELECT USERNAME, [PASSWORD] FROM USERSS WHERE USERNAME=@username AND [PASSWORD]=@password";
    }
}
