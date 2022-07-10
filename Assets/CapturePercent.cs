using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapturePercent : MonoBehaviour
{
    public GameManager GM;
    public Text percent;
    void Update()
    {
        percent.text = GM.percentHit.ToString("F2") + "%";
        //percent.text = (Mathf.Floor((GM.percentHit * 100)) / 100).ToString() + "%";
    }
}
