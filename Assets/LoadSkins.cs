using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System.Globalization;

public class LoadSkins : MonoBehaviour
{
    public GameObject prefabSkin;

    public static LoadSkins current;
    //public string[] skinList;
    //public string[] readSkin;

    //private DirectoryInfo dir;

    public int id = 0;

    public Transform contenido;

    public Sprite[] preview1, preview2;

    //public string[,] dataSkin = new string[10000, 30];

    // Start is called before the first frame update
    void Start()
    {
        id = preview1.Length;
        /*dir = new DirectoryInfo(Application.dataPath + @"\Resources");
        skinList = Directory.GetDirectories(Application.dataPath + @"\Resources"); //Lectura de la carpeta Skin (se ignora los .meta)
        DirectoryInfo[] info = dir.GetDirectories();*/
        /*for (int i = 0; i < skinList.Length; i++) //id como carpeta
        {
            readSkin = Directory.GetFiles(skinList[i]); //Lectura de archivos del skin

            for (int j = 0; j < readSkin.Length; j++)
            {
                if ((readSkin[j].Contains(".jpg") || readSkin[j].Contains(".png")) && !readSkin[j].Contains(".meta")) //Se buscan los jpg o png del skin
                {
                    Debug.Log(readSkin[j]);
                    var preview = (Sprite)AssetDatabase.LoadAssetAtPath(readSkin[j], typeof(Sprite));
                    Debug.Log(preview);

                    findPreview[previewIndice] = preview; //Se guarda la imagen y avanzamos
                    previewIndice++;

                    dataSkin[i, id] = readSkin[j]; //Se gaurda el I de la carpeta y la ID de cada imagen cargada
                    id++;
                }

                //------------------ Escritura de titulo e impresion de preview ---------------------------
                GameObject obj1 = Instantiate(prefabSkin, contenido);

                obj1.transform.GetChild(0).GetComponent<TMP_Text>().text = info[i].Name;
                obj1.transform.GetChild(1).GetComponent<SkinOnClick>().id = i;
                obj1.transform.GetChild(2).GetComponent<Image>().sprite = findPreview[0];
                obj1.transform.GetChild(3).GetComponent<Image>().sprite = findPreview[1];
            }
            id = 0;
        }*/
        for (int i = 0; i < id; i++)
        {
            GameObject obj1 = Instantiate(prefabSkin, contenido);

            obj1.transform.GetChild(0).GetComponent<TMP_Text>().text = "Skin "+ (i + 1);
            obj1.transform.GetChild(1).GetComponent<SkinOnClick>().id = i;
            obj1.transform.GetChild(2).GetComponent<Image>().sprite = preview1[i];
            obj1.transform.GetChild(3).GetComponent<Image>().sprite = preview2[i];
        }

    }
}
