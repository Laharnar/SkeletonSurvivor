using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtTransform : MonoBehaviour
{
    public Transform target;

    [Range(0.0f, 1.0f)]
    public float strength;

    // Update is called once per frame
    void Update()
    {
        transform.up = Vector3.Lerp(transform.up, (target.position - transform.position).normalized, strength);
    }
}
