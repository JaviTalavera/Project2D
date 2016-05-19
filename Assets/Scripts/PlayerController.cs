using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Reflection;

[assembly: AssemblyVersionAttribute("0.1")]

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
    private Vector3 startPos;
    private int count;
    private int coin;
    private int iLifes;
    public int CurrentPlayingLevel;
    public int PickupNumber;
    public float Timer;
    private string TotalPoints;
    public Text countText;
    public Text winText;
    public Text Elapsed;
    public Text GameOver;
    public AudioClip salto;
    public AudioClip caida;
    public AudioClip win;
    public AudioClip lose;

    public GameObject EndPanel;
    public float MaxTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        count = 0;
        coin = 0;
        iLifes = 3;
        PickupNumber = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        winText.text = "";
        TotalPoints = "/" + PickupNumber.ToString();
        SetCountText();
        GameOver.text = "";
        MaxTime = 45;
        Time.timeScale = 1;
    }

    void Update()
    {
        TimeSpan remaining;


        bool Jump = Input.GetButtonDown("Jump");
        if (Jump && transform.position.y<1f)
        {
            rb.AddForce(0f, 300f, 0f);
            AudioSource.PlayClipAtPoint(salto, transform.position,PlayerData.Instance.EffectsVolume);
        }
        Timer += Time.deltaTime;
        remaining = TimeSpan.FromSeconds(MaxTime - Timer);

        Elapsed.text = string.Format("{0:D2}:{1:D2}.{2:D3}", remaining.Minutes, remaining.Seconds, remaining.Milliseconds);

        if (remaining.Seconds < 10)
        {
            Elapsed.GetComponent<Text>().color = Color.red;
        }
        if (remaining.Seconds <= 0)
        {
            Time.timeScale = 0;
            Elapsed.text = "00:00.000";
           GameOverNoLifes();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (transform.position.y < -1f)
        {
            AudioSource.PlayClipAtPoint(caida, transform.position, PlayerData.Instance.EffectsVolume);
            transform.position = startPos;
            iLifes--;
            SetCountText();
            PlayerData.Instance.Lifes++;
            PlayerPrefs.SetInt("Lifes", PlayerData.Instance.Lifes);
            PlayerPrefs.Save();

            if (iLifes < 1)
            {
                Time.timeScale = 0;
                AudioSource.PlayClipAtPoint(lose, transform.position, PlayerData.Instance.EffectsVolume);
                PlayerData.Instance.Deaths++;
                PlayerPrefs.SetInt("Deaths", PlayerData.Instance.Deaths);
                PlayerPrefs.Save();
                GameOverNoLifes();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            coin++;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Speed Up"))
        {
            if (other.gameObject.name.Equals("SpeedLeft"))
                rb.AddForce(-500f, 0f, 0f);
            else if (other.gameObject.name.Equals("SpeedDown"))
                rb.AddForce(0f, 0f, -500f);
            else if (other.gameObject.name.Equals("SpeedRight"))
                    rb.AddForce(500f, 0f, 0f);
            else
                rb.AddForce(0f, 0f, 500f);

        }else if (other.gameObject.CompareTag("Finish"))
        {
            AudioSource.PlayClipAtPoint(win, transform.position, PlayerData.Instance.EffectsVolume);
            EndPanel.SetActive(true);
            winText.text = "NIVEL COMPLETADO";
            Time.timeScale = 0;

            if (CurrentPlayingLevel < 7)
            {
                if (PlayerData.Instance.LevelUnlocked < CurrentPlayingLevel)
                    PlayerData.Instance.LevelUnlocked = CurrentPlayingLevel;

                PlayerPrefs.SetInt("LevelUnlocked", PlayerData.Instance.LevelUnlocked = CurrentPlayingLevel + 1);
                SaveBestTime();
            }

            if (count > PlayerData.Instance.PlayerWorldGems1[(CurrentPlayingLevel - 1)])
            {
                PlayerData.Instance.PlayerWorldGems1[(CurrentPlayingLevel - 1)] = count;
                PlayerData.Instance.setPlayerWorldGems();
            }
            if (coin > PlayerData.Instance.PlayerWorldCoins1[(CurrentPlayingLevel - 1)])
            {
                PlayerData.Instance.PlayerWorldCoins1[(CurrentPlayingLevel - 1)] = coin;
                PlayerData.Instance.setPlayerWorldCoins();
            }
        }

    }

    void SetCountText()
    {
        countText.text = "Vidas: " + iLifes.ToString() + "\n" +
                         "Gemas: " + count.ToString() + TotalPoints + "\n" +
                         "Monedas: " + coin.ToString();
    }

    void GameOverNoLifes()
    {
        EndPanel.SetActive(true);
        GameOver.text = "¡¡¡ERES MALÍSIMO !!!";
    }

    void SaveBestTime()
    {
        int inicio;
        int final;
        float auxSuperior;
        string sAuxSuperior;          

        for (inicio = 1; inicio <= 10; inicio++)
        {
            if (Timer < PlayerPrefs.GetFloat("HighScoreLevelTime" + CurrentPlayingLevel.ToString() + inicio.ToString(),100000))
            {
                for (final = 10; final != inicio; final--)
                {
                    auxSuperior = PlayerPrefs.GetFloat("HighScoreLevelTime" + CurrentPlayingLevel.ToString() + (final - 1).ToString());
                    sAuxSuperior = PlayerPrefs.GetString("HighScoreLevelName" + CurrentPlayingLevel.ToString() + (final - 1).ToString());
                    PlayerPrefs.SetFloat("HighScoreLevelTime" + CurrentPlayingLevel.ToString() + final.ToString(), auxSuperior);
                    PlayerPrefs.SetString("HighScoreLevelName" + CurrentPlayingLevel.ToString() + final.ToString(), sAuxSuperior);
                }
                PlayerPrefs.SetFloat("HighScoreLevelTime" + CurrentPlayingLevel.ToString() + inicio.ToString(), Timer);
                PlayerPrefs.SetString("HighScoreLevelName" + CurrentPlayingLevel.ToString() + inicio.ToString(), PlayerData.Instance.PlayerName);
                PlayerPrefs.Save();
                inicio = 11;
            }
        }

    }
}
