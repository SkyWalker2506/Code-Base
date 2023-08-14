using TMPro;
using UnityEngine;

namespace InteractionSystem
{
    public class MessagePanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text messageText;

        private void Awake()
        {
            HideMessage();
        }

        public void ShowMessage(string message, float time)
        {
            messageText.SetText(message);
            Invoke(nameof(HideMessage),time);
        }
        
        public void HideMessage()
        {
            messageText.SetText("");
        }
    }
}