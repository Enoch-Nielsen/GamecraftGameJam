using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerMessage : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI messageText;
        [SerializeField] private float fadeTime;

        private void Start()
        {
            messageText.alpha = 0.0F;
        }

        private void Update()
        {
            if (messageText.alpha > 0)
            {
                messageText.alpha -= Time.deltaTime / fadeTime;
            }
        }

        public void SendMessage(string text)
        {
            messageText.text = text;
            messageText.alpha = 1.0F;
        }
    }
}
