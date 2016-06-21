using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStats : MonoBehaviour {

    public int nPlayers;
    public int[] iPlayers;

    public GameObject[] prefabs;
    public GameObject[] hudNumPlayer;
    public GameObject[] hudHpPlayer;

    public GameObject mainCamera;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    public void selectPlayer(int selection)
    {
        iPlayers[0] = selection;
    }

    void OnLevelWasLoaded(int level)
    {
        if (level > 0)
        {
            // Destruimos la cámara y los personajes por si acaso (?)
            // Instanciamos la cámara en el spawnPoint
            // Inicializamos los personajes que hagan falta
            Transform initialPosition = GameObject.FindGameObjectWithTag("RespawnPoint").transform as Transform;

            GameObject p1 = Instantiate(prefabs[iPlayers[0]], initialPosition.position, Quaternion.identity) as GameObject;
            p1.tag = "Player1";
            p1.GetComponent<PlayerMovement>().cJump = KeyCode.Space;
            p1.GetComponent<PlayerMovement>().cAttack = KeyCode.LeftControl;
            p1.GetComponent<PlayerMovement>().xAxis = "Horizontal";

            GameObject pPlayerNum1 = Instantiate(hudNumPlayer[iPlayers[0]], p1.transform.position, Quaternion.identity) as GameObject;
            pPlayerNum1.transform.parent = p1.transform;
            p1.GetComponent<PlayerMovement>().pmPlayerAux = pPlayerNum1;

            GameObject pPlayerHud = Instantiate(hudHpPlayer[iPlayers[0]]) as GameObject;
            pPlayerHud.transform.SetParent(GameObject.Find("Canvas").transform);
            pPlayerHud.transform.localScale = new Vector3(1f,1f,1f);
            pPlayerHud.GetComponent<PlayerHudHandler>().player = PlayerHudHandler.NPlayer.Player1;

            if (nPlayers == 2)
            {
                GameObject p2 = Instantiate(prefabs[iPlayers[1]], initialPosition.position + Vector3.left, Quaternion.identity) as GameObject;
                p2.tag = "Player2";
                p2.GetComponent<PlayerMovement>().cJump = KeyCode.RightCommand;
                p2.GetComponent<PlayerMovement>().cAttack = KeyCode.RightAlt;
                p2.GetComponent<PlayerMovement>().xAxis = "Horizontal2";
                GameObject pPlayerNum2 = Instantiate(hudNumPlayer[iPlayers[1]], p2.transform.position, Quaternion.identity) as GameObject;
                pPlayerNum2.transform.parent = p2.transform;
                p2.GetComponent<PlayerMovement>().pmPlayerAux = pPlayerNum2;
                GameObject pPlayerHud2 = Instantiate(hudHpPlayer[iPlayers[1]]) as GameObject;
                pPlayerHud2.transform.SetParent(GameObject.Find("Canvas").transform);
                pPlayerHud2.transform.localScale = new Vector3(1f, 1f, 1f);
                pPlayerHud2.GetComponent<PlayerHudHandler>().player = PlayerHudHandler.NPlayer.Player2;

            }
            Instantiate(mainCamera);
        }
    }

    // Use this for initialization
    void Start () {
        nPlayers = 1;
        iPlayers[0] = 0;
	}

    public void LoadScene (int scene)
    {
        SceneManager.LoadScene(scene);
    }	
}