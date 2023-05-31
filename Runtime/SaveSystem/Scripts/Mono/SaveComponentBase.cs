using System;
using UnityEngine;

namespace SaveSystem
{
    public abstract class SaveComponentBase : MonoBehaviour, ISaveComponent
    {
        public int ID { get; private set; }

        private void Awake()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
             ID = GetInstanceID();
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