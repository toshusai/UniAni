using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField]
    public int testCase;

    [ContextMenu("Test")]
    void UniAniTest()
    {
        switch (testCase)
        {
            case 0:
                transform.DoPosition(transform.position + Vector3.up * 3, 3f);
                break;
            case 1:
                transform.DoScale(new Vector3(2, 5, 1), 3f);
                break;
            case 2:
                transform.DoRotation(new Vector3(90, 45, 0), 3f);
                break;
            case 3:
                transform.DoPosition(transform.position + Vector3.up * 3, 1.5f, animationType: AnimationType.LOOP);
                break;
            case 4:
                transform.DoPosition(transform.position + Vector3.up * 3, 1.5f, animationType: AnimationType.TURN_LOOP);
                break;
            case 5:
                UniAni uniAni = transform.DoPosition(transform.position + Vector3.up * 3, 3f);
                UniAniManager.Delay(() =>
                {
                    uniAni.Kill();
                }, 1.5f);
                break;
        }
    }
}
