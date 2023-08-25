using System;
using TMPro;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueChoice : MonoBehaviour, IDialogueChoice 
    {
        public int ChoiceIndex { get; set; }
        [SerializeField] private TMP_Text text;
        [SerializeField] private GameObject hoverPanel;
        
        public Action<int> OnChoiceSelected { get; set; }
        
        public void SetChoiceText(string text, int index)
        {
            this.text.SetText(text);
            ChoiceIndex = index;
        }

        public void Hover()
        {
            hoverPanel.SetActive(true);    
        }
        
        public void HoverStopped()
        {
            hoverPanel.SetActive(false);
        }

        public void Select()
        {
            OnChoiceSelected?.Invoke(ChoiceIndex);
        }
    }
}