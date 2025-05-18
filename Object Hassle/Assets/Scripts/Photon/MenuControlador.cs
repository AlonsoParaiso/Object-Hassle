using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System;

public class MenuControlador : MonoBehaviourPunCallbacks, ILobbyCallbacks
{
    [Header("Pantallas")]
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject crearRoomPantalla;
    [SerializeField] private GameObject lobbiePnatalla;
    [SerializeField] private GameObject lobbieNavegador;

    [Header("Menu")]
    [SerializeField] private Button btnCrearRoom;
    [SerializeField] private Button btnEncontarRoom;

    [Header("Lobby")]
    [SerializeField] private TextMeshProUGUI txtListaJugadores;
    [SerializeField] private TextMeshProUGUI txtInfo;
    [SerializeField] private Button iniciarJuego;

    [Header("Lobby Navegador")]
    [SerializeField] private RectTransform roomContenedor;
    [SerializeField] private GameObject roomElemento;

    private List<GameObject> roomElementos= new List<GameObject>();
    private List<RoomInfo> listaRooms= new List<RoomInfo>();

    void Start()
    {
        btnCrearRoom.interactable = false;
        btnEncontarRoom.interactable = false;

        if(PhotonNetwork.InRoom)
        {
            PhotonNetwork.CurrentRoom.IsVisible = true;
            PhotonNetwork.CurrentRoom.IsOpen = true;
        }
    }

    void SetPantalla(GameObject screen)
    {
        menuPrincipal.SetActive(false);
        crearRoomPantalla.SetActive(false);
        lobbiePnatalla.SetActive(false);
        lobbieNavegador.SetActive(false);

        screen.SetActive(true);

        if (screen == lobbieNavegador)
            ActualizarLobbyNavegador();
    }

    private void ActualizarLobbyNavegador()
    {
        throw new NotImplementedException();
    }

    public void OnNombreJugadorCambia(TMP_InputField inpJugadorNombre) 
    {
        PhotonNetwork.NickName = inpJugadorNombre.text;
    }

    public override void OnConnectedToMaster()
    {
        btnCrearRoom.interactable=true;
        btnEncontarRoom.interactable = true;

    }

    public void OnCrearRoomClicked()
    {
        SetPantalla(crearRoomPantalla);
    }

    public void OnCrearRoomBoton(TMP_InputField nombre)
    {
        NetworkManager.instance.CrearRoom(nombre.text);
    }

    public override void OnJoinedRoom()
    {
        SetPantalla(lobbiePnatalla);
        photonView.RPC("ActualizarLobby", RpcTarget.All);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
    }

    [PunRPC]

    private void ActualizarLobby()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
