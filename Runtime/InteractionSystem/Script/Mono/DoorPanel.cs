namespace InteractionSystem
{
    public class DoorPanel : OpenableRotatingBase
    {
        public void Initialize(bool isOpened)
        {
            IsOpened = isOpened;
        }
    }
}