using System;
using System.Collections;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[InitializeOnLoad]
static class UniAniManager
{
    static UniAniManager()
    {
        EditorApplication.update += Update;
    }

    static void Update()
    {
        int index = 0;
        for (int i = 0; i < unimeList.Count; i++)
        {
            unimeList[index].Update();
            if (unimeList[index].done)
            {
                unimeList.Remove(unimeList[index]);
                i++;
            }
            index++;
        }
    }

    static List<UniAni> unimeList = new List<UniAni>();

    public static UniAni Move(this Transform transform, Vector3 endPosition, float time)
    {
        UniAni unime = new UniAni(unimeList, transform, endPosition, time, AnimationCurve.EaseInOut(0, 0, 1, 1));
        unimeList.Add(unime);
        return unime;
    }

    public static UniAni Move(this Transform transform, Vector3 endPosition, float time, AnimationCurve curve)
    {
        UniAni unime = new UniAni(unimeList, transform, endPosition, time, curve);
        unimeList.Add(unime);
        return unime;
    }
}