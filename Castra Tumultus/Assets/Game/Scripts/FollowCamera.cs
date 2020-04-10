using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    float distance;
    public float yHeight;

    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.Distance(target.position, transform.position);
    }

    // Update is called once per frame

    void Update()
    {
        transform.position = new Vector3(target.position.x, yHeight, target.position.z - distance);
        transform.LookAt(target);
    }
}
