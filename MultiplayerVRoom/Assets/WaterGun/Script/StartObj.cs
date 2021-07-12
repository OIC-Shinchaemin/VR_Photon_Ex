using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class StartObj : MonoBehaviourPunCallbacks, IPunObservable
{
    PhotonView m_photonView;
    bool Collision = false;

    private void Awake()
    {
        m_photonView = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Collision)
        {
            TransferOwnership();
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "WaterGun1" || collider.gameObject.name == "WaterGun2")
        {
            Collision = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "WaterGun1" || collider.gameObject.name == "WaterGun2")
        {
            Collision = false;
        }
    }

    public bool IsCollision()
    {
        return Collision;
    }

    public void reset()
    {
        Collision = false;
    }
    void TransferOwnership()
    {
        m_photonView.RequestOwnership();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(Collision);
        }
        else
        {
            this.Collision = (bool)stream.ReceiveNext();
        }
    }
}
