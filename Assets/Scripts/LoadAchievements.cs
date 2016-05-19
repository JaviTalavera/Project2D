using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadAchievements : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LoadGems();
    }
	

    public void LoadGems()
    {
        Inicializa();

        GameObject.Find("AcT1").GetComponent<Text>().text = "Consigue 10 Gemas";
        if (PlayerData.Instance.Gems >= 10)
                GameObject.Find("Image1").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT2").GetComponent<Text>().text = "Consigue 20 Gemas";
        if (PlayerData.Instance.Gems >= 20)
            GameObject.Find("Image2").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT3").GetComponent<Text>().text = "Consigue 30 Gemas";
        if (PlayerData.Instance.Gems >= 30)
            GameObject.Find("Image3").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT4").GetComponent<Text>().text = "Consigue 50 Gemas";
        if (PlayerData.Instance.Gems >= 50)
            GameObject.Find("Image4").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT5").GetComponent<Text>().text = "Consigue 75 Gemas";
        if (PlayerData.Instance.Gems >= 75)
            GameObject.Find("Image5").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT6").GetComponent<Text>().text = "Consigue 100 Gemas";
        if (PlayerData.Instance.Gems >= 100)
            GameObject.Find("Image6").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT7").GetComponent<Text>().text = "Consigue 150 Gemas";
        if (PlayerData.Instance.Gems >= 150)
            GameObject.Find("Image7").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT8").GetComponent<Text>().text = "Consigue 200 Gemas";
        if (PlayerData.Instance.Gems >= 200)
            GameObject.Find("Image8").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT9").GetComponent<Text>().text = "Consigue 300 Gemas";
        if (PlayerData.Instance.Gems >= 300)
            GameObject.Find("Image9").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT10").GetComponent<Text>().text = "Consigue 400 Gemas";
        if (PlayerData.Instance.Gems >= 400)
            GameObject.Find("Image10").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT11").GetComponent<Text>().text = "Consigue 500 Gemas";
        if (PlayerData.Instance.Gems >= 500)
            GameObject.Find("Image11").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT12").GetComponent<Text>().text = "Consigue 600 Gemas";
        if (PlayerData.Instance.Gems >= 600)
            GameObject.Find("Image12").GetComponent<Image>().color = Color.green;
    }

    public void LoadCoins()
    {
        Inicializa();

        GameObject.Find("AcT1").GetComponent<Text>().text = "Consigue 1 Moneda";
        if (PlayerData.Instance.Coins >= 1)
            GameObject.Find("Image1").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT2").GetComponent<Text>().text = "Consigue 5 Monedas";
        if (PlayerData.Instance.Coins >= 5)
            GameObject.Find("Image2").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT3").GetComponent<Text>().text = "Consigue 10 Monedas";
        if (PlayerData.Instance.Coins >= 10)
            GameObject.Find("Image3").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT4").GetComponent<Text>().text = "Consigue 15 Monedas";
        if (PlayerData.Instance.Coins >= 15)
            GameObject.Find("Image4").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT5").GetComponent<Text>().text = "Consigue 20 Monedas";
        if (PlayerData.Instance.Coins >= 20)
            GameObject.Find("Image5").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT6").GetComponent<Text>().text = "Consigue 25 Monedas";
        if (PlayerData.Instance.Coins >= 25)
            GameObject.Find("Image6").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT7").GetComponent<Text>().text = "Consigue 30 Monedas";
        if (PlayerData.Instance.Coins >= 30)
            GameObject.Find("Image7").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT8").GetComponent<Text>().text = "Consigue 35 Monedas";
        if (PlayerData.Instance.Coins >= 35)
            GameObject.Find("Image8").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT9").GetComponent<Text>().text = "Consigue 40 Monedas";
        if (PlayerData.Instance.Coins >= 40)
            GameObject.Find("Image9").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT10").GetComponent<Text>().text = "Consigue 45 Monedas";
        if (PlayerData.Instance.Coins >= 45)
            GameObject.Find("Image10").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT11").GetComponent<Text>().text = "Consigue 50 Monedas";
        if (PlayerData.Instance.Coins >= 50)
            GameObject.Find("Image11").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT12").GetComponent<Text>().text = "Consigue 60 Monedas";
        if (PlayerData.Instance.Coins >= 60)
            GameObject.Find("Image12").GetComponent<Image>().color = Color.green;
    }

    public void LoadTimes()
    {
        Inicializa();
        GameObject.Find("AcT1").GetComponent<Text>().text = "Consigue 3 tiempos Plata";
        GameObject.Find("AcT2").GetComponent<Text>().text = "Consigue 5 tiempos Plata";
        GameObject.Find("AcT3").GetComponent<Text>().text = "Consigue 10 tiempos Plata";
        GameObject.Find("AcT4").GetComponent<Text>().text = "Consigue 15 tiempos Plata";
        GameObject.Find("AcT5").GetComponent<Text>().text = "Consigue 20 tiempos Plata";
        GameObject.Find("AcT6").GetComponent<Text>().text = "Consigue 25 tiempos Plata";
        GameObject.Find("AcT7").GetComponent<Text>().text = "Consigue 5 tiempos Oro";
        GameObject.Find("AcT8").GetComponent<Text>().text = "Consigue 10 tiempos Oro";
        GameObject.Find("AcT9").GetComponent<Text>().text = "Consigue 20 tiempos Oro";
        GameObject.Find("AcT10").GetComponent<Text>().text = "Consigue 30 tiempos Oro";
        GameObject.Find("AcT11").GetComponent<Text>().text = "Consigue 40 tiempos Oro";
        GameObject.Find("AcT12").GetComponent<Text>().text = "Consigue 60 tiempos Oro";
    }

    public void LoadLevels()
    {
        Inicializa();
        GameObject.Find("AcT1").GetComponent<Text>().text = "Descubre el Mundo 2";
        if (PlayerData.Instance.LevelUnlocked > 6)
            GameObject.Find("Image1").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT2").GetComponent<Text>().text = "Descubre el Mundo 3";
        if (PlayerData.Instance.LevelUnlocked > 12)
            GameObject.Find("Image1").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT3").GetComponent<Text>().text = "Descubre el Mundo 4";
        if (PlayerData.Instance.LevelUnlocked > 18)
            GameObject.Find("Image1").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT4").GetComponent<Text>().text = "Descubre el Mundo 5";
        if (PlayerData.Instance.LevelUnlocked > 24)
            GameObject.Find("Image1").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT5").GetComponent<Text>().text = "Descubre el Mundo 6";
        if (PlayerData.Instance.LevelUnlocked > 30)
            GameObject.Find("Image1").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT6").GetComponent<Text>().text = "Descubre el Mundo 7";
        if (PlayerData.Instance.LevelUnlocked > 36)
            GameObject.Find("Image1").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT7").GetComponent<Text>().text = "Descubre el Mundo 8";
        if (PlayerData.Instance.LevelUnlocked > 42)
            GameObject.Find("Image1").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT8").GetComponent<Text>().text = "Descubre el Mundo 9";
        if (PlayerData.Instance.LevelUnlocked > 48)
            GameObject.Find("Image1").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT9").GetComponent<Text>().text = "Descubre el Mundo 10";
        if (PlayerData.Instance.LevelUnlocked > 54)
            GameObject.Find("Image1").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT10").GetComponent<Text>().text = "Descubre el Mundo Gemas";
        if (PlayerData.Instance.Gems >= 600)
            GameObject.Find("Image10").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT11").GetComponent<Text>().text = "Descubre el Mundo Monedas";
        if (PlayerData.Instance.Coins >= 60)
            GameObject.Find("Image10").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT12").GetComponent<Text>().text = "Descubre el Mundo Dorado";
    }

    public void LoadMultiplayer()
    {
        Inicializa();

        GameObject.Find("AcT1").GetComponent<Text>().text = "Juega 5 partidas";
        if (PlayerData.Instance.TimesPlayedMultiplayer >= 5)
            GameObject.Find("Image1").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT2").GetComponent<Text>().text = "Juega 10 partidas";
        if (PlayerData.Instance.TimesPlayedMultiplayer >= 10)
            GameObject.Find("Image2").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT3").GetComponent<Text>().text = "Juega 50 partidas";
        if (PlayerData.Instance.TimesPlayedMultiplayer >= 50)
            GameObject.Find("Image3").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT4").GetComponent<Text>().text = "Juega 100 partidas";
        if (PlayerData.Instance.TimesPlayedMultiplayer >= 100)
            GameObject.Find("Image4").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT5").GetComponent<Text>().text = "Gana 1 partida";
        if (PlayerData.Instance.TimesPlayedMultiplayer >= 1)
            GameObject.Find("Image5").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT6").GetComponent<Text>().text = "Gana 10 partidas";
        if (PlayerData.Instance.TimesPlayedMultiplayer >= 10)
            GameObject.Find("Image6").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT7").GetComponent<Text>().text = "Gana 50 partidas";
        if (PlayerData.Instance.TimesPlayedMultiplayer >= 50)
            GameObject.Find("Image7").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT8").GetComponent<Text>().text = "Gana 100 partidas";
        if (PlayerData.Instance.TimesPlayedMultiplayer >= 100)
            GameObject.Find("Image8").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT9").GetComponent<Text>().text = "Mata 1 rival";
        if (PlayerData.Instance.MultiplayerKills >= 1)
            GameObject.Find("Image9").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT10").GetComponent<Text>().text = "Mata 10 rivales";
        if (PlayerData.Instance.MultiplayerKills >= 10)
            GameObject.Find("Image10").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT11").GetComponent<Text>().text = "Mata 50 rivales";
        if (PlayerData.Instance.MultiplayerKills >= 50)
            GameObject.Find("Image11").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT12").GetComponent<Text>().text = "Mata 100 rivales";
        if (PlayerData.Instance.MultiplayerKills >= 100)
            GameObject.Find("Image12").GetComponent<Image>().color = Color.green;
    }

    public void LoadShop()
    {
        Inicializa();
        GameObject.Find("AcT1").GetComponent<Text>().text = "Compra 1 Artículo";
        GameObject.Find("AcT2").GetComponent<Text>().text = "Compra 3 Artículos";
        GameObject.Find("AcT3").GetComponent<Text>().text = "Compra 5 Artículos";
        GameObject.Find("AcT4").GetComponent<Text>().text = "Compra 7 Artículos";
        GameObject.Find("AcT5").GetComponent<Text>().text = "Compra 10 Artículos";
        GameObject.Find("AcT6").GetComponent<Text>().text = "Compra 15 Artículos";
        GameObject.Find("AcT7").GetComponent<Text>().text = "Compra 20 Artículos";
        GameObject.Find("AcT8").GetComponent<Text>().text = "Compra 25 Artículos";
        GameObject.Find("AcT9").GetComponent<Text>().text = "Compra 30 Artículos";
        GameObject.Find("AcT10").GetComponent<Text>().text = "Compra 35 Artículos";
        GameObject.Find("AcT11").GetComponent<Text>().text = "Compra 40 Artículos";
        GameObject.Find("AcT12").GetComponent<Text>().text = "Compra 50 Artículos";
    }

    public void LoadGame()
    {
        Inicializa();

        GameObject.Find("AcT1").GetComponent<Text>().text = "Inicia el juego 500 veces";
        if (PlayerData.Instance.TimesPlayed >= 500)
            GameObject.Find("Image1").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT2").GetComponent<Text>().text = "Muere 300 veces";
        if (PlayerData.Instance.Deaths >= 300)
            GameObject.Find("Image2").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT3").GetComponent<Text>().text = "Pierde 300 vidas ";
        if (PlayerData.Instance.Lifes >= 300)
            GameObject.Find("Image3").GetComponent<Image>().color = Color.green;

        GameObject.Find("AcT4").GetComponent<Text>().text = "Consigue 15 Monedas";
        GameObject.Find("AcT5").GetComponent<Text>().text = "Consigue 20 Monedas";
        GameObject.Find("AcT6").GetComponent<Text>().text = "Consigue 25 Monedas";
        GameObject.Find("AcT7").GetComponent<Text>().text = "Consigue 30 Monedas";
        GameObject.Find("AcT8").GetComponent<Text>().text = "Consigue 35 Monedas";
        GameObject.Find("AcT9").GetComponent<Text>().text = "Consigue 40 Monedas";
        GameObject.Find("AcT10").GetComponent<Text>().text = "Consigue 45 Monedas";
        GameObject.Find("AcT11").GetComponent<Text>().text = "Consigue 50 Monedas";
        GameObject.Find("AcT12").GetComponent<Text>().text = "Consigue 60 Monedas";
    }

    public void Inicializa()
    {
        int i;
        for (i=1; i<=12; i++)
            GameObject.Find(("Image" + i.ToString())).GetComponent<Image>().color = Color.red;
    }
}
