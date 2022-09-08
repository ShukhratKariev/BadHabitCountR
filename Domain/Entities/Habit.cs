namespace Domain.Entities;

public class Habit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MonthlyGoal { get; set; }
    public int UserId { get; set; }
    public DateOnly CreatedAt { get; set; }


    public List<HabitUsage> Usages { get; set; }
    public User User { get; set; }
}