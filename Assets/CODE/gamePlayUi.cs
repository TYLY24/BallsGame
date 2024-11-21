using System;
using System.Collections;
using System.Collections.Generic;
using LeaderboardCreator;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class gamePlayUi : MonoBehaviour
{
    [SerializeField] LeaderBoardLnS leaderBoardLnS;
    [SerializeField]Text Point;
    [SerializeField] BallControl ballControls;
    [SerializeField] GameObject PauseUi,GamePlay;
    [SerializeField] TMP_InputField YN;
     Color colors;
    [SerializeField] Button Help;
    Image buttonImage;
    bool Helped=false;
    // Start is called before the first frame update
    void Start()
    {
        
        buttonImage = Help.GetComponent<Image>();
      //  colors=buttonImage.color;
    }

    public void Helping()
    {
        if(!Helped)
        {
             DestroyBall(3);
            buttonImage.color=Color.gray;
             ballControls.HaveBall=false;
            Helped=true;
        }
        
    }
    public void GameOverOK()
    {
        Time.timeScale = 1;
        String name=YN.text;
        leaderBoardLnS.UpEntry(name,ballControls.Points);
         
    }
    // Update is called once per frame
    void DestroyBall(int BallNum)
    {
        for (int i=1;i<=BallNum;i++)
            {
                GameObject[] Ball=GameObject.FindGameObjectsWithTag(i.ToString());
                if(Ball!=null)
                for(int ii=0;ii<Ball.Length;ii++)
                {
                    Destroy(Ball[ii]);
                }
            }
    }
    public void Pause()
    {
        PauseUi.SetActive(true);
        Time.timeScale = 0;
    }
    public void UnPause()
    {
        PauseUi.SetActive(false);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Time.timeScale = 1;
        ballControls.Gameover=true;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        DestroyBall(11);
        ballControls.Points=0;
        Helped=false;
         buttonImage.color=Color.white;
         ballControls.HaveBall=false;
        PauseUi.SetActive(false);
    }
    void Update()
    {
        Point.text=ballControls.Points.ToString();
    }
}
