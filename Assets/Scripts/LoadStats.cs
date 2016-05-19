using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadStats : MonoBehaviour {
    public Text Stats;

	// Use this for initialization
	void Start () {
        Stats.text = "Jugador: " + PlayerData.Instance.PlayerName + "\r\n" +
                    "Veces jugadas: " + PlayerData.Instance.TimesPlayed + "\r\n" +
                    "Vidas perdidas: " + PlayerData.Instance.Lifes + "\r\n" +
                    "Muertes: " + PlayerData.Instance.Deaths + "\r\n" +
                    "Máximo nivel desbloqueado: " + PlayerData.Instance.LevelUnlocked + "\r\n" +
                    "Gemas conseguidas: " + PlayerData.Instance.Gems + "\r\n" +
                    "Monedas conseguidas: " + PlayerData.Instance.Coins;

}
	
	// Update is called once per frame
	void Update () {
	
	}
}
