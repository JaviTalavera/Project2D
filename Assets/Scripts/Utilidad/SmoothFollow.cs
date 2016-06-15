using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{

    public float dampTime = 0.15f;
    public float Offset = 5f;
    private Vector3 velocity = Vector3.zero;
    private Transform[] targets;

    // Update is called once per frame
    void Start ()
    {
        targets = new Transform[2];
        targets[0] = GameObject.FindGameObjectWithTag("Player1").gameObject.transform;
        targets[1] = GameObject.FindGameObjectWithTag("Player2").gameObject.transform;
    }

    void Update()
    {
        if (targets.Length > 0)
        {
            Vector3 midPoint = (targets[0].position + targets[1].position)/2 + Offset*Vector3.up;

            Vector3 point = Camera.main.WorldToViewportPoint(midPoint);
            Vector3 delta = midPoint - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}