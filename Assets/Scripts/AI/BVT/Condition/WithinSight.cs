﻿using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class WithinSight : Conditional
{
    // Field of View Angle
    public float FieldOfViewAngle;

    // Aiming transform
    public SharedTransform AimingTransform;

    // Target transform
    public Transform targetTransform;

    public override TaskStatus OnUpdate()
    {
        if(targetTransform && isTargetInSight(targetTransform, FieldOfViewAngle))
        {
            AimingTransform.Value = targetTransform;
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }

    // Returns true if targetTransform is within sight of current transform
    public bool isTargetInSight(Transform targetTransform, float fieldOfViewAngle)
    {
        // #Todo: Add distance limit

        Vector3 direction = targetTransform.position - transform.position;
        // An object is within sight if the angle is less than field of view

        Debug.Log(Vector3.Angle(direction, transform.forward));
        return Vector3.Angle(direction, transform.forward) < fieldOfViewAngle;
    }
}
