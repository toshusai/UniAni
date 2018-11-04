using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UniAniImage : UniAni {
    private Image image;
    private Color startColor;
    private Color endColor;

    public UniAniImage( List<UniAni> uniAniList_, Image image_, Color endColor_, float animeTime_, AnimationCurve curve_, AnimationType animationType_) :
    base(uniAniList_, animeTime_, curve_, animationType_) {
        image = image_;
        startColor = image.color;
        endColor = endColor_;
    }

    protected override bool AnimationEnd() {
        image.color = endColor;
        return true;
    }

    protected override void Animation(float pos) {
        if(image == null){
            done = true;
            return;
        }
        base.Animation(pos);
        Color leapColor = Color.Lerp(startColor, endColor, pos);
        image.color = leapColor;
    }
}
