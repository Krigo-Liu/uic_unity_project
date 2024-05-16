using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangetoDynamic : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerFeet"))
        {
            Invoke("starFalling", 1);

        }

    }

    void starFalling()
    {
        rb.isKinematic = false;
    }
}
