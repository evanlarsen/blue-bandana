namespace Lunch.Infrastructure
{
    public interface ISettingsBuilder<T> where T : new()
    {
        T GetSettings();
    }
}
