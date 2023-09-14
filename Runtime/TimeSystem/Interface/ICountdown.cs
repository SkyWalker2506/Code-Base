namespace TimeSystem
{
    public interface ICountdown
    {
        float CountdownTime { get; }        
        float LeftTime { get; }
        float TickInterval { get; }
        CountdownEvents CountdownEvents{ get;}
        void StartCountdown();
        void CancelCountdown();
        void Tick();
        void PauseCountdown();
        void ResumeCountdown();
    }
}
