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

    public double currentScore;
    public double scorePerNote;
    public double scorePerGoodNote;
    public double scorePerPerfectNote;

    private double unidadScore;

    //public int currentMultiplier;
    //public int multiplierTracker;
    //public int[] multiplierThresholds;

    public Text scoreText;
    public Text accText;
    public GameObject f3f4;

    public GameObject[] keys;

    public GameObject[] buttons;

    private KeyCode[] keysDetect = new KeyCode[4];

    public double totalNotes;
    public float NormalHits = 0;
    public float GoodHits = 0;
    public float PerfectHits = 0;
    public float MissedHits = 0;

    public float percentHit = 0;
    public float totalHits;

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
        //currentMultiplier = 1;
        totalNotes = FindObjectsOfType<NoteObject>().Length;

        unidadScore = (100000f / totalNotes);

        scorePerPerfectNote = unidadScore;
        scorePerGoodNote = (unidadScore * 0.80f);
        scorePerNote = (unidadScore * 0.50f);

        Debug.Log(mapa.NotasInstanciadas1.Count);
        Debug.Log(mapa.NotasInstanciadas2.Count);
        Debug.Log(mapa.NotasInstanciadas3.Count);
        Debug.Log(mapa.NotasInstanciadas4.Count);
    }

    // Update is called once per frame
    void Update()
    {

        if (!startPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                scoreText.text = "0";
                accText.gameObject.SetActive(true);
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
            totalHits = NormalHits + GoodHits + PerfectHits + MissedHits;

            percentHit =(NormalHits * 0.50f + GoodHits * 0.80f + PerfectHits * 1f) / (totalHits) * 100;

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

                PlayerPrefs.SetInt("ScrollSpeed", theBS.constantSpeed);


                percentHitText.text = percentHit.ToString("F2") + "%";

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

                else if (percentHit >= 95 && percentHit < 100)
                {
                    rankVal = "S";
                }

                else if (percentHit >= 100)
                {
                    rankVal = "SS";
                }
                rankText.text = rankVal;
                finalScoreText.text = currentScore.ToString("F0");
            }
            else
            {
                if (indiceNota1 < mapa.NotasInstanciadas1.Count)
                {
                    if (Input.GetKeyDown(keysDetect[0]) && indiceNota1 < mapa.NotasInstanciadas1.Count)
                    {
                        if (Mathf.Abs(mapa.NotasInstanciadas1[indiceNota1].transform.position.y) <= 0.9f)
                        {
                            instance.PerfectHit();
                            perfectEffect.SetActive(true);
                            mapa.NotasInstanciadas1[indiceNota1].SetActive(false);
                            //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                            if (indiceNota1 < mapa.NotasInstanciadas1.Count)
                            {
                                indiceNota1++;
                            }
                        }

                        else if (Mathf.Abs(mapa.NotasInstanciadas1[indiceNota1].transform.position.y) <= 1.3f)
                        {
                            instance.GoodHit();
                            goodEffect.SetActive(true);
                            mapa.NotasInstanciadas1[indiceNota1].SetActive(false);
                            //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                            if (indiceNota1 < mapa.NotasInstanciadas1.Count)
                            {
                                indiceNota1++;
                            }
                        }

                        else if (Mathf.Abs(mapa.NotasInstanciadas1[indiceNota1].transform.position.y) <= 1.7f)
                        {
                            instance.NormalHit();
                            hitEffect.SetActive(true);
                            mapa.NotasInstanciadas1[indiceNota1].SetActive(false);
                            //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                            if (indiceNota1 < mapa.NotasInstanciadas1.Count)
                            {
                                indiceNota1++;
                            }
                        }
                    }

                    if (mapa.NotasInstanciadas1[indiceNota1].transform.position.y < -1.70f && indiceNota1 < mapa.NotasInstanciadas1.Count)
                    {
                        instance.NoteMissed();
                        missEffect.SetActive(true);
                        indiceNota1++;
                    }
                }

                if (indiceNota2 < mapa.NotasInstanciadas2.Count)
                {
                    if (Input.GetKeyDown(keysDetect[1]) && indiceNota2 < mapa.NotasInstanciadas2.Count)
                    {
                        if (Mathf.Abs(mapa.NotasInstanciadas2[indiceNota2].transform.position.y) <= 0.9f)
                        {
                            instance.PerfectHit();
                            perfectEffect.SetActive(true);
                            mapa.NotasInstanciadas2[indiceNota2].SetActive(false);
                            //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                            if (indiceNota2 < mapa.NotasInstanciadas2.Count)
                            {
                                indiceNota2++;
                            }
                        }

                        else if (Mathf.Abs(mapa.NotasInstanciadas2[indiceNota2].transform.position.y) <= 1.3f)
                        {
                            instance.GoodHit();
                            goodEffect.SetActive(true);
                            mapa.NotasInstanciadas2[indiceNota2].SetActive(false);
                            //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                            if (indiceNota2 < mapa.NotasInstanciadas2.Count)
                            {
                                indiceNota2++;
                            }
                        }

                        if (Mathf.Abs(mapa.NotasInstanciadas2[indiceNota2].transform.position.y) <= 1.7f)
                        {
                            instance.NormalHit();
                            hitEffect.SetActive(true);
                            mapa.NotasInstanciadas2[indiceNota2].SetActive(false);
                            //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                            if (indiceNota2 < mapa.NotasInstanciadas2.Count)
                            {
                                indiceNota2++;
                            }
                        }
                    }

                    if (mapa.NotasInstanciadas2[indiceNota2].transform.position.y < -1.70f && indiceNota2 < mapa.NotasInstanciadas2.Count)
                    {
                        instance.NoteMissed();
                        missEffect.SetActive(true);
                        indiceNota2++;
                    }
                }

                if (indiceNota3 < mapa.NotasInstanciadas3.Count)
                {
                    if (Input.GetKeyDown(keysDetect[2]) && indiceNota3 < mapa.NotasInstanciadas3.Count)
                    {
                        if (Mathf.Abs(mapa.NotasInstanciadas3[indiceNota3].transform.position.y) <= 0.9f)
                        {
                            instance.PerfectHit();
                            perfectEffect.SetActive(true);
                            mapa.NotasInstanciadas3[indiceNota3].SetActive(false);
                            //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                            if (indiceNota3 < mapa.NotasInstanciadas3.Count)
                            {
                                indiceNota3++;
                            }
                        }

                        else if (Mathf.Abs(mapa.NotasInstanciadas3[indiceNota3].transform.position.y) <= 1.3f)
                        {
                            instance.GoodHit();
                            goodEffect.SetActive(true);
                            mapa.NotasInstanciadas3[indiceNota3].SetActive(false);
                            //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                            if (indiceNota3 < mapa.NotasInstanciadas3.Count)
                            {
                                indiceNota3++;
                            }
                        }

                        if (Mathf.Abs(mapa.NotasInstanciadas3[indiceNota3].transform.position.y) <= 1.7f)
                        {
                            instance.NormalHit();
                            hitEffect.SetActive(true);
                            mapa.NotasInstanciadas3[indiceNota3].SetActive(false);
                            //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                            if (indiceNota3 < mapa.NotasInstanciadas3.Count)
                            {
                                indiceNota3++;
                            }
                        }
                    }

                    if (mapa.NotasInstanciadas3[indiceNota3].transform.position.y < -1.70f && indiceNota3 < mapa.NotasInstanciadas3.Count)
                    {
                        instance.NoteMissed();
                        missEffect.SetActive(true);
                        indiceNota3++;
                    }
                }

                if (indiceNota4 < mapa.NotasInstanciadas4.Count)
                {
                    if (Input.GetKeyDown(keysDetect[3]) && indiceNota4 < mapa.NotasInstanciadas4.Count)
                    {
                        if (Mathf.Abs(mapa.NotasInstanciadas4[indiceNota4].transform.position.y) <= 0.9)
                        {
                            instance.PerfectHit();
                            perfectEffect.SetActive(true);
                            mapa.NotasInstanciadas4[indiceNota4].SetActive(false);
                            //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                            if (indiceNota4 < mapa.NotasInstanciadas4.Count)
                            {
                                indiceNota4++;
                            }
                        }

                        else if (Mathf.Abs(mapa.NotasInstanciadas4[indiceNota4].transform.position.y) <= 1.3f)
                        {
                            instance.GoodHit();
                            goodEffect.SetActive(true);
                            mapa.NotasInstanciadas4[indiceNota4].SetActive(false);
                            //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                            if (indiceNota4 < mapa.NotasInstanciadas4.Count)
                            {
                                indiceNota4++;
                            }
                        }

                        else if (Mathf.Abs(mapa.NotasInstanciadas4[indiceNota4].transform.position.y) <= 1.7)
                        {
                            instance.NormalHit();
                            hitEffect.SetActive(true);
                            mapa.NotasInstanciadas4[indiceNota4].SetActive(false);
                            //Instantiate(pressedEffect, transform.position, Quaternion.identity);
                            if (indiceNota4 < mapa.NotasInstanciadas4.Count)
                            {
                                indiceNota4++;
                            }
                        }
                    }

                    if (mapa.NotasInstanciadas4[indiceNota4].transform.position.y < -1.70f && indiceNota4 < mapa.NotasInstanciadas4.Count)
                    {
                        instance.NoteMissed();
                        missEffect.SetActive(true);
                        indiceNota4++;
                    }
                }
            }
        }
    }

    public void NoteHit()
    {
        scoreText.text = "" + currentScore.ToString("F0");
    }



    public void NormalHit()
    {
        UnityEngine.Debug.Log("Normal Hit");
        hitEffect.GetComponent<EffectObject>().timer = 0;
        perfectEffect.SetActive(false);
        goodEffect.SetActive(false);
        missEffect.SetActive(false);
        currentScore += scorePerNote;
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
        currentScore += scorePerGoodNote;
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
        Debug.Log(scorePerPerfectNote);
        currentScore += scorePerPerfectNote;
        PerfectHits++;
        NoteHit();
    }

    public void NoteMissed()
    {
        UnityEngine.Debug.Log("missed");
        MissedHits++;
        //currentMultiplier = 1;
        //multiplierTracker = 0;
        //multiText.text = "Score x" + currentMultiplier;

    }


}
    