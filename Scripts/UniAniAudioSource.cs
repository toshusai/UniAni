using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UniAniAudioSource : UniAni {
    private AudioSource audioSource;
    private float startVolume;
    private float endVolume;

    public UniAniAudioSource(List<UniAni> uniAniList_, AudioSource audioSource_, float volume_, float animeTime_, AnimationCurve curve_, AnimationType animationType_) :
    base(uniAniList_, animeTime_, curve_, animationType_) {
        audioSource = audioSource_;
        startVolume = audioSource.volume;
        endVolume = volume_;
    }

    protected override bool AnimationEnd() {
        audioSource.volume = endVolume;
        return true;
    }

    protected override void Animation(float pos) {
        base.Animation(pos);
        float leapVolume = startVolume + (endVolume - startVolume) * pos;
        audioSource.volume = leapVolume;
    }
}
