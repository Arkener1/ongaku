using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;

public class BeatScroller : MonoBehaviour
{
    

    [HideInInspector] public bool hasStarted;

    //public float scaleY;

    //public float distanciaY, distanciaY2, distanciaYFinal;
    [Header("Parametros Usuario")]
    public float bpm;
    public float Offset;
    public float constantSpeed;
    //public float BeatsAdelantados;

    [Header("Parametros Estaticos Cancion")]
    public float segundosPorBeat;
    public float TiempoInicioCancion;
    public float TiempoTotalCancion;
    public float beatTempo;

    [Header("Parametros Dinamicos Cancion")]
    public float songPosition;
    public float songPositionInBeats;
    public float positionFirstSnap;
    public float deltaTime = 0;
    public float SnapDistance, SnapDistanceFuturo;
    private float LastSongTime = 0;


    public GameObject snap;
    public TextToMap map;
    public AudioSource audioSource;
    [HideInInspector] public List<GameObject> SnapList;

    //public Transform pivote1, pivote2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj1;
        beatTempo = bpm;
        beatTempo = beatTempo / 60f;
        segundosPorBeat = 60 / bpm; //metronomo
        TiempoTotalCancion = Mathf.Round(audioSource.clip.length);
        //scaleY = transform.localScale.y;
        //distanciaY = Mathf.Abs(pivote1.position.y - pivote2.position.y);

        for (int i = 0; i < TiempoTotalCancion; i++)
        {
            obj1 = Instantiate(snap, new Vector3(0, (i * segundosPorBeat) + Offset, 0), transform.rotation);
            SnapList.Add(obj1);
            obj1.transform.parent = gameObject.transform;
        }

        for (int j = 0; j < map.NotasInstanciadas.Count; j++)
        {
            map.NotasInstanciadas[j].transform.position = new Vector3(map.NotasInstanciadas[j].transform.position.x, map.NotasInstanciadas[j].transform.position.y + Offset, 0f);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!hasStarted)
        {
            if (Input.anyKey)
            {
                hasStarted = true;
                TiempoInicioCancion = (float)AudioSettings.dspTime;
                SnapDistance = segundosPorBeat;
            }
        }
        else
        {
            songPosition = (float)(AudioSettings.dspTime - TiempoInicioCancion - Offset);
            songPositionInBeats = songPosition / segundosPorBeat;
            deltaTime = audioSource.time - LastSongTime;
            LastSongTime = audioSource.time;
            positionFirstSnap = SnapList[0].transform.position.y;

            //transform.position = Vector2.Lerp(new Vector2(0, Offset), new Vector2(0, TiempoTotalCancion), (TiempoTotalCancion / segundosPorBeat) + Mathf.Floor((songPosition - TiempoTotalCancion)));

            transform.position -= new Vector3(0f, constantSpeed * Time.fixedDeltaTime, 0f); //Velocidad del snap

            //transform.position = new Vector3(0,(TiempoTotalCancion / segundosPorBeat) + Mathf.Floor((songPosition - TiempoTotalCancion) / 4) * Time.deltaTime, 0);
            
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            float posicionSnapReasignar;
            float posicionNotaReasignar;
            constantSpeed = Mathf.Clamp(constantSpeed - 1, 1, 20000);
            if (constantSpeed > 1)
            {
                for (int i = 0; i < SnapList.Count; i++)
                {
                    posicionSnapReasignar = (SnapList[i].transform.position.y * constantSpeed) / (constantSpeed + 1);
                    SnapList[i].transform.position = new Vector3(0, posicionSnapReasignar, 0);
                }
                for (int i = 0; i < map.NotasInstanciadas.Count; i++)
                {
                    posicionNotaReasignar = (map.NotasInstanciadas[i].transform.position.y * constantSpeed) / (constantSpeed + 1);
                    map.NotasInstanciadas[i].transform.position = new Vector3(map.NotasInstanciadas[i].transform.position.x, posicionNotaReasignar, 0);
                }
                SnapDistanceFuturo = Mathf.Abs(SnapList[0].transform.position.y - SnapList[1].transform.position.y);
                SnapDistance = (SnapDistance * constantSpeed) / (constantSpeed + 1);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            float posicionSnapReasignar;
            float posicionNotaReasignar;
            constantSpeed = Mathf.Clamp(constantSpeed + 1, 1, 20000);
            if (constantSpeed > 0)
            {
                for (int i = 0; i < SnapList.Count; i++)
                {
                    posicionSnapReasignar = (SnapList[i].transform.position.y * constantSpeed) / (constantSpeed - 1);
                    SnapList[i].transform.position = new Vector3(0, posicionSnapReasignar, 0);
                }
                for (int i = 0; i < map.NotasInstanciadas.Count; i++)
                {
                    posicionNotaReasignar = (map.NotasInstanciadas[i].transform.position.y * constantSpeed) / (constantSpeed - 1);
                    map.NotasInstanciadas[i].transform.position = new Vector3(map.NotasInstanciadas[i].transform.position.x, posicionNotaReasignar, 0);
                }
                Debug.Log(map.NotasInstanciadas.Count);
                SnapDistanceFuturo = Mathf.Abs(SnapList[0].transform.position.y - SnapList[1].transform.position.y);
                SnapDistance = (SnapDistance * constantSpeed) / (constantSpeed - 1);
            }
            
        }
    }
}
