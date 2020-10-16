using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFlatfrom : MonoBehaviour
{
    public Transform Pos1, Pos2;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == Pos1.position)
        {
            nextPos = Pos2.position;
        }
        if (transform.position == Pos2.position)
        {
            nextPos = Pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

    }
}
