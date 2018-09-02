using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Minijuegos
{
    [RequireComponent(typeof(InputField))]
    public class SCR_Ahorcado_Letra : MonoBehaviour
    {
        private InputField myInputField;
        private string myLetter = "";

        public void Init()
        {
            myInputField = GetComponent<InputField>();
        }

        public void Init(char _letter)
        {
            myInputField = GetComponent<InputField>();
            myLetter = _letter.ToString();
            HideLetter();
        }

        public void SetLetter(char _letter)
        {
            myInputField.text = _letter.ToString();
            myLetter = _letter.ToString();
        }

        public void SetLetter(string _letter)
        {
            myInputField.text = _letter;
            myLetter = _letter;
        }

        private void HideLetter()
        {
            myInputField.text = "";
        }

        private void ShowLetter()
        {
            myInputField.text = myLetter;
        }
    }
}

