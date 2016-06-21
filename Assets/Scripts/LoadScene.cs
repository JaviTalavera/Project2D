using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject LeftMenu;
    public GameObject RightMenu;
    public GameObject Previous;
    public GameObject Next;
    public int page;



    public void LoadSceneNumber(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoadLeftMenu()
    {
        MainMenu.SetActive(false);
        LeftMenu.SetActive(true);
    }

    public void LoadRightMenu()
    {
        MainMenu.SetActive(false);
        RightMenu.SetActive(true);
    }

    public void LoadMainMenu()
    {
        LeftMenu.SetActive(false);
        RightMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void LoadBestTimes(int level)
    {
        int i = 0;
        string sAuxBest;
        string sAuxBestTime;
        string sHighName;
        string sHighTime;
        string sLevel;
        TimeSpan time;

        if (level.Equals(1))
            Previous.SetActive(false);
        else
            Previous.SetActive(true);

        if (level.Equals(6))
            Next.SetActive(false);
        else
            Next.SetActive(true);

        sLevel = level.ToString();
        GameObject.Find("Level").GetComponent<Text>().text = "Nivel " + sLevel;

        for (i=1; i<=10; i++)
        {
            sAuxBest = ("Best" + i.ToString());
            sAuxBestTime = ("BestTime" + i.ToString());
            sHighName = ("HighScoreLevelName" + sLevel + i.ToString());
            sHighTime = ("HighScoreLevelTime" + sLevel + i.ToString());

            time = TimeSpan.FromSeconds(PlayerPrefs.GetFloat(sHighTime, 0));
           
            GameObject.Find(sAuxBest).GetComponent<Text>().text = PlayerPrefs.GetString(sHighName, "Bot");
            GameObject.Find(sAuxBestTime).GetComponent<Text>().text = string.Format("{0:D2}:{1:D2}.{2:D3}", time.Minutes, time.Seconds,time.Milliseconds);
        } 
    }

    void Start()
    {
        /* switch (SceneManager.GetActiveScene().name)
         {
             case "HighScores": 
                 LoadBestTimes(1);
                 break;
             case "Menu":
                 LoadMainMenu();
                 break;
         }*/
    }

    public void startGame ()
    {
        
    }

    public void NextHighScoresPage()
    {
        int level;

        level = int.Parse(GameObject.Find("Level").GetComponent<Text>().text.Substring(6));
        level++;
        LoadBestTimes(level);
    }

    public void PreviousHighScoresPage()
    {
        int level;

        level = int.Parse(GameObject.Find("Level").GetComponent<Text>().text.Substring(6));
        level--;
        LoadBestTimes(level);
    }
}