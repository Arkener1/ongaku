using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinOnClick : MonoBehaviour
{
    public SkinScript click;
    public int id = 0;
    public Button boton;

    // Start is called before the first frame update
    void Start()
    {
        click = FindObjectOfType<SkinScript>();
        boton = GetComponent<Button>();
        boton.onClick.AddListener(delegate { click.playSkin(id); });
    }
}
