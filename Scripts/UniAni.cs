using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniAni
{
    public bool done = false;
    private List<UniAni> unimeList;

    private Transform transform;
    private Vector3 endPosition;
    private float time = 1;
    AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private Action end;

    private float startTime;
    private Vector3 startPosition;

    public UniAni(List<UniAni> unimeList, Transform transform, Vector3 endPosition, float time, AnimationCurve curve)
    {
        this.unimeList = unimeList;
        this.transform = transform;
        this.startTime = Time.timeSinceLevelLoad;
        this.endPosition = endPosition;
        this.time = time;
        this.curve = curve;
    }

    public void End(Action end)
    {
        this.end = end;
    }

    public void Update()
    {
        var diff = Time.timeSinceLevelLoad - startTime;
        if (diff > time)
        {
            transform.position = endPosition;
            end();
            done = true;
        }

        var rate = diff / time;
        var pos = curve.Evaluate(rate);

        transform.position = Vector3.Lerp(startPosition, endPosition, pos);
    }
}