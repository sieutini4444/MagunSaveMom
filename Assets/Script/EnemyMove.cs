using Pathfinding.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public float speed;

    public Rigidbody2D rigibody;
    public BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacing())
        {
            rigibody.velocity = new Vector2(speed, 0f);
        }
        else
        {
            rigibody.velocity = new Vector2(-speed, 0f);
        }
    }



    bool IsFacing() 
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
}
