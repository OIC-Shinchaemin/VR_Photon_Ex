using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class WaterGunGame : MonoBehaviourPunCallbacks, IPunObservable
{
    public const int WinTime = 20;
    public GameObject StartObj1;
    public GameObject StartObj2;
    public GameObject WaterGun1;
    public GameObject WaterGun2;

    PhotonView m_photonView;

    WaterGunUI waterGunUi = null;

    private bool IsGame = false;
    private bool IsEnd = false;

    StartObj start_obj1;
    StartObj start_obj2;
    WaterParticle water_particle1;
    WaterParticle water_particle2;
    WaterGun WaterGun1Sc;
    WaterGun WaterGun2Sc;

    bool Host = false;
    float time;
    private void Awake()
    {
        m_photonView = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        start_obj1 = StartObj1.GetComponent<StartObj>();
        start_obj2 = StartObj2.GetComponent<StartObj>();
        water_particle1 = WaterGun1.GetComponentInChildren<WaterParticle>();
        water_particle2 = WaterGun2.GetComponentInChildren<WaterParticle>();
        WaterGun1Sc = WaterGun1.GetComponent<WaterGun>();
        WaterGun2Sc = WaterGun2.GetComponent<WaterGun>();
        waterGunUi = GameObject.FindGameObjectWithTag("WaterGunUi").GetComponent<WaterGunUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Host)
        {
            TransferOwnership();
        }

        if(waterGunUi == null)
        {
            waterGunUi = GameObject.FindGameObjectWithTag("WaterGunUi").GetComponent<WaterGunUI>();
        }

        time += Time.deltaTime;
        if(time >= 5)
        {
            if (waterGunUi.IsStartActive())
            {
                waterGunUi.StartInactive();
            }
            if (waterGunUi.IsWinActive())
            {
                waterGunUi.WinInactive();
            }
            if (waterGunUi.IsLostActive())
            {
                waterGunUi.LostInactive();
            }
        }

        if(!IsGame)
        {
            if(start_obj1.IsCollision() && start_obj2.IsCollision())
            {
                waterGunUi.StartActive();
                time = 0;
                IsGame = true;
                if(WaterGun1Sc.IsBeingHeld())
                {
                    water_particle1.TimeReset();
                    Host = true;
                }
                else
                {
                    water_particle2.TimeReset();
                }
            }
        }
        else
        {
            if(!IsEnd)
            {
                if (water_particle1.GetTime() >= WinTime || water_particle2.GetTime() >= WinTime)
                {
                    IsEnd = true;
                    if(Host)
                    {
                        if(water_particle1.GetTime() >= WinTime)
                        {
                            waterGunUi.WinActive();
                            time = 0;
                        }
                        else
                        {
                            waterGunUi.LostActive();
                            time = 0;
                        }
                    }
                    else
                    {
                        if (water_particle2.GetTime() >= WinTime)
                        {
                            waterGunUi.WinActive();
                            time = 0;
                        }
                        else
                        {
                            waterGunUi.LostActive();
                            time = 0;
                        }
                    }
                }
            }
            else
            {
                if (time >= 5)
                {
                    IsEnd = false;
                    IsGame = false;
                    Host = false;
                    water_particle1.TimeReset();
                    water_particle2.TimeReset();
                    start_obj1.reset();
                    start_obj2.reset();
                }
            }
        }
    }

    void TransferOwnership()
    {
        m_photonView.RequestOwnership();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        /*if (stream.IsWriting)
        {
            stream.SendNext(StartObj1);
            stream.SendNext(StartObj2);
            if (Host)
            {
                stream.SendNext(WaterGun1);
                stream.SendNext(IsGame);
                stream.SendNext(IsEnd);
            }
            else
            {
                stream.SendNext(WaterGun2);
            }
        }
        else
        {
            this.StartObj1 = (GameObject)stream.ReceiveNext();
            this.StartObj2 = (GameObject)stream.ReceiveNext();
            if (Host)
            {
                this.WaterGun2 = (GameObject)stream.ReceiveNext();
            }
            else
            {
                this.WaterGun1 = (GameObject)stream.ReceiveNext();
                this.IsGame = (bool)stream.ReceiveNext();
                this.IsEnd = (bool)stream.ReceiveNext();
            }
        }*/
        /*if (stream.IsWriting)
        {

            if (WaterGun1Sc.IsBeingHeld())
            {
                //stream.SendNext(StartObj1);
               // stream.SendNext(WaterGun1);
                stream.SendNext(IsGame);
                stream.SendNext(IsEnd);
            }
            else if (WaterGun2Sc.IsBeingHeld())
            {
                //stream.SendNext(StartObj2);
                //stream.SendNext(WaterGun2);
            }
            else
            {

            }
        }
        else
        {
            if (WaterGun1Sc.IsBeingHeld())
            {
                //this.StartObj2 = (GameObject)stream.ReceiveNext();
                //this.WaterGun2 = (GameObject)stream.ReceiveNext();
            }
            else if (WaterGun2Sc.IsBeingHeld())
            {
                //this.StartObj1 = (GameObject)stream.ReceiveNext();
               // this.WaterGun1 = (GameObject)stream.ReceiveNext();
                this.IsGame = (bool)stream.ReceiveNext();
                this.IsEnd = (bool)stream.ReceiveNext();
            }
            else
            {
               // this.WaterGun2 = (GameObject)stream.ReceiveNext();
                //this.WaterGun1 = (GameObject)stream.ReceiveNext();
                this.IsGame = (bool)stream.ReceiveNext();
                this.IsEnd = (bool)stream.ReceiveNext();
            }
        }*/

        if (stream.IsWriting)
        {
            stream.SendNext(IsGame);
            stream.SendNext(IsEnd);
        }
        else
        {
            this.IsGame = (bool)stream.ReceiveNext();
            this.IsEnd = (bool)stream.ReceiveNext();
        }
    }
}
