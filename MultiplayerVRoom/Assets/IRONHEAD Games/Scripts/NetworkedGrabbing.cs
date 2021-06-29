using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkedGrabbing : MonoBehaviourPunCallbacks,IPunOwnershipCallbacks
{
    PhotonView m_photonView;
    Rigidbody rb;
    public bool isBeingHeld = false;
    private void Awake()
    {
        m_photonView = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld)
        {
            //rb.isKinematic = true;
            gameObject.layer = 13;
        }
        else
        {
            //rb.isKinematic = false;
            gameObject.layer = 8;
        }
    }

    void TransferOwnership()
    {
        m_photonView.RequestOwnership();
    }

    public void OnSelectEnter()
    {
        Debug.Log("Grabbed");
        m_photonView.RPC("StartNetworkedGrabbing",RpcTarget.AllBuffered);

        if (m_photonView.Owner == PhotonNetwork.LocalPlayer)
        {
            Debug.Log("We do not request the ownership. Already mine.");
        }
        else
        {
            TransferOwnership();

        }
    }

    public void OnSelectExit()
    {
        Debug.Log("Released");
        m_photonView.RPC("StopNetworkedGrabbing", RpcTarget.AllBuffered);
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        if (targetView != m_photonView)
        {
            return;
        }
        Debug.Log("OnOwnerShip Requested for: " + targetView.name + " from " + requestingPlayer.NickName);
        m_photonView.TransferOwnership(requestingPlayer);
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.Log("Tresfer is complete. New owner: " + targetView.Owner.NickName);
    }

    public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
    {
        
    }

    [PunRPC]
    public void StartNetworkedGrabbing()
    {
        isBeingHeld = true;
    }

    [PunRPC]
    public void StopNetworkedGrabbing()
    {
        isBeingHeld = false;
    }
}
