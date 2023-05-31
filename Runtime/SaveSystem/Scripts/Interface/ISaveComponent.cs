namespace SaveSystem
{
    public interface ISaveComponent
    {
        int ID { get; }
        string GetSerializedValue();
        void LoadData(string value);
    }
}