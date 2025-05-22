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


    public void OnEncontrarRoomClicked()
    {
        SetPantalla(lobbieNavegador);
    }

    public void OnRegresarClicked()
    {
        
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
        iniciarJuego.interactable = PhotonNetwork.IsMasterClient;

        txtListaJugadores.text = "";

        foreach(Player p in PhotonNetwork.PlayerList)
        {
            txtListaJugadores.text += p.NickName + "\n";

        }

        txtInfo.text = string.Format(@"<b>Nombre Room: </b>{0}{1}", "\n", PhotonNetwork.CurrentRoom.Name);
    }


    public void OnIniciarJuegoCliked()
    {
        PhotonNetwork.LoadLevel("MapRainPhoton");
    }

    public void OnSalirLobby()
    {

    }

    public GameObject CrearRoomBoton()
    {
        GameObject obj = Instantiate(roomElemento, roomContenedor, transform);
        roomElementos.Add(obj);
        return obj;
    }

    private void ActualizarLobbyNavegador()
    {
        foreach(GameObject p in roomElementos)
        {
            p.SetActive(false);
        }

        for (int i = 0; i < listaRooms.Count; i++)
        {
            GameObject boton = i >=roomElementos.Count ? CrearRoomBoton() : roomElementos[i];
            boton.SetActive(true);

            boton.transform.Find("txtNombreRoom").GetComponent<TextMeshProUGUI>().text = listaRooms[i].Name;
            boton.transform.Find("txtCantidadJugadores").GetComponent<TextMeshProUGUI>().text = listaRooms[i].PlayerCount + "/" + listaRooms[i].MaxPlayers;

            Button b1 = boton.GetComponent<Button>();
            string nombre = listaRooms[i].Name;
            b1.onClick.RemoveAllListeners();
            b1.onClick.AddListener(() => { OnUnirseRoomClicked(nombre); });
        }
    }

    public void OnRefrescarClicked()
    {
        ActualizarLobbyNavegador();
    }

    private void OnUnirseRoomClicked(string nombre)
    {
        NetworkManager.instance.UnirseRoom(nombre);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        listaRooms = roomList;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
