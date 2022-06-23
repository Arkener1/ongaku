using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;
using System;
using System.Text.RegularExpressions;

public class TextToMap : MonoBehaviour
{
    string[] mapa;
    string Audio;
    float BPM;

    [HideInInspector] public string[] MusicMap;
    [HideInInspector] public AudioClip readClip;
    public AudioSource OrigenMusica;

    public BeatScroller gameplay;
    public GameObject[] Notas = new GameObject[4];

    public GameObject pool;

    public List<GameObject> NotasInstanciadas;
    public List<GameObject> NotasInstanciadas1;
    public List<GameObject> NotasInstanciadas2;
    public List<GameObject> NotasInstanciadas3;
    public List<GameObject> NotasInstanciadas4;

    int NoteLines;
    private void Awake()
    {
        mapa = File.ReadAllLines(PlayerPrefs.GetString("MapaCargado"));
        for (int i = 0; i < mapa.Length; i++)
        {
            if (mapa[i].Contains("AudioFilename: "))
            {
                Audio = mapa[3].Remove(0, 15);
                Debug.Log(mapa[3]);
            }
            else if (mapa[i].Contains("[TimingPoints]"))
            {
                string[] timming = new string[8];
                timming = mapa[i + 1].Split(char.Parse(","));

                BPM = 1 / float.Parse(timming[1], CultureInfo.InvariantCulture) * 1000 * 60;
                gameplay.bpm = BPM;
            }
            else if (mapa[i].Contains("[HitObjects]"))
            {
                NoteLines = i + 1;
            }
        }

        for (int j = NoteLines; j < mapa.Length; j++)
        {
            GameObject addNote;
            string[] note = new string[6];
            note = mapa[j].Split(char.Parse(","));
            switch (note[0])
            {
                case "64":
                    addNote = Instantiate(Notas[0], new Vector3(-1.517f, float.Parse(note[2]) / 1000, 0), transform.rotation, pool.transform);
                    NotasInstanciadas.Add(addNote);
                    NotasInstanciadas1.Add(addNote);
                    break;
                case "192":

                    addNote = Instantiate(Notas[1], new Vector3(-0.51f, float.Parse(note[2]) / 1000, 0), transform.rotation, pool.transform);
                    NotasInstanciadas.Add(addNote);
                    NotasInstanciadas2.Add(addNote);
                    break;
                case "320":

                    addNote = Instantiate(Notas[2], new Vector3(0.51f, float.Parse(note[2]) / 1000, 0), transform.rotation, pool.transform);
                    NotasInstanciadas.Add(addNote);
                    NotasInstanciadas3.Add(addNote);
                    break;
                case "448":

                    addNote = Instantiate(Notas[3], new Vector3(1.517f, float.Parse(note[2]) / 1000, 0), transform.rotation, pool.transform);
                    NotasInstanciadas.Add(addNote);
                    NotasInstanciadas4.Add(addNote);
                    break;
            }
        }
        MusicMap = Directory.GetFiles(PlayerPrefs.GetString("Folder"));
        
        for (int i = 0; i < MusicMap.Length; i++)
        {
            WWW www = new WWW(MusicMap[i]);
            if (MusicMap[i].Contains(Audio))
            {
                readClip = NAudioPlayer.FromMp3Data(www.bytes);
                OrigenMusica.clip = readClip;
            }
        }

        PlayerPrefs.DeleteAll();
        //Debug.Log(MusicMap);
    }
}
