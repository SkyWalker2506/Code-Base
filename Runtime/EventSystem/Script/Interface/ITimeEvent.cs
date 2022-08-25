namespace EventSystem
{
    public interface ITimeEvent 
    {
        TimeEventData Data { get; }
        void Initialize();
        void EachTick();
        void TimeEnded();
        void SetCurrentTime(float time);
    }
}
