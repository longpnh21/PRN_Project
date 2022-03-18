using System;

namespace UniClub.Worker.Jobs
{
    public class MyJob
    {
        public MyJob(Type type, string expression)
        {
            Common.Logs($"MyJob at {DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss")} - Type: {type.ToString()} - Expression: {expression}", $"MyJob-{DateTime.UtcNow.ToString("dd-MM-yyyy-HH-mm-ss")}");
            Type = type;
            Expression = expression;
        }

        public Type Type { get; }
        public string Expression { get; }
    }
}
