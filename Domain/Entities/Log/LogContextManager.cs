using System.Reflection;

namespace Domain.Entities.Log
{
    public static class LogContextManager
    {
        private static readonly AsyncLocal<LogEvent?> _current = new();

        public static LogEvent? Current
        {
            get => _current.Value;
            set => _current.Value = value;
        }

        public static IDictionary<string, object?> ToDictionary(Guid? userId = null, int Subject = 2)
        {
            var context = Current;
            if (context == null)
                return new Dictionary<string, object?>()
                {
                    ["LogSubjectId"] = 2,
                    ["UserId"] = userId,
                };

            var dictionary = new Dictionary<string, object?>();
            foreach (var property in context.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                dictionary[property.Name] = property.GetValue(context);
            }

            dictionary["LogSubjectId"] = 2;
            dictionary["UserId"] = userId;

            return dictionary;
        }
    }
}
