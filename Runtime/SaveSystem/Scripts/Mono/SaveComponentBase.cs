using System;
using UnityEngine;

namespace SaveSystem
{
    public abstract class SaveComponentBase : MonoBehaviour, ISaveComponent
    {
        public string ID => _id;

        [SerializeField]private string _id;

        public void GenerateID()
        {
            if (string.IsNullOrWhiteSpace(_id))
            {
                _id = Guid.NewGuid().ToString();
            }
        }

        private void OnEnable()
        {
            SaveManager.RegisterSaveComponent(this);
        }

        private void OnDisable()
        {
            SaveManager.UnregisterSaveComponent(this);
        }

        public abstract string GetSerializedValue();
        public abstract void LoadData(string value);

        [ContextMenu("SaveTest")]
        public void SaveTest()
        {
            SaveManager.SaveData();
        }

        [ContextMenu("LoadTest")]
        public void LoadTest()
        {
            SaveManager.LoadData();
        }

    }
}