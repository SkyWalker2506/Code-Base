using System;
using TMPro;
using UnityEngine;

namespace InteractionSystem
{
    public class InteractionPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text interactionTextObject;

        public void SetText(string interactionText)
        {
            interactionTextObject.SetText(interactionText);
        }
    }
}