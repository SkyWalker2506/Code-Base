namespace SaveSystem
{
    public interface ISaveComponent
    {
        string ID { get; }
        string GetSerializedValue();
        void LoadData(string value);
    }
}