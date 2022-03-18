using System.IO;

namespace UniClub.Worker
{
    public static class Common
    {
        public static void Logs(string message, string filename)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, filename);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                using (TextWriter textWriter = new StreamWriter(stream))
                {
                    textWriter.WriteLine(message);
                }

            }
        }
    }
}
