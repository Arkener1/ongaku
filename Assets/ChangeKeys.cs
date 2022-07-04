using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeKeys : MonoBehaviour
{
    public TMP_Text[] keyTexts;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("key0") == "")
        {
            keyTexts[0].text = "V";
            keyTexts[1].text = "B";
            keyTexts[2].text = "N";
            keyTexts[3].text = "M";
        }
        else
        {
            keyTexts[0].text = PlayerPrefs.GetString("key0");
            keyTexts[1].text = PlayerPrefs.GetString("key1");
            keyTexts[2].text = PlayerPrefs.GetString("key2");
            keyTexts[3].text = PlayerPrefs.GetString("key3");
        }
    }

}
