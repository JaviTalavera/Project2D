using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Dropdown dropdownMenu;
    public Toggle fullScreen;
    public InputField PlayerName;
    public Slider slMusic;
    public Slider slEffects;
    public Text tMusic;
    public Text tEffecs;

    public void ChangeOptions()
    {
        string resolution;
        //string auxName;
        int width;
        int height;
        resolution = dropdownMenu.captionText.text;

        int.TryParse(resolution.Substring(0, resolution.IndexOf('x')), out width);
        int.TryParse(resolution.Substring(resolution.IndexOf('x')+1), out height);
        //auxName = (PlayerName.placeholder.GetComponent<Text>().text);
        //if (auxName  != PlayerData.Instance.PlayerName)
        //    PlayerData.Instance.setPlayerName(PlayerName.text);
        PlayerData.Instance.ChangeResolution(width, height, fullScreen.isOn);

        slMusic.normalizedValue = slMusic.value;
        slEffects.normalizedValue = slEffects.value;
        PlayerData.Instance.setVolume(slMusic.normalizedValue, slEffects.normalizedValue);
        SceneManager.LoadScene(1);
    }

    void Start()
    {
        float auxVolume;
        //PlayerName.placeholder.GetComponent<Text>().text = PlayerData.Instance.PlayerName;

        if (PlayerData.Instance.FullScreen.Equals(1))
            fullScreen.isOn = true;
        else
            fullScreen.isOn = false;

        switch (PlayerData.Instance.ResolutionHeigth)
        {
            case 1920: dropdownMenu.captionText.text = "1920x1080";
                break;
            case 1080: dropdownMenu.captionText.text = "1080x720";
                break;
            case 800: dropdownMenu.captionText.text = "800x600";
                break;
        }
        slMusic.normalizedValue = PlayerData.Instance.MusicVolume;
        slMusic.value = slMusic.normalizedValue;
        auxVolume = (PlayerData.Instance.MusicVolume * 100);
        auxVolume = Mathf.FloorToInt(auxVolume);
        tMusic.text = auxVolume.ToString() + "%";

        slEffects.normalizedValue = PlayerData.Instance.EffectsVolume;
        slEffects.value = slEffects.normalizedValue;
        auxVolume = (PlayerData.Instance.EffectsVolume * 100);
        auxVolume = Mathf.FloorToInt(auxVolume);
        tEffecs.text = auxVolume.ToString() + "%";

    }

    public void ChangeSlidersText()
    {
        float auxVolume;

        auxVolume = (slMusic.value * 100);
        auxVolume = Mathf.FloorToInt(auxVolume);
        tMusic.text = auxVolume.ToString() + "%";
        PlayerData.Instance.MainTheme.volume = slMusic.value;  

        auxVolume = (slEffects.value * 100);
        auxVolume = Mathf.FloorToInt(auxVolume);
        tEffecs.text = auxVolume.ToString() + "%";

    }

    public void Cancel()
    {
        if (PlayerData.Instance.MainTheme.volume != PlayerData.Instance.MusicVolume)
            PlayerData.Instance.MainTheme.volume = PlayerData.Instance.MusicVolume;
        SceneManager.LoadScene(1);
    }
}