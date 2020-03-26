using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerCtrl : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform tr;
    private Animator anim;

    [Range(5.0f, 10.0f)]
    public float speed = 5.0f;

    private readonly int hashSpeed = Animator.StringToHash("Speed");
    private readonly int hashSide = Animator.StringToHash("Side");

    private FollowCam followCam;
    public TMP_Text playerName;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();

        playerName.text = photonView.Owner.NickName;

        if (photonView.IsMine)
        {
            followCam = Camera.main.GetComponent<FollowCam>();
            followCam.target = tr;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!photonView.IsMine)
        {
            return;
        }

        float v = Input.GetAxisRaw("Vertical"); // W, S or Up, Down / -1.0f ~ 0.0f ~ +1.0f
        float h = Input.GetAxisRaw("Horizontal"); // A, D

        //벡터의 덧셈 연산 
        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(dir.normalized * speed * Time.deltaTime);

        //회전
        float r = Input.GetAxis("Mouse X");
        tr.Rotate(Vector3.up * r * Time.deltaTime * 100.0f);

        //animation 처리
        anim.SetFloat(hashSpeed, v);
        anim.SetFloat(hashSide, h);

    }

    private float initHp = 100.0f;
    private float currHp = 100.0f;

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            string killer = coll.gameObject.GetComponent<Bullet>().bulletOwner;
            Debug.Log($"Hit by {killer} !!!");

            currHp -= 10.0f;
            if(currHp <= 0.0f)
            {
                Debug.Log("Killed by " + killer);
            }
        }
    }
}
