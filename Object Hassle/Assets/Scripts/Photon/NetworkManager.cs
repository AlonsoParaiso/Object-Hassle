using Photon.Pun;
using Photon.Pun.Demo.Cockpit.Forms;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public int maximoJugadores = 2;
    
    public static NetworkManager instance;

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
        
    }
}
