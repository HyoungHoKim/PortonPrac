using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    
    private AudioSource _audio;
    public MeshRenderer muzzleFlash;

    public AudioClip fireSfx;

    public float fireRate = 0.15f;
    private float nextFire = 0.0f;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        muzzleFlash.enabled = false;

    }


    void Update()
    {
        if (Input.GetMouseButton(0)) // 0 : Left Mouse Btn, 1 : Right Mouse Btn, 2 : Middle Button
        {
            if (nextFire <= Time.time)
            {
                Fire();
                nextFire = Time.time + fireRate;
            }
        }
    }

    void Fire()
    {
        _audio.PlayOneShot(fireSfx, 0.8f);
        Instantiate(bullet, firePos.position, firePos.rotation);
        StartCoroutine(ShowMuzzleFlash());
    }

    IEnumerator ShowMuzzleFlash()
    {
        // scale
        Vector3 _scale = Vector3.one * Random.Range(1.0f, 3.0f);
        muzzleFlash.transform.localScale = _scale;
        
        //Rotation


        muzzleFlash.enabled = true;


        yield return new WaitForSeconds(0.1f);
        muzzleFlash.enabled = false;

    }
}
