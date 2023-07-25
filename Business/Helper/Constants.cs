namespace PRN221_Project.Business.Helper
{
    public static class Constants
    {
        // constants session key
        public const string LECTURE_ID_KEY = "lectureId";

        // constants title keys
        public const string TITLE_KEY = "Title";
        
        // constants message keys
        public const string MESSAGE_KEY_RESPONSE = "response_message";
        
        // constants page keys
        public const string PAGE_KEY = "Page";
        public const string PAGE_HOME = "Home";
        public const string PAGE_ATTENDANCE = "Attendance";
        public const string PAGE_TIME_TABLE = "Time Table";
        public const string PAGE_SIGN_IN = "Sign in";
        public const string PAGE_CHANGE_PASSWORD = "Change Password";

        // constants layouts
        public const string LAYOUT_NAME = "_layout";

        // constants messages
        public const string MESSAGE_NULL_FIELD = "You must fill all fields!";
        public const string MESSAGE_WRONG_ACCOUNT = "Username or password is not correct!";
        public const string MESSAGE_ADD_ATTENDANCE_SUCCESSFULLY = "You have add attendances successfully!";
        public const string MESSAGE_ADD_ATTENDANCE_FAIL = "You have add attendances fail!";
        public const string MESSAGE_UPDATE_ATTENDANCE_SUCCESSFULLY = "You have update attendances successfully!";
        public const string MESSAGE_UPDATE_ATTENDANCE_FAIL = "You have update attendances fail!";
        public const string MESSAGE_UPDATE_ATTENDANCE_NOT_FOUND = "Attendance not found";
        public const string MESSAGE_CHANGE_PASSWORD_SUCCESSFULLY = "You have change password successfully!";
        public const string MESSAGE_INCORRECT_OLD_PASSSWORD = "Old password is incorrect!";
        public const string MESSAGE_CHANGE_PASSWORD_FAIL = "You have change password fail!";

        //constants routes
        public const string ROUTE_HOME = "/";
        public const string ROUTE_SIGN_IN = "/signin";
        public const string ROUTE_ATTENDANCE = "/attendance";
        public const string ROUTE_TIME_TABLE = "/time-table";
        public const string ROUTE_CHANGE_PASSWORD = "/change-password";

        //constants title of pages
        public const string TITLE_HOME = "Home page";
        public const string TITLE_SIGN_IN = "Sign in page";
        public const string TITLE_ATTENDANCE = "Attendance page";
        public const string TITLE_TIME_TABLE = "Time table page";
        public const string TITLE_CHANGE_PASSWORD = "Change password page";
    }
}
