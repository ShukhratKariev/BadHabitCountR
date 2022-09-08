using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName => FirstName + " " + LastName;

    public List<Habit> Habits { get; set; } = new();

    public List<HabitUsage> Usages { get; set; } = new();
}