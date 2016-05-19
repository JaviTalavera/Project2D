using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {
    public int level;

    void Start()
    {
        if (level > 0)
        {
            if (PlayerData.Instance.LevelUnlocked < level)
            {
                GetComponent<Image>().color = Color.gray;
                GetComponent<Button>().enabled = false;
            }
            GetComponentInChildren<Text>().text = ("Nivel " + level.ToString()  + "\n" + PlayerData.Instance.PlayerWorldGems1[(level - 1)].ToString()

                                                                                + "//" + PlayerData.Instance.WorldGems1[ (level-1) ].ToString() + " Gemas"

                                                                                + "\n" + PlayerData.Instance.PlayerWorldCoins1[(level - 1)].ToString()

                                                                                + "//" + PlayerData.Instance.WorldCoins1[(level - 1)].ToString() + " Moneda");
        }


    }

 
}