using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    public float lifeTime = 1f;

    public float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifeTime)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
    }

    private void OnDisable()
    {
        timer = 0;
    }
}
