using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviourPunCallbacks
{
    public string bulletOwner;

    // Start is called before the first frame update
    void Start()
    {
        //bulletOwner = photonView.Owner.NickName;
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 5000.0f);
        Destroy(this.gameObject, 20.0f);
    }
}
