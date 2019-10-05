

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniAniAction : UniAni
{
    public Action<float> action;
    public UniAniAction(List<UniAni> uniAniList_, Action<float> action_, float animeTime_, AnimationCurve curve_, AnimationType animationType_) :
        base(uniAniList_, animeTime_, curve_, animationType_)
    {
        action = action_;
    }

    protected override void Animation(float pos)
    {
        base.Animation(pos);
        action(pos);
    }
}