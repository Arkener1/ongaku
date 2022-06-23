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

    public float totalNotes;
    public float NormalHits;
    public float GoodHits;
    public float PerfectHits;
    public float MissedHits;

    public GameObject resultsScreen;
    public TextToMap mapa;

    public int indiceNota1 = 0;
    public int indiceNota2 = 0;
    public int indiceNota3 = 0;
    public int indiceNota4 = 0;

    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect, pressedEffect;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Press Any Key to Continue";
        
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
                startPlaying = true;
                theBS.hasStarted = true;
                theMusic.Play();
            }
        }
        else
        {
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

                if (percentHit >= 30)
                {
                    rankVal = "D";
                    if (currentScore >= 550000)
                    {
                        rankVal = "C";
                        if (currentScore >= 750000)
                        {
                            rankVal = "B";
                            if (currentScore >= 900000)
                            {
                                rankVal = "A";
                                if (currentScore >= 950000)
                                {
                                    rankVal = "S";
                                }
                            }
                        }
                    }
                }
                rankText.text = rankVal;
                finalScoreText.text = currentScore.ToString();
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                

                if (Mathf.Abs(mapa.NotasInstanciadas1[indiceNota1].transform.position.y) <= 0.4)
                {
                    instance.PerfectHit();
                    perfectEffect.SetActive(true);
                    mapa.NotasInstanciadas1[indiceNota1].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota1++;
                }

                else if (Mathf.Abs(mapa.NotasInstanciadas1[indiceNota1].transform.position.y) <= 0.7)
                {
                    instance.GoodHit();
                    goodEffect.SetActive(true);
                    mapa.NotasInstanciadas1[indiceNota1].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota1++;
                }

                else if (Mathf.Abs(mapa.NotasInstanciadas1[indiceNota1].transform.position.y) <= 1.50)
                {
                    instance.NormalHit();
                    hitEffect.SetActive(true);
                    mapa.NotasInstanciadas1[indiceNota1].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota1++;
                }

            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                

                if (Mathf.Abs(mapa.NotasInstanciadas2[indiceNota2].transform.position.y) <= 0.4)
                {
                    instance.PerfectHit();
                    perfectEffect.SetActive(true);
                    mapa.NotasInstanciadas2[indiceNota2].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota2++;
                }

                else if (Mathf.Abs(mapa.NotasInstanciadas2[indiceNota2].transform.position.y) <= 0.70)
                {
                    instance.GoodHit();
                    goodEffect.SetActive(true);
                    mapa.NotasInstanciadas2[indiceNota2].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota2++;
                }

                if (Mathf.Abs(mapa.NotasInstanciadas2[indiceNota2].transform.position.y) <= 1.50)
                {
                    instance.NormalHit();
                    hitEffect.SetActive(true);
                    mapa.NotasInstanciadas2[indiceNota2].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota2++;
                }

            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                if (Mathf.Abs(mapa.NotasInstanciadas3[indiceNota3].transform.position.y) <= 0.4)
                {
                    instance.PerfectHit();
                    perfectEffect.SetActive(true);
                    mapa.NotasInstanciadas3[indiceNota3].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota3++;
                }

                else if (Mathf.Abs(mapa.NotasInstanciadas3[indiceNota3].transform.position.y) <= 0.7)
                {
                    instance.GoodHit();
                    goodEffect.SetActive(true);
                    mapa.NotasInstanciadas3[indiceNota3].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota3++;
                }

                if (Mathf.Abs(mapa.NotasInstanciadas3[indiceNota3].transform.position.y) <= 1.50)
                {
                    instance.NormalHit();
                    hitEffect.SetActive(true);
                    mapa.NotasInstanciadas3[indiceNota3].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota3++;
                }
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                if (Mathf.Abs(mapa.NotasInstanciadas4[indiceNota4].transform.position.y) <= 0.4)
                {
                    instance.PerfectHit();
                    perfectEffect.SetActive(true);
                    mapa.NotasInstanciadas4[indiceNota4].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota4++;
                }

                else if (Mathf.Abs(mapa.NotasInstanciadas4[indiceNota4].transform.position.y) <= 0.7)
                {
                    instance.GoodHit();
                    goodEffect.SetActive(true);
                    mapa.NotasInstanciadas4[indiceNota4].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota4++;
                }

                else if (Mathf.Abs(mapa.NotasInstanciadas4[indiceNota4].transform.position.y) > 0.70 && Mathf.Abs(mapa.NotasInstanciadas4[indiceNota4].transform.position.y) <= 1.50)
                {
                    instance.NormalHit();
                    hitEffect.SetActive(true);
                    mapa.NotasInstanciadas4[indiceNota4].SetActive(false);
                    //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                    indiceNota4++;
                }
            }

            if (mapa.NotasInstanciadas1[indiceNota1].transform.position.y < -1.50f)
            {
                instance.NoteMissed();
                missEffect.SetActive(true);
                indiceNota1++;
            }

            if (mapa.NotasInstanciadas2[indiceNota2].transform.position.y < -1.50f)
            {
                instance.NoteMissed();
                missEffect.SetActive(true);
                indiceNota2++;
            }

            if (mapa.NotasInstanciadas3[indiceNota3].transform.position.y < -1.50f)
            {
                instance.NoteMissed();
                missEffect.SetActive(true);
                indiceNota3++;
            }

            if (mapa.NotasInstanciadas4[indiceNota4].transform.position.y < -1.50f)
            {
                instance.NoteMissed();
                missEffect.SetActive(true);
                indiceNota4++;
            }
        }
    }

    public void NoteHit()
    {
        beatSfx.Play();
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
        multiText.text = "Score x" + currentMultiplier;  
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
        multiText.text = "Score x" + currentMultiplier;

    }


}
    