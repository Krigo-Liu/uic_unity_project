using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public Vector2 velocity;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //float playerSpeed = Input.GetAxisRaw("Horizontal");
        //rb.velocity = new Vector2(playerSpeed*100, rb.velocity.y);
        rb.velocity = velocity;
        
    }
}
