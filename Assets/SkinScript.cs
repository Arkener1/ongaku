using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SkinScript : MonoBehaviour
{
    public LoadSkins cargarSkin;
    public void playSkin(int id)
    {
        //PlayerPrefs.SetString("FolderSkin", cargarSkin.skinList[id]);
        PlayerPrefs.SetInt("Skin", id);
        SceneManager.LoadScene(0);
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
