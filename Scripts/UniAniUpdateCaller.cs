using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniAniUpdateCaller : MonoBehaviour
{
    private Action action;

    public void SetUpate(Action action_)
    {
        DontDestroyOnLoad(this.gameObject);
        action = action_;
    }
    private void Update()
    {
        action();
    }
}
