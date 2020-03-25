using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    private Transform tr;
    public Transform target;

    public float distance = 10.0f;
    public float height = 5.0f;
    public float hOffset = 2.0f;

    public float damping = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        tr = transform; // GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 nextPos = target.position + (-target.forward * distance) + (Vector3.up * height);

        tr.position = Vector3.Lerp(tr.position, nextPos, Time.deltaTime * damping);
        tr.LookAt(target.position + (Vector3.up * hOffset));
    }
}
