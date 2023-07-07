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

        //constants routes
        public const string ROUTE_HOME = "/";
        public const string ROUTE_SIGN_IN = "/signin";
        public const string ROUTE_ATTENDANCE = "/attendance";
        public const string ROUTE_TIME_TABLE = "/time-table";

        //constants title of pages
        public const string TITLE_HOME = "Home page";
        public const string TITLE_SIGN_IN = "Sign in page";
        public const string TITLE_ATTENDANCE = "Attendance page";
        public const string TITLE_TIME_TABLE = "Time table page";

    }
}
