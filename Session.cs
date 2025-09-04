namespace Proyecto.Data
{
    public static class Session
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string UserType { get; set; }
        public static int? TechnicianId { get; set; }

        public static void Clear()
        {
            UserId = 0;
            Username = "";
            UserType = "";
            TechnicianId = null;
        }
    }
}