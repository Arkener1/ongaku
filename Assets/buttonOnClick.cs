using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonOnClick : MonoBehaviour
{
    public buttonScript click;
    public int id = 0, idDiff;
    public Button boton;

    // Start is called before the first frame update
    void Start()
    {
        click = FindObjectOfType<buttonScript>();
        boton = GetComponent<Button>();
        boton.onClick.AddListener(delegate {click.playSong(id, idDiff);} );
    }

}
