using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationType
{
    ONCE,
    LOOP,
    REVERSE,
    TURN_LOOP
}

public class UniAni
{
    public bool done = false;
    protected List<UniAni> uniAniList;

    protected float startTime;
    protected float animeTime = 1;
    protected AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    protected Action endAction = () => { };
    protected AnimationType animationType = AnimationType.ONCE;

    public UniAni(List<UniAni> uniAniList_, float animeTime_, AnimationCurve curve_, AnimationType animationType_)
    {
        uniAniList_.Add(this);
        uniAniList = uniAniList_;
        startTime = Time.timeSinceLevelLoad;
        animeTime = animeTime_;
        animationType = animationType_;
        if (curve_ == null)
        {
            curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        }
        else
        {
            curve = curve_;
        }
    }

    public void SetEndAction(Action endAction_)
    {
        this.endAction = endAction_;
    }

    public virtual bool AnimationEnd()
    {
        return true;
    }

    public virtual void Animation(float pos)
    {

    }

    public void Kill()
    {
        done = true;
    }

    public void Update()
    {
        float diff = Time.timeSinceLevelLoad - startTime;
        if (diff > animeTime)
        {
            switch (animationType)
            {
                case AnimationType.ONCE:
                    break;
                case AnimationType.LOOP:
                    startTime = Time.timeSinceLevelLoad;
                    return;
            }
            if(!AnimationEnd()){
                return;
            }
            endAction();
            done = true;
        }

        float rate = diff / animeTime;
        float pos = curve.Evaluate(rate);
        Animation(pos);
    }
}