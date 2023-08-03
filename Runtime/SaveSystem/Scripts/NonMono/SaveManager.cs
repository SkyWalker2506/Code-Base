using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace SaveSystem
{
    public static class SaveManager
    {
        private static string _saveKey = "SaveData";
        private static Dictionary<ISaveComponent, string> _saveComponentIDPairs = new Dictionary<ISaveComponent, string> ();
        private static Dictionary<string, string> _idValuePairs = new Dictionary<string, string>();

        public static void RegisterSaveComponent(ISaveComponent saveComponent)
        {
            if (!_saveComponentIDPairs.ContainsKey(saveComponent))
            {
                _saveComponentIDPairs.Add(saveComponent, saveComponent.ID);
            }
            else
            {
                _saveComponentIDPairs[saveComponent] = saveComponent.ID;
            }
            if (!_idValuePairs.ContainsKey(saveComponent.ID))
            {
                _idValuePairs.Add(saveComponent.ID, saveComponent.GetSerializedValue());
            }
            else
            {
                _idValuePairs[saveComponent.ID] = saveComponent.GetSerializedValue();
            }
        }

        public static void UnregisterSaveComponent(ISaveComponent saveComponent)
        {
            if (_saveComponentIDPairs.ContainsKey(saveComponent))
            {
                _saveComponentIDPairs.Remove(saveComponent);
            }
            if (_idValuePairs.ContainsKey(saveComponent.ID))
            {
                _idValuePairs.Remove(saveComponent.ID);
            }
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

            if (string.IsNullOrEmpty(data))
                return;

            _idValuePairs = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            foreach (KeyValuePair<ISaveComponent, string> saveComponentIDPair in _saveComponentIDPairs)
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