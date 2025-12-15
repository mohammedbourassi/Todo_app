using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Todo_app.Models;

namespace Todo_app.Attributes
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var env = validationContext.GetService(typeof(IWebHostEnvironment)) as IWebHostEnvironment;
            if (env == null) return ValidationResult.Success;

            var filePath = Path.Combine(env.WebRootPath, "data", "users.json");
            if (!File.Exists(filePath)) return ValidationResult.Success;

            var jsonData = File.ReadAllText(filePath);
            List<User> users;

            if (string.IsNullOrWhiteSpace(jsonData))
            {
                users = new List<User>();
            }
            else
            {
                try
                {
                    users = JsonSerializer.Deserialize<List<User>>(jsonData) ?? new List<User>();
                }
                catch (JsonException)
                {
                    // log the malformed JSON, then treat as empty list (or surface an error)
                    users = new List<User>();
                }
            }

            var email = value.ToString()?.Trim();
            if (string.IsNullOrEmpty(email)) return ValidationResult.Success;

            if (users.Any(u => u.Email != null &&
                               u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                return new ValidationResult(ErrorMessage ?? "Email already exists.");
            }

            return ValidationResult.Success;
        }
    }
}
