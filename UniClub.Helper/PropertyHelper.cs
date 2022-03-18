namespace UniClub.Helpers
{
    public static class PropertyHelper
    {
        public static bool HasProperty(this object obj, string propertyName)
        {
            var property = obj.GetType().GetProperty(propertyName);
            return property != null;
        }
    }
}
