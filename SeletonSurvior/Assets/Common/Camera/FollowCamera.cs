using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    [Range(0.0f, 1.0f)]
    public float followStrength = 0.8f;

    public bool keepX, keepY, keepZ;

    // Update is called once per frame
    void Update()
    {
        Vector3 v = Vector3.Lerp(transform.position, target.position, followStrength);
        Vector3 dir = v-transform.position;
        if (keepX)
        {
            dir.x = 0;
        }
        if (keepY)
        {
            dir.y = 0;
        }
        if (keepZ)
        {
            dir.z = 0;
        }
        transform.Translate(dir*Time.deltaTime*30);
    }
}
