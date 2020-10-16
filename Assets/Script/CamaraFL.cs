using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFL : MonoBehaviour
{

    public Transform target;

    private void LateUpdate()
    {
        transform.position = new Vector2(target.position.x, target.position.y);
    }
}
