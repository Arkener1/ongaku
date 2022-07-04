using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public AudioSource beatSfx;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 2000;
    public int scorePerGoodNote = 2500;
    public int scorePerPerfectNote = 3000;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;
    public GameObject f3f4;

    public GameObject[] keys;

    public GameObject[] buttons;

    private KeyCode[] keysDetect = new KeyCode[4];

    public float totalNotes;
    public float NormalHits;
    public float GoodHits;
    public float PerfectHits;
    public float MissedHits;

    public int SkinId;

    public GameObject resultsScreen;
    public TextToMap mapa;

    public int indiceNota1 = 0;
    public int indiceNota2 = 0;
    public int indiceNota3 = 0;
    public int indiceNota4 = 0;

    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect, pressedEffect;

    public Sprite[] p1, p2, p3, p4;


    private void Awake()
    {
        SkinId = PlayerPrefs.GetInt("Skin");
        keys[0].GetComponent<SpriteRenderer>().sprite = p1[SkinId];
        keys[2].GetComponent<SpriteRenderer>().sprite = p2[SkinId];
        keys[3].GetComponent<SpriteRenderer>().sprite = p3[SkinId];
        keys[1].GetComponent<SpriteRenderer>().sprite = p4[SkinId];

        
    }

    // Start is called before the first frame update
    void Start()
    {
        keysDetect[0] = buttons[0].GetComponent<ButtonController>().keyToPress;
        keysDetect[1] = buttons[1].GetComponent<ButtonController>().keyToPress;
        keysDetect[2] = buttons[2].GetComponent<ButtonController>().keyToPress;
        keysDetect[3] = buttons[3].GetComponent<ButtonController>().keyToPress;
        instance = this;
        currentMultiplier = 1;
        totalNotes = ((FindObjectsOfType<NoteObject>().Length));
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                scoreText.text = "0";
                scoreText.alignment = TextAnchor.MiddleRight;
                scoreText.rectTransform.anchoredPosition = new Vector2(652f, 496f);
                scoreText.fontSize = 60;
                f3f4.SetActive(false);
                startPlaying = true;
                theBS.hasStarted = true;
                theMusic.Play();
            }
            
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                theMusic.Stop();
                startPlaying = false;
                theBS.hasStarted = false;
                theBS.gameObject.SetActive(false);
            }
            if (!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);
                normalsText.text = "" + NormalHits;
                goodsText.text = "" + GoodHits;
                perfectsText.text = "" + PerfectHits;
                missesText.text = "" + MissedHits;

                float totalHits = NormalHits + GoodHits + PerfectHits;
                float percentHit = (totalHits / totalNotes) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankVal = "F";

                if (percentHit >= 60 && percentHit < 65)
                {
                    rankVal = "D";
                }

                else if (percentHit >= 60 && percentHit < 70)
                {
                    rankVal = "C";
                }

                else if (percentHit >= 70 && percentHit < 80)
                {
                    rankVal = "B";
                }

                else if (percentHit >= 80 && percentHit < 95)
                {
                    rankVal = "A";
                }

                else if (percentHit >= 95)
                {
                    rankVal = "S";
                }
                rankText.text = rankVal;
                finalScoreText.text = currentScore.ToString();
            }

            if (Input.GetKeyDown(keysDetect[0]))
            {
                

                if (Mathf.Abs(mapa.NotasInstanciadas1[indiceNota1].transform.position.y) <= 0.9f)
                {
                    instance.PerfectHit();
                    perfectEffect.SetActive(true);
                    mapa.NotasInstanciadas1[indiceNota1].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota1++;
                }

                else if (Mathf.Abs(mapa.NotasInstanciadas1[indiceNota1].transform.position.y) <= 1.3f)
                {
                    instance.GoodHit();
                    goodEffect.SetActive(true);
                    mapa.NotasInstanciadas1[indiceNota1].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota1++;
                }

                else if (Mathf.Abs(mapa.NotasInstanciadas1[indiceNota1].transform.position.y) <= 1.7f)
                {
                    instance.NormalHit();
                    hitEffect.SetActive(true);
                    mapa.NotasInstanciadas1[indiceNota1].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota1++;
                }

            }

            if (Input.GetKeyDown(keysDetect[1]))
            {
                

                if (Mathf.Abs(mapa.NotasInstanciadas2[indiceNota2].transform.position.y) <= 0.9f)
                {
                    instance.PerfectHit();
                    perfectEffect.SetActive(true);
                    mapa.NotasInstanciadas2[indiceNota2].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota2++;
                }

                else if (Mathf.Abs(mapa.NotasInstanciadas2[indiceNota2].transform.position.y) <= 1.3f)
                {
                    instance.GoodHit();
                    goodEffect.SetActive(true);
                    mapa.NotasInstanciadas2[indiceNota2].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota2++;
                }

                if (Mathf.Abs(mapa.NotasInstanciadas2[indiceNota2].transform.position.y) <= 1.7f)
                {
                    instance.NormalHit();
                    hitEffect.SetActive(true);
                    mapa.NotasInstanciadas2[indiceNota2].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota2++;
                }

            }

            if (Input.GetKeyDown(keysDetect[2]))
            {
                if (Mathf.Abs(mapa.NotasInstanciadas3[indiceNota3].transform.position.y) <= 0.9f)
                {
                    instance.PerfectHit();
                    perfectEffect.SetActive(true);
                    mapa.NotasInstanciadas3[indiceNota3].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota3++;
                }

                else if (Mathf.Abs(mapa.NotasInstanciadas3[indiceNota3].transform.position.y) <= 1.3f)
                {
                    instance.GoodHit();
                    goodEffect.SetActive(true);
                    mapa.NotasInstanciadas3[indiceNota3].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota3++;
                }

                if (Mathf.Abs(mapa.NotasInstanciadas3[indiceNota3].transform.position.y) <= 1.7f)
                {
                    instance.NormalHit();
                    hitEffect.SetActive(true);
                    mapa.NotasInstanciadas3[indiceNota3].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota3++;
                }
            }

            if (Input.GetKeyDown(keysDetect[3]))
            {
                if (Mathf.Abs(mapa.NotasInstanciadas4[indiceNota4].transform.position.y) <= 0.9)
                {
                    instance.PerfectHit();
                    perfectEffect.SetActive(true);
                    mapa.NotasInstanciadas4[indiceNota4].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota4++;
                }

                else if (Mathf.Abs(mapa.NotasInstanciadas4[indiceNota4].transform.position.y) <= 1.3f)
                {
                    instance.GoodHit();
                    goodEffect.SetActive(true);
                    mapa.NotasInstanciadas4[indiceNota4].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota4++;
                }

                else if (Mathf.Abs(mapa.NotasInstanciadas4[indiceNota4].transform.position.y) <= 1.7)
                {
                    instance.NormalHit();
                    hitEffect.SetActive(true);
                    mapa.NotasInstanciadas4[indiceNota4].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota4++;
                }
            }

            if (mapa.NotasInstanciadas1[indiceNota1].transform.position.y < -1.70f)
            {
                instance.NoteMissed();
                missEffect.SetActive(true);
                indiceNota1++;
            }

            if (mapa.NotasInstanciadas2[indiceNota2].transform.position.y < -1.70f)
            {
                instance.NoteMissed();
                missEffect.SetActive(true);
                indiceNota2++;
            }

            if (mapa.NotasInstanciadas3[indiceNota3].transform.position.y < -1.70f)
            {
                instance.NoteMissed();
                missEffect.SetActive(true);
                indiceNota3++;
            }

            if (mapa.NotasInstanciadas4[indiceNota4].transform.position.y < -1.70f)
            {
                instance.NoteMissed();
                missEffect.SetActive(true);
                indiceNota4++;
            }
        }
    }

    public void NoteHit()
    {
        //beatSfx.Play();
        multiplierTracker++;
        if ((currentMultiplier - 1) < multiplierThresholds.Length) 
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        scoreText.text = "" + currentScore;
        //multiText.text = "Score x" + currentMultiplier;  
    }

    public void NormalHit()
    {
        UnityEngine.Debug.Log("Normal Hit");
        hitEffect.GetComponent<EffectObject>().timer = 0;
        perfectEffect.SetActive(false);
        goodEffect.SetActive(false);
        missEffect.SetActive(false);
        currentScore += scorePerNote * currentMultiplier;
        NormalHits++;
        NoteHit();
    }

    public void GoodHit()
    {
        UnityEngine.Debug.Log("Good Hit");
        goodEffect.GetComponent<EffectObject>().timer = 0;
        hitEffect.SetActive(false);
        perfectEffect.SetActive(false);
        missEffect.SetActive(false);
        currentScore += scorePerGoodNote * currentMultiplier;
        GoodHits++;
        NoteHit();
    }

    public void PerfectHit()
    {
        UnityEngine.Debug.Log("Perfect Hit");
        perfectEffect.GetComponent<EffectObject>().timer = 0;
        hitEffect.SetActive(false);
        goodEffect.SetActive(false);
        missEffect.SetActive(false);
        currentScore += scorePerPerfectNote * currentMultiplier;
        PerfectHits++;
        NoteHit();
    }

    public void NoteMissed()
    {
        UnityEngine.Debug.Log("missed");
        MissedHits++;
        currentMultiplier = 1;
        multiplierTracker = 0;
        //multiText.text = "Score x" + currentMultiplier;

    }


}
    