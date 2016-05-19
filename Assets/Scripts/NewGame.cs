using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {

    public InputField iPlayerName;

    // Use this for initialization
    void Start () {

        GameObject tPlayer ;
        if (PlayerData.Instance.PlayerName.Equals(""))
        {

        }
        else
        {
            iPlayerName.gameObject.SetActive(false);
            tPlayer = GameObject.Find("Text");
            tPlayer.GetComponent<Text>().text = "Bienvenido" +  "\r\n"+  PlayerData.Instance.PlayerName;
        }
        PlayerData.Instance.TimesPlayed++;
        PlayerData.Instance.setTimesPlayed(PlayerData.Instance.TimesPlayed);

    }

    public void SetPlayerName()
    {
        if ((iPlayerName.text.Equals("")) & (PlayerData.Instance.PlayerName.Equals("")))
        {
            iPlayerName.placeholder.GetComponent<Text>().text = "Nombre demasiado corto";
        }
        else
        {
            if (PlayerData.Instance.PlayerName.Equals("")) 
                PlayerData.Instance.setPlayerName(iPlayerName.text);
            SceneManager.LoadScene(1);
        }
    }

   
}
