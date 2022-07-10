using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect, pressedEffect;

    public float tempo;

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
    }
}
