using System;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.PunTutorial {
  public class GameManager : MonoBehaviourPunCallbacks {
    #region Photon Callbacks
    
    public override void OnleftRoom() {
      SceneManager.LoadScene(0);
    }

    #endregion

    #region Public Methods
    
    public void LeaveRoom() {
      PhotonNetwork.LeaveRoom();
    }

    #endregion
  }

}