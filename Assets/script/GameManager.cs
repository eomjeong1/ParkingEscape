using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animation anim;
    
    public AudioSource Hurry;
    public AudioSource BGM;
    public Text Stnum;
    public float LimitTime;
    public Text text_Timer;
    public GameObject player;
    public Button Retry, Main, Next;
    public Image GO, TO, SC;
    public bool isClear;

    private bool IsHurried = false;

    void Start()
    {
        Stnum.text = "Stage 1";
        BGM.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        
        if (isClear == true)
        {
            
            StageClear();
        }


        if (isClear == false && player != null)
        {
            LimitTime -= Time.deltaTime;
            text_Timer.text = "���� �ð� : " + Mathf.Round(LimitTime);
            if (LimitTime <= 10)
            {
                if (IsHurried == false)
                {
                    IsHurried = true;
                    
                    Debug.Log("hurryup");
                    HurryUp();
                }
                
                if (LimitTime <= 0)
                {
                    text_Timer.text = "���� �ð� : 0";
                    Timeover();
                    BGM.Stop();


                }
            }
            
        }
    }
    public void GameRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Timeover()
    {
        TO.gameObject.SetActive(true);       
        Destroy(player);
        Retry.gameObject.SetActive(true);
        Main.gameObject.SetActive(true);


    }
    public void Gameover()
    {
        GO.gameObject.SetActive(true);
        Destroy(player);
        Retry.gameObject.SetActive(true);
        Main.gameObject.SetActive(true);

    }
    public void StageClear()
    {
        SC.gameObject.SetActive(true);       
        Destroy(player);
        Next.gameObject.SetActive(true);
        Main.gameObject.SetActive(true);
        Retry.gameObject.SetActive(true);
        BGM.Stop();
    }
    public void NextStage1()
    {
        SceneManager.LoadScene("Park Stage2");
    }
    public void NextStage2()
    {
        SceneManager.LoadScene("Park Stage3");
    }
    public void NextStage3()
    {
        SceneManager.LoadScene("Park Stage4");
    }
    public void NextStage4()
    {
        SceneManager.LoadScene("Park Stage4");
    }
    public void Back()
    {
        SceneManager.LoadScene("Parking Main");
    }
    public void HurryUp()
    {
        Hurry.Play();
        Debug.Log("hurryup?");
        anim.Play();
        Debug.Log("......");
    }

}

