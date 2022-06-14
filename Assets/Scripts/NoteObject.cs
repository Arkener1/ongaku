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
       /* 
        if (Input.GetKeyDown(keyToPress))
        {

            if (Mathf.Abs(transform.position.y) > 0.30 && Mathf.Abs(transform.position.y) <= 0.80)
            {
                GameManager.instance.NormalHit();
                Instantiate(hitEffect, hitEffect.transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                Instantiate(pressedEffect, transform.position, Quaternion.identity);
            }

            else if (Mathf.Abs(transform.position.y) > 0.18 && Mathf.Abs(transform.position.y) <= 0.30)
            {
                GameManager.instance.GoodHit();
                Instantiate(goodEffect, goodEffect.transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                Instantiate(pressedEffect, transform.position, Quaternion.identity);
            }

            else if (Mathf.Abs(transform.position.y) <= 0.18)
            {
                GameManager.instance.PerfectHit();
                Instantiate(perfectEffect, perfectEffect.transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                Instantiate(pressedEffect, transform.position, Quaternion.identity);
            }

        }
*/
        
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();
            Instantiate(missEffect, missEffect.transform.position, Quaternion.identity);
        }
    }*/
}
