namespace Domain.Entities;

public class HabitUsage
{
    public long Id { get; set; }
    public DateTime Time { get; set; }
    public int HabitId { get; set; }


    public Habit Habit { get; set; }
    public List<HabitUsage> Usages { get; set; }
}