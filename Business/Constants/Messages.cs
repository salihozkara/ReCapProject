using Core.Entities;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added(string entity=null) { return $"{entity} eklendi"; }
        public static string NameInvalid(string entity=null) {return $"{entity} ismi geçersiz"; }
        public static string MaintenanceTime = "Sistem bakımda";
        public static string Listed(string entity=null) {return $"{entity}lar listelendi"; }
    }
}