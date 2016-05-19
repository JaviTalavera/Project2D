using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicTheme : MonoBehaviour {

    public AudioClip MainTheme;

    public static MusicTheme Instance
    {
        get { return _instance ?? (_instance = new GameObject("MusicThemeObject").AddComponent<MusicTheme>()); }
    }

    private static MusicTheme _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        _instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
