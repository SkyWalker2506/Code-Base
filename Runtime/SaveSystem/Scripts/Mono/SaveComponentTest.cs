using UnityEngine;

namespace SaveSystem
{
    public class SaveComponentTest : SaveComponentBase
    {

        public override string GetSerializedValue()
        {
            return name;
        }

        public override void LoadData(string value)
        {
        }
        
    }
}
