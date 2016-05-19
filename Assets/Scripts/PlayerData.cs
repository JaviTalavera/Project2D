using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{
    public int LevelUnlocked;
    public int BallColor;
    public int Coins;
    public int CurrentLevel;
    public string CurrentTypeLevel;
    public string PlayerName;
    public int TimesPlayed;
    public int TimesPlayedMultiplayer;
    public int MultiplayerWins;
    public int MultiplayerKills;
    public int Deaths;
    public int Gems;
    public int Lifes;
    public int ResolutionWidth;
    public int ResolutionHeigth;
    public int FullScreen;
    public float MusicVolume;
    public float EffectsVolume;
    public AudioSource MainTheme;
    public List<int> WorldGems1;
    public List<int> WorldCoins1;
    public List<int> PlayerWorldGems1;
    public List<int> PlayerWorldCoins1;

    public static PlayerData Instance
    {
        get { return _instance ?? (_instance = new GameObject("PlayerDataObject").AddComponent<PlayerData>()); }
    }

    private static PlayerData _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        _instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        LoadPlayerData();
        if (FullScreen.Equals(1))
            Screen.SetResolution(ResolutionWidth, ResolutionHeigth, true);
        else
            Screen.SetResolution(ResolutionWidth, ResolutionHeigth, false);
    }

    public void NewLevelUnlocked(int level)
    {
        LevelUnlocked++;
    }

    public void LoadPlayerData()
    {
        string[] aux; 
        LevelUnlocked = PlayerPrefs.GetInt("LevelUnlocked", 1);
        if (LevelUnlocked < 1)
            LevelUnlocked = 1;

        BallColor = PlayerPrefs.GetInt("BallColor", 0);
        Coins = PlayerPrefs.GetInt("Coins", 0);
        CurrentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        CurrentTypeLevel = PlayerPrefs.GetString("CurrentTypeLevel", "");
        PlayerName = PlayerPrefs.GetString("PlayerName", "");
        TimesPlayed = PlayerPrefs.GetInt("TimesPlayed", 0);
        TimesPlayedMultiplayer = PlayerPrefs.GetInt("TimesPlayedMultiplayer", 0);
        MultiplayerWins = PlayerPrefs.GetInt("MultiplayerWins", 0);
        MultiplayerKills = PlayerPrefs.GetInt("MultiplayerKills", 0);
        Deaths = PlayerPrefs.GetInt("Deaths", 0);
        //Gems = PlayerPrefs.GetInt("Gems", 0);
        Gems = 0;
        Lifes = PlayerPrefs.GetInt("Lifes", 0);
        ResolutionHeigth = PlayerPrefs.GetInt("ResolutionHeigth", 800);
        ResolutionWidth = PlayerPrefs.GetInt("ResolutionWidth", 600);
        FullScreen = PlayerPrefs.GetInt("FullScreen", 0);
        EffectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 1);
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1);
        MainTheme.volume = MusicVolume;

        aux = (PlayerPrefs.GetString("WorldGems1", "15,10,10,10,10,5").Split(','));
        foreach (string saux in aux)
        {
            WorldGems1.Add(int.Parse(saux));
        }

        aux = (PlayerPrefs.GetString("PlayerWorldGems1", "0,0,0,0,0,0").Split(','));
        foreach (string saux in aux)
        {
            PlayerWorldGems1.Add(int.Parse(saux));
            Gems = Gems + int.Parse(saux);
        }

        aux = (PlayerPrefs.GetString("WorldCoins1", "1,1,1,1,1,1").Split(','));
        foreach (string saux in aux)
        {
            WorldCoins1.Add(int.Parse(saux));
        }

        aux = (PlayerPrefs.GetString("PlayerWorldCoins1", "0,0,0,0,0,0").Split(','));
        foreach (string saux in aux)
        {
            PlayerWorldCoins1.Add(int.Parse(saux));
            Coins = Coins + int.Parse(saux);
        }
    }

    public void setPlayerWorldGems()
    {
        string aux = "";
        int totalGems = 0; 
        foreach (int iaux in PlayerWorldGems1)
        {
            aux = aux + iaux.ToString() + ",";
            totalGems = totalGems + iaux; 
        }

        aux = aux.Substring(0, 11);
        PlayerPrefs.SetString("PlayerWorldGems1", aux);
        PlayerPrefs.SetInt("Gems", totalGems);
        Gems = totalGems;
        PlayerPrefs.Save();
    }

    public void setPlayerWorldCoins()
    {
        string aux = "";
        int totalCoins = 0;
        foreach (int iaux in PlayerWorldCoins1)
        {
            aux = aux + iaux.ToString() + ",";
            totalCoins = totalCoins + iaux;
        }
        aux = aux.Substring(0, 11);
        PlayerPrefs.SetString("PlayerWorldCoins1", aux);
        PlayerPrefs.SetInt("Coins", totalCoins);
        Coins = totalCoins;
        PlayerPrefs.Save();
    }


    public void setPlayerName(string name)
    {
        PlayerName = name;
        PlayerPrefs.SetString("PlayerName", PlayerName);
        PlayerPrefs.Save();
    }

    public void setTimesPlayed(int times)
    {
        TimesPlayed = times;
        PlayerPrefs.SetInt("TimesPlayed", TimesPlayed);
        PlayerPrefs.Save();
    }

    public void setVolume(float music, float effects)
    {
        EffectsVolume = effects;
        MusicVolume = music;
        PlayerPrefs.SetFloat("EffectsVolume", effects);
        PlayerPrefs.SetFloat("MusicVolume", music);
        PlayerPrefs.Save();
    }

    public void ChangeResolution(int width, int height,bool enabled)
    {
        ResolutionWidth = width;
        ResolutionHeigth = height;
        if (enabled)
            FullScreen = 1;
        else
            FullScreen = 0;

        PlayerPrefs.SetInt("ResolutionWidth", ResolutionWidth);
        PlayerPrefs.SetInt("ResolutionHeigth", ResolutionHeigth);
        PlayerPrefs.SetInt("FullScreen", FullScreen);

        PlayerPrefs.Save();
        Screen.SetResolution(ResolutionWidth, ResolutionHeigth, enabled);
    }


   
}
