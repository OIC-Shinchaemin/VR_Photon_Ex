using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class LoginManager : MonoBehaviourPunCallbacks
{


    public TMP_InputField PlayerName_InputField;


    #region UNITY Methods


    // Start is called before the first frame update


    #endregion

    #region UI Callback Methods

    public void ConnectedToPhotonServer()
    {
        if(PlayerName_InputField != null)
        {
            PhotonNetwork.NickName = PlayerName_InputField.text;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    #endregion

    #region Photon callback Methods
    public override void OnConnected()
    {

        Debug.Log("OnConnected is called. The server is available.");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to the Master Server with player name: " + PhotonNetwork.NickName);
        PhotonNetwork.LoadLevel("HomeScene");
    }

    #endregion
}
