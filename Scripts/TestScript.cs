using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [ContextMenu("RunTest")]
    void UniAniTest()
    {
        transform.Move(new Vector3(3, 3, 3), 3f).End(() => { Debug.Log("Animation end!"); });
    }
}
