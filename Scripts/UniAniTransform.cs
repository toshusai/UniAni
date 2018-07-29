using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TransformType
{
    POSITION,
    LOCAL_POSITION,
    SCALE,
    ROTATION
}

public class UniAniTransform : UniAni
{
    private TransformType transformType;
    private Transform transform;
    private Vector3 startVector;
    private Vector3 endVector;

    public UniAniTransform(TransformType transformType_, List<UniAni> uniAniList_, Transform transform_, Vector3 endVector_, float animeTime_, AnimationCurve curve_, AnimationType animationType_) :
    base(uniAniList_, animeTime_, curve_, animationType_)
    {
        transformType = transformType_;
        transform = transform_;
        endVector = endVector_;
        switch (transformType_)
        {
            case TransformType.POSITION:
                startVector = transform.position;
                break;
            case TransformType.LOCAL_POSITION:
                startVector = transform.localPosition;
                break;
            case TransformType.SCALE:
                startVector = transform.localScale;
                break;
            case TransformType.ROTATION:
                startVector = transform.rotation.eulerAngles;
                break;
        }
    }

    public override bool AnimationEnd()
    {
        switch (transformType)
        {
            case TransformType.POSITION:
                transform.position = endVector;
                break;
            case TransformType.LOCAL_POSITION:
                transform.localPosition = endVector;
                break;
            case TransformType.SCALE:
                transform.localScale = endVector;
                break;
            case TransformType.ROTATION:
                transform.eulerAngles = endVector;
                break;
        }
        switch (animationType)
        {
            case AnimationType.TURN_LOOP:
                startTime = Time.timeSinceLevelLoad;
                switch (transformType)
                {
                    case TransformType.POSITION:
                        endVector = startVector;
                        startVector = transform.position;
                        break;
                    case TransformType.LOCAL_POSITION:
                        endVector = startVector;
                        startVector = transform.localPosition;
                        break;
                    case TransformType.SCALE:
                        endVector = startVector;
                        startVector = transform.localScale;
                        break;
                    case TransformType.ROTATION:
                        endVector = startVector;
                        startVector = transform.eulerAngles;
                        break;
                }
                return false;
        }
        return true;
    }

    public override void Animation(float pos)
    {
        if (transform == null) {
            uniAniList.Remove(this);
        }
        base.Animation(pos);
        Vector3 lerpVector = Vector3.Lerp(startVector, endVector, pos);
        switch (transformType)
        {
            case TransformType.POSITION:
                transform.position = lerpVector;
                break;
            case TransformType.LOCAL_POSITION:
                transform.localPosition = lerpVector;
                break;
            case TransformType.SCALE:
                transform.localScale = lerpVector;
                break;
            case TransformType.ROTATION:
                transform.eulerAngles = lerpVector;
                break;
        }
    }
}