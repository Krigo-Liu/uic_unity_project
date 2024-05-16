using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D rb;//declare a rigidbody
    SpriteRenderer sr;
    Animator anim;
    public float speedBoost = 3; 
    public float jumpForce = 100;

    public GameObject leftBullet;
    public Transform leftSpawnPos;

    public GameObject rightBullet;
    public Transform rightSpawnPos;

    //public Transform parent;

    public int jumpTimes = 0;
    bool fire_Activated = false;

    public bool leftPressed, rightPressed;

    //public int T = 2;
   // Start is called before the first frame update
   void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerSpeed = Input.GetAxisRaw("Horizontal");
        playerSpeed = playerSpeed * speedBoost;
        if (playerSpeed != 0 && jumpTimes == 0)
        {
            MoveHorizontal(playerSpeed);
        }
        else if (jumpTimes ==0 )
        {
            StopMoving();
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (jumpTimes <2)
            {
                anim.SetInteger("state", 2);
                AudioCtrl.instance.PlayerJump(transform.position);
                Jump();
                jumpTimes++;
            }
            
        }

        if (Input.GetButtonDown("Fire1"))
        {
            FireBullet();
        }


        if (rb.velocity.y < -1)
        {
            anim.SetInteger("state", 3);
        }

        if (leftPressed)
        {
            MoveHorizontal(-speedBoost);
        }

        if (rightPressed)
        {
            MoveHorizontal(speedBoost);
        }

    }
    void MoveHorizontal(float playerSpeed)
    {
        rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
        if (playerSpeed < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        if (jumpTimes == 0)
        {
            anim.SetInteger("state", 1);
        }


    }
    void StopMoving()
    {

        rb.velocity = new Vector2(0, rb.velocity.y);
        if(jumpTimes == 0)
        {
            anim.SetInteger("state", 0);
        }
    }
    public void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce));
    }

    public void FireBullet()
    {

        if (sr.flipX == true && fire_Activated == true)
        //if (sr.flipX == true)
        {
            Debug.Log("Start Fire!");
            Instantiate(leftBullet, leftSpawnPos.position, Quaternion.identity);

        }
        else if (sr.flipX == false && fire_Activated == true)
        //else if (sr.flipX == false)
        {
            Debug.Log("Start Fire!");
            Instantiate(rightBullet, rightSpawnPos.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider cube)
    {
        if (cube.tag == "player")
        {
            Debug.Log("A player");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            anim.SetInteger("state", 0);
            jumpTimes = 0;
            Debug.Log("on the ground");
        }

        //if (other.gameObject.CompareTag("Could"))
        //{
        //    anim.transform.SetParent(parent);
        //}
        //else
        //{
        //    anim.transform.SetParent(null);
        //}
    }

    void OnTriggerEnter2D(Collider2D cube)
    {
        if (cube.gameObject.CompareTag("coin"))
        {
            Destroy(cube.gameObject);
            SFXCtrl.instance.ShowCoinParticle(cube.gameObject.transform.position);
            GameCtrl.instance.updateCoin();
            GameCtrl.instance.updateScore(10);
            AudioCtrl.instance.CoinPick(transform.position);
            //fire_activated = true;

        }

        if (cube.gameObject.CompareTag("key"))
        {

            Destroy(cube.gameObject);
            SFXCtrl.instance.ShowExplosion(cube.gameObject.transform.position);
            fire_Activated = true;
            Debug.Log("Can fire");
        }

        if (cube.gameObject.CompareTag("flag"))
        {
            Destroy(cube.gameObject);
            GameCtrl.instance.updateScore(20);
            //fire_activated = true;

        }
    }

    public void MobileMoveLeft()
    {
        leftPressed = true;
    }

    public void MobileMoveRight()
    {
        rightPressed = true;
    }

    public void MobilesStop()
    {
        leftPressed = false;
        rightPressed = false;
        StopMoving();
    }

}
