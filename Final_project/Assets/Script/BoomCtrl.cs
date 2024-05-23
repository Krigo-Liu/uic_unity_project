using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomCtrl : MonoBehaviour
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
        rb.velocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {


            // ���ٵ������
            Destroy(other.gameObject);
            Debug.Log("Destroy");

        }
    }
}