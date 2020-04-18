using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.WSA.Input;

public class AimAtTransform : MonoBehaviour
{
    public Transform target;

    [Range(0.0f, 1.0f)]
    public float strength;

    public bool fullAimOnStart = false;

    public Vec3VarRef targetPositionOnStart;
    public FloatVarRef distanceToTargetAtStart;

    public UnityEvent onStartEnd;

    void Start()
    {
        if (fullAimOnStart)
        {
            transform.up = target.position - transform.position;
        }

        targetPositionOnStart.Value = target.position;
        distanceToTargetAtStart.Value = Vector2.Distance(target.position, transform.position);
        onStartEnd?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = Vector3.Lerp(transform.up, (target.position - transform.position).normalized, strength);
    }
}
