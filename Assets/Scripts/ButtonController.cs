using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public int id;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Awake()
    {
        KeyCode thisKeyCode;
        theSR = GetComponent<SpriteRenderer>();
        for (int i = 0; i < 4; i++)
        {
            if (i == id)
            {
                thisKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("key" + id));
                keyToPress = thisKeyCode;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            theSR.sprite = pressedImage;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
        }
    }
}
