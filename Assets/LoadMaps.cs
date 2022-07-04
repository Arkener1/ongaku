using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class LoadMaps : MonoBehaviour
{
    public GameObject prefabMap;
    public string[] mapList;
    public string[] readMap;
    public string title;
    public string diff;
    public string keys;

    public string[] mapa;

    public int id = 0;

    public Transform contenido;

    public string[,] dataMap = new string[10000,30];

    // Start is called before the first frame update
    void Start()
    {
        mapList = Directory.GetDirectories(Application.dataPath + @"\Song"); //Lectura de la carpeta Song (se ignora los .meta)
        for (int i = 0; i < mapList.Length; i++) //id como carpeta
        {
            readMap = Directory.GetFiles(mapList[i]); //Lectura de documentos del mapa
            for (int j = 0; j < readMap.Length; j++)
            {
                if (readMap[j].Contains(".osu") && !readMap[j].Contains(".meta")) //Se busca la dificultad (documento .osu)
                {
                    mapa = File.ReadAllLines(readMap[j]); // Se lee el .osu
                    
                    for (int k = 0; k < mapa.Length; k++)
                    {
                        if (mapa[k].Contains("Title:")) //Titulo
                        {
                            title = mapa[k].Remove(0, 6);
                        }
                        else if (mapa[k].Contains("Version:")) //Dificultad
                        {
                            diff = mapa[k].Remove(0, 8);
                        }
                        else if (mapa[k].Contains("CircleSize:")) //verificar si el mapa es 4K
                        {
                            keys = mapa[k].Remove(0, 11);
                        }
                    }

                    if (keys.Contains("4")) 
                    {
                        //------------------ Escritura de titulo y dificultad ---------------------------
                        dataMap[i, id] = readMap[j];

                        GameObject obj1 = Instantiate(prefabMap, contenido);

                        obj1.transform.GetChild(0).GetComponent<TMP_Text>().text = title;
                        obj1.transform.GetChild(1).GetComponent<TMP_Text>().text = diff;
                        obj1.transform.GetChild(2).GetComponent<buttonOnClick>().id = i;
                        obj1.transform.GetChild(2).GetComponent<buttonOnClick>().idDiff = id;
                        id++;
                    }
                    
                }
            }
            id = 0;
        }
    }
}
