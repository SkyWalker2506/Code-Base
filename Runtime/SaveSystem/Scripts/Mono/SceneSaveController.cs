using System;
using System.Collections;
using UnityEngine;

namespace SaveSystem
{
    public class SceneSaveController : MonoBehaviour
    {
        [SerializeField] private bool _loadData;
        [SerializeField] private bool _saveData;
        [SerializeField] private float _saveInterval = 1;
        private void Start()
        {
            if (_loadData)
            {
                StartCoroutine(LoadDataCoroutine());
            }

            StartCoroutine(SaveData());
        }

        private IEnumerator LoadDataCoroutine()
        {
            yield return null;
            LoadData();
        }

        [ContextMenu("Load")]
        public void LoadData()
        {
            SaveManager.LoadData();
        }

        private IEnumerator SaveData()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(_saveInterval);
                if (_saveData)
                {
                    SaveManager.SaveData();
                }
            }

        }
    }
}