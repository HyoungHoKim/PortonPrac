using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


[RequireComponent(typeof(AudioSource))]
public class FireCtrl : MonoBehaviourPunCallbacks
{
    public GameObject bullet;
    public Transform firePos;
    
    private AudioSource _audio;
    public MeshRenderer muzzleFlash;

    public AudioClip fireSfx;

    public float fireRate = 0.15f;
    private float nextFire = 0.0f;

    [SerializeField]
    private Light fireLight;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        muzzleFlash.enabled = false;
        fireLight = firePos.Find("Point Light").GetComponent<Light>();
        fireLight.intensity = 0.0f;
    }


    void Update()
    {
        if (!photonView.IsMine) return;

        if (Input.GetMouseButton(0)) // 0 : Left Mouse Btn, 1 : Right Mouse Btn, 2 : Middle Button
        {
            if (nextFire <= Time.time)
            {
                Fire(PhotonNetwork.NickName);

                photonView.RPC("Fire", RpcTarget.Others, PhotonNetwork.NickName);
                nextFire = Time.time + fireRate;
            }
        }
    }

    [PunRPC]
    void Fire(string fireOwner)
    {
        _audio.PlayOneShot(fireSfx, 0.8f);
        var _bullet = Instantiate(bullet, firePos.position, firePos.rotation);
        _bullet.GetComponent<Bullet>().bulletOwner = fireOwner;

        StartCoroutine(ShowMuzzleFlash());
    }

    IEnumerator ShowMuzzleFlash()
    {
        // scale
        Vector3 _scale = Vector3.one * Random.Range(1.0f, 3.0f);
        muzzleFlash.transform.localScale = _scale;

        //Rotation
        Quaternion rot = Quaternion.Euler(Vector3.forward * Random.Range(0, 360));
        muzzleFlash.transform.localRotation = rot;

        //Random Texture 
        Vector2 offset = new Vector2(Random.Range(0, 2), Random.Range(0, 2)) * 0.5f;
        muzzleFlash.material.SetTextureOffset("_MainTex", offset);


        //Fire Light On
        fireLight.intensity = Random.Range(0.8f, 3.0f);

        muzzleFlash.enabled = true;
       
        yield return new WaitForSeconds(0.1f);
        muzzleFlash.enabled = false;
        //Fire Light Off
        fireLight.intensity = 0.0f;

    }
}
