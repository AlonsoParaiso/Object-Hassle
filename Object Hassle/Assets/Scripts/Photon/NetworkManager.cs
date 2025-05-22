using Photon.Pun;
using Photon.Pun.Demo.Cockpit.Forms;
using Photon.Pun.Demo.SlotRacer.Utils;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public int maximoJugadores = 2;
    public static NetworkManager instance;
    private float time;
    private float life;

    private KeyCode Esc = KeyCode.Escape;
    //public AudioClip SelectClip;
    public uint[] characterIndexes;
    public int sceneryIndexes;
    public AudioClip selection;
    public string scenaryCombat;
    public Character character;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CrearRoom(string nombre)
    {
        RoomOptions opciones = new RoomOptions
        {
            MaxPlayers = (byte)maximoJugadores,
        };
        PhotonNetwork.CreateRoom(nombre, opciones);
    }  

    public void UnirseRoom (string nombre)
    {
        PhotonNetwork.JoinRoom(nombre);
    }

    [PunRPC]

    public void CambiarEscena(string escena)
    {
        PhotonNetwork.LoadLevel(escena);
    }

    public override void OnDisconnected(DisconnectCause cause) 
    {
        PhotonNetwork.LoadLevel("menu");
    }


    // Update is called once per frame

    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKeyDown(Esc))
        {
            SceneManager.LoadScene("Menu");
            AudioManager.instance.ClearAudio();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            time = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            AudioManager.instance.ClearAudio();
        }
    }

    // getter
    public float GetTime()
    {
        return time;
    }

    // getter


    // setter
    public void SetPoints(int value)
    {
        life = value;
    }

    public void LoadScene(string sceneName)
    {
        time = 0;
        SceneManager.LoadScene(sceneName);
        AudioManager.instance.ClearAudio();
    }

    public void ExitGame()
    {
        Debug.Log("Me cerraste wey");
        Application.Quit();
    }

    public void SelectCharacter(int Selection)
    {
        characterIndexes[0] = (uint)Selection;//selecciona el persoanje elegido
        AudioManager.instance.PlayAudio(selection, "selection", false, 0.5f);
    }

    public void SelectScenery()
    {
        LoadScene(scenaryCombat);//selencionna la escena la cual has elegido
        AudioManager.instance.PlayAudio(selection, "selection", false, 0.5f);
    }
}
