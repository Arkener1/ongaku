using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class buttonScript : MonoBehaviour
{
    public LoadMaps cargarMapa;
    public void playSong(int id, int idDiff)
    {
        PlayerPrefs.SetString("Folder", cargarMapa.mapList[id]);
        PlayerPrefs.SetString("MapaCargado", cargarMapa.dataMap[id,idDiff]);
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
}
