
using System;

namespace DialogueSystem
{
    public interface IDialogueChoice
    {
        int ChoiceIndex { get; set; }
        void SetChoiceText(string text,int index);
        void Hover();
        void HoverStopped();
        void Select();
        Action<int> OnChoiceSelected { get; set; }
    }
}