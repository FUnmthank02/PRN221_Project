﻿
namespace PRN221_Project.Business.Helper
{
    public class Helper
    {
        public static int? GetIdFromSession(ISession session, string key)
        {
            return session.GetInt32(key);
        }
        
        public static void SetIdToSession(ISession session, string key, int value)
        {
            session.SetInt32(key, value);
        }
        
        public static void RemoveIdFromSession(ISession session, string key)
        {
            session.Remove(key);
        }
    }
}
