using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupText : MonoBehaviour
{
    public TMP_Text Popuptext;

    public GameObject popup;

    float seconds = 10;

    public void Popup(string text)
    {
        popup.SetActive(true);

        Popuptext.text = text;

        float zerotime =   seconds - Time.deltaTime;

        if (zerotime == 0)
        {
            this.popup.SetActive(false);
        }
    }
}
