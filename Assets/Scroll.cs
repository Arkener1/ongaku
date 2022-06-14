using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scaleY;

    // Start is called before the first frame update
    void Start()
    {
        scaleY = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            scaleY -= 4f;
            transform.localScale = new Vector3(1, scaleY, 1);
            transform.position -= new Vector3(0f, (scaleY) * 204 * Time.deltaTime, 0f);
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            scaleY += 4f;
            transform.localScale = new Vector3(1, scaleY, 1);
            transform.position += new Vector3(0f, (scaleY * 2) * 204 * Time.deltaTime, 0f);
        }
    }
}
