using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Com.PunTutorial {
  public class Launcher : MonoBehaviourPunCallbacks {
    #region Private Serializable Fields

    [SerializeField]
    private byte maxPlayersPerRoom = 4;

    [SerializeField]
    private GameObject controlPanel;

    [SerializeField]
    private GameObject progressLabel;

    #endregion

    #region Private Fields
    
    string gameVersion = "1";
    
    #endregion
    
    #region MonoBehaviour Callbacks

    void Awake() {
      PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start() {
      progressLabel.SetActive(false);
      controlPanel.SetActive(true);
    }

    #endregion

    #region Public Methods
    
    public void Connect() {
      progressLabel.SetActive(true);
      controlPanel.SetActive(false);

      if (PhotonNetwork.IsConnected) {
        PhotonNetwork.JoinRandomRoom();
      } else {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
      }
    }

    #endregion

    #region MonoBehaviourPunCallbacks Callbacks
    public override void OnConnectedToMaster() {
      Debug.Log("OnConnectedToMaster was called by Pun");
      PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause) {
      progressLabel.SetActive(false);
      controlPanel.SetActive(true);
      Debug.LogWarningFormat("OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
      Debug.Log("OnJoinRandomFailed() was called by PUN. No random rooms available, creating one");
      PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom() {
      Debug.Log("OnJoinedRoom() called by PUN. Client is in a room");
    }

    #endregion
  }
}