using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WaterParticle : MonoBehaviourPunCallbacks, IPunObservable
{
	PhotonView m_photonView;
	private float CollisionTime = 0.0f;
	private void Awake()
	{
		m_photonView = GetComponent<PhotonView>();
	}

	void OnParticleCollision(GameObject obj)
	{
		if(obj.layer == 10)
		{
			/*Vector3 wcenter = obj.transform.position;
			Vector3 lcenter = obj.GetComponent<CapsuleCollider>().center;
			float radius = obj.GetComponent<CapsuleCollider>().radius;*/
			if (obj.GetComponent< PhotonView>().OwnerActorNr != m_photonView.OwnerActorNr)
			{
				CollisionTime += Time.deltaTime;
			}
		}
	}


	public void TimeReset()
    {
		CollisionTime = 0;
	}

	public float GetTime()
    {
		return CollisionTime;
	}
	public void TransferOwnership()
	{
		m_photonView.RequestOwnership();
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
		if (stream.IsWriting)
        {
			stream.SendNext(CollisionTime);
		}
        else
        {
			this.CollisionTime = (float)stream.ReceiveNext();
		}
	}
}
