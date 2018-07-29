using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections.Generic;

static class UniAniManager
{
    [RuntimeInitializeOnLoadMethod]
    static void Start()
    {
        GameObject gameObject = new GameObject();
        UniAniUpdateCaller updateCaller = gameObject.AddComponent<UniAniUpdateCaller>();
        updateCaller.name = "UniAniUpdateCaller";
        updateCaller.SetUpate(Update);
    }

    static void Update()
    {
        int index = 0;
        for (int i = 0; i < uniAniList.Count; i++)
        {
            uniAniList[index].Update();
            if (uniAniList[index].done)
            {
                uniAniList.Remove(uniAniList[index]);
                i++;
            }
            index++;
        }
    }

    public static void Delay(Action action, float animeTime){
        UniAni uniAni = new UniAni(uniAniList, animeTime, AnimationCurve.Linear(0, 0, 1, 1), AnimationType.ONCE);
        uniAni.SetEndAction(action);
    }

    static List<UniAni> uniAniList = new List<UniAni>();

    public static UniAni DoPosition(this Transform transform, Vector3 endPosition, float animeTime, AnimationCurve curve = null, AnimationType animationType = AnimationType.ONCE)
    {
        return new UniAniTransform(TransformType.POSITION, uniAniList, transform, endPosition, animeTime, curve, animationType);
    }

    public static UniAni DoLocalPosition(this Transform transform, Vector3 endPosition, float animeTime, AnimationCurve curve = null, AnimationType animationType = AnimationType.ONCE) {
        return new UniAniTransform(TransformType.LOCAL_POSITION, uniAniList, transform, endPosition, animeTime, curve, animationType);
    }

    public static UniAni DoScale(this Transform transform, Vector3 endScale, float animeTime, AnimationCurve curve = null, AnimationType animationType = AnimationType.ONCE)
    {
        return new UniAniTransform(TransformType.SCALE, uniAniList, transform, endScale, animeTime, curve, animationType);
    }

    public static UniAni DoRotation(this Transform transform, Vector3 endEulerAngles, float animeTime, AnimationCurve curve = null, AnimationType animationType = AnimationType.ONCE)
    {
        return new UniAniTransform(TransformType.ROTATION, uniAniList, transform, endEulerAngles, animeTime, curve, animationType);
    }

    public static UniAni DoColor(this Image image, Color endColor, float animeTime, AnimationCurve curve = null, AnimationType animationType = AnimationType.ONCE)
    {
        return new UniAniImage(uniAniList, image, endColor, animeTime, curve, animationType);
    }
}