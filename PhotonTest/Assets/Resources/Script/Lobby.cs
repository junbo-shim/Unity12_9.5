using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class Lobby : MonoBehaviourPunCallbacks
{
    public Button joinButton;
    public TMP_Text buttonText;
     
    // Start is called before the first frame update
    void Start()
    {
        //joinButton = GameObject.Find("Lobby_Button").GetComponent<Button>();
        //buttonText = joinButton.GetComponentInChildren<TMP_Text>();

        PhotonNetwork.ConnectUsingSettings();
        joinButton.interactable = false;
        buttonText.text = "Wait...\nConnecting to Server...";
    }
    
    public override void OnConnectedToMaster() 
    {
        joinButton.interactable = true;
        buttonText.text = "Online\nSearch Game";
        //PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        buttonText.text = "Disconnected...\nConnecting to Server...";

        PhotonNetwork.ConnectUsingSettings();
    }

    public void Connect()
    {
        Debug.Log("1");
        joinButton.interactable = false;
        Debug.Log("2");
        if (PhotonNetwork.IsConnected) 
        {
            Debug.Log("3");
            buttonText.text = "Joining the Game";
            PhotonNetwork.JoinRandomRoom();
        }
        else 
        {
            Debug.Log("4");
            buttonText.text = "Disconnected...\nConnecting to Server...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        buttonText.text = "No Game Found\nCreating New Game";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });
    }

    public override void OnJoinedRoom()
    {
        buttonText.text = "Join Success";
        PhotonNetwork.LoadLevel("PlayScene");
    }
}
