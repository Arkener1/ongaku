using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonScript : MonoBehaviour
{
    public LoadMaps cargarMapa;
    public Text Scroll;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("ScrollSpeed") == 0)
        {
            Scroll.text = "1";
        }
        else
        {
            Scroll.text = PlayerPrefs.GetInt("ScrollSpeed").ToString();
        }
        
    }

    public void playSong(int id, int idDiff)
    {
        PlayerPrefs.SetString("Folder", cargarMapa.mapList[id]);
        PlayerPrefs.SetString("MapaCargado", cargarMapa.dataMap[id,idDiff]);
        PlayerPrefs.SetInt("ScrollSpeed", int.Parse(Scroll.text));
        SceneManager.LoadScene(3);
    }

    public void backButton()
    {
        SceneManager.LoadScene(0);
    }
    public void instructButton()
    {
        SceneManager.LoadScene(2);
    }

    public void backScroll()
    {
        Scroll.text = Mathf.Clamp(int.Parse(Scroll.text) - 1, 1, 999).ToString();
    }

    public void forwardScroll()
    {
        Scroll.text = Mathf.Clamp(int.Parse(Scroll.text) + 1, 1, 999).ToString();
    }
}
