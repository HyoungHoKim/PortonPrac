using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField]
    private Transform tr;
    private Animator anim;

    [Range(5.0f, 10.0f)]
    public float speed = 5.0f;

    private readonly int hashSpeed = Animator.StringToHash("Speed");
    private readonly int hashSide = Animator.StringToHash("Side");

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
}
