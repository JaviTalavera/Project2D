using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {

    public float Timer;
    public Text Elapsed;

    void Update()
    {
        Timer += Time.deltaTime;

        Elapsed.text = Timer.ToString();
    }

}
