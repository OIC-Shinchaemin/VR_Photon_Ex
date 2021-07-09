using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class WaterGun : MonoBehaviourPunCallbacks, IPunObservable, IPunOwnershipCallbacks
{
    PhotonView m_photonView;
    Rigidbody rb;
    public ParticleSystem particle;
    WaterParticle water_particle;

    public bool isBeingHeld = false;
    bool IsFire = false;

    private void Awake()
    {
        m_photonView = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        water_particle = this.GetComponentInChildren<WaterParticle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld)
        {
            rb.isKinematic = true;
            gameObject.layer = 13;
        }
        else
        {
            rb.isKinematic = false;
            gameObject.layer = 8;
        }

        /*if (isBeingHeld && m_photonView.IsMine)
        {
            var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
            UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices); 
            var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
            UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);
            if (rightHandDevices.Count ==1 || leftHandDevices.Count == 1)
            {
                UnityEngine.XR.InputDevice rdevice = rightHandDevices[0];
                UnityEngine.XR.InputDevice ldevice = leftHandDevices[0];
                bool rtriggerValue, rgripValue, ltriggerValue, lgripValue;
                if (rdevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out rtriggerValue) && rtriggerValue && rdevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out rgripValue) && rgripValue
                    || ldevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out ltriggerValue) && ltriggerValue && ldevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out lgripValue) && lgripValue)
                {
                    IsFire = true;
                }
                else 
                {
                    IsFire = false;
                }
            }

        }*/

        if ( IsFire)
        {
            particle.Play();
        }
        else
        {
            particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(IsFire);
        }
        else
        {
            this.IsFire = (bool)stream.ReceiveNext();
        }
    }

    void TransferOwnership()
    {
        m_photonView.RequestOwnership();
    }

    public void OnSelectEnter()
    {
        Debug.Log("Grabbed");
        m_photonView.RPC("StartNetworkedGrabbing", RpcTarget.AllBuffered);

        if (m_photonView.Owner == PhotonNetwork.LocalPlayer)
        {
            Debug.Log("We do not request the ownership. Already mine.");
        }
        else
        {
            TransferOwnership();
            water_particle.TransferOwnership();
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

    public bool IsBeingHeld()
    {
        return isBeingHeld;
    }

    public void OnActivate()
    {
        IsFire = true;
    }

    public void OnDeactivate()
    {
        IsFire = false;
    }
}
