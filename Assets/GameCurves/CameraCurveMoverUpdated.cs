using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteAlways]
public class CameraCurveMoverUpdated : MonoBehaviour
{
    float t = 0f;

    [SerializeField]
    Transform target, followObject, rotatedObject;
    [SerializeField]
    float lerpSpeed = 0.5f, findStep = 0.05f, offset = 0.5f, rotationLerpSpeed, minZposClamp = -10f, maxZposClamp = 0f;
    [SerializeField]
    GameCurve curve;
    void Start()
    {

    }

    void Update()
    {
        //SelfMoving();
        t = curve.GetClosestTByHandler(target.position);
        Vector3 targetPos = curve.GetPointByT(t);
        followObject.position = Vector3.Lerp(followObject.position, targetPos, Time.deltaTime * lerpSpeed);
        BezieSegment seg = curve.GetSegmentByT(t);
        Transform a = seg.points[0], b = seg.points[3];
        Vector3 targ = new Vector3(0f, 0f, Mathf.Clamp(target.position.z, minZposClamp, maxZposClamp));
        float angle = Vector3.SignedAngle(Vector3.forward, targ - (transform.position + Vector3.down * offset), Vector3.right);
        //Quaternion targetRotation = Quaternion.LookRotation(targ - rotatedObject.position, Vector3.up);
        Quaternion targetRotation = Quaternion.Euler(angle, 0f, 0f);
        rotatedObject.rotation = Quaternion.Lerp(rotatedObject.rotation, targetRotation, Time.deltaTime * rotationLerpSpeed);
        rotatedObject.localEulerAngles = new Vector3(rotatedObject.localEulerAngles.x, rotatedObject.localEulerAngles.y, 0f);
    }
    void SelfMoving()
    {
        Vector3 dir = curve.GetDirectionByT(t);
        Vector3 tptr = (target.position - curve.GetPointByT(t)).normalized;
        float dotDist = Vector3.Dot(tptr, dir);
        if (dotDist > offset)
        {
            t = Mathf.Lerp(t, t + (findStep / curve.SegmentsNumber), Time.deltaTime * lerpSpeed);
        }

        //transform.position = curve.GetPointByT(t) + Vector3.back * 6f + Vector3.up * 4f;
    }


}
