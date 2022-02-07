using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Vector3 offset;

    private void LateUpdate()
    {
        var pos = Camera.main.transform.position;
        pos /= 1.2f;
        pos.x += offset.x;
        pos.y += offset.y;
        pos.z = 0;
        transform.position = pos;
    }
}
