using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTracker : MonoBehaviour
{
    public Transform target;

    /// <summary>
    /// 업데이트 이후에 실행되는 함수
    /// </summary>
    private void LateUpdate()
    {
        if (target)
        {
            Vector3 pos = target.transform.position;
            pos.z = -10;
            transform.position = pos;
        }
    }
}
