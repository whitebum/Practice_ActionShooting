using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTracker : MonoBehaviour
{
    public Transform target;

    /// <summary>
    /// ������Ʈ ���Ŀ� ����Ǵ� �Լ�
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
