using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class changeButton : MonoBehaviour
{
    private Toggle button;
    public TMP_Text keytext;
    public int buttonID = 0;

    private void Start()
    {
        button = GetComponent<Toggle>();
    }

    private void Update()
    {
        if (button.isOn)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    keytext.text = vKey.ToString();
                    button.isOn = false;
                    PlayerPrefs.SetString("key" + (buttonID), vKey.ToString());
                    EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
                }
            }
        }
    }
}
