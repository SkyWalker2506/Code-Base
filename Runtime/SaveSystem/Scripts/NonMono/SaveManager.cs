using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveSystem
{
    public static class SaveManager
    {
        private static string _saveKey = "SaveData";
        private static Dictionary<ISaveComponent, int> _saveComponentIDPairs = new Dictionary<ISaveComponent, int> ();
        private static Dictionary<int, string> _idValuePairs = new Dictionary<int, string>();

        public static void RegisterSaveComponent(ISaveComponent saveComponent)
        {
            _saveComponentIDPairs.Add(saveComponent, saveComponent.ID);
            _idValuePairs.Add(saveComponent.ID, saveComponent.GetSerializedValue());
        }

        public static void UnregisterSaveComponent(ISaveComponent saveComponent)
        {
            _idValuePairs.Remove(_saveComponentIDPairs[saveComponent]);
            _saveComponentIDPairs.Remove(saveComponent);
        }

        public static void SaveData()
        {
            foreach (ISaveComponent saveComponent in _saveComponentIDPairs.Keys)
            {
                _idValuePairs[_saveComponentIDPairs[saveComponent]] = saveComponent.GetSerializedValue();
            }
            string data = JsonConvert.SerializeObject(_idValuePairs,Formatting.Indented);
            PlayerPrefs.SetString(_saveKey, data);
        }
        
        public static void LoadData()
        {
            string data = PlayerPrefs.GetString(_saveKey);
            _idValuePairs = JsonConvert.DeserializeObject<Dictionary<int, string>>(data);
            foreach (KeyValuePair<ISaveComponent, int> saveComponentIDPair in _saveComponentIDPairs)
            {
                if(_saveComponentIDPairs.ContainsKey(saveComponentIDPair.Key))
                {
                    if(_idValuePairs.ContainsKey(saveComponentIDPair.Value))
                    {
                        saveComponentIDPair.Key.LoadData(_idValuePairs[saveComponentIDPair.Value]);
                    }

                }
            }
        }
    }
}