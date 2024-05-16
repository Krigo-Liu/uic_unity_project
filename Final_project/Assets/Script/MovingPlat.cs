using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    public Transform post1, post2;
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
        if(transform.position == post1.position)
        {
            nextPos = post2.position;
        }
        if (transform.position == post2.position)
        {
            nextPos = post1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed = Time.deltaTime);
    }

}
