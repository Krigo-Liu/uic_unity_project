using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;


public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D rb;//declare a rigidbody
    SpriteRenderer sr;
    Animator anim;
    public float speedBoost = 3; 

    public GameObject leftBullet;
    public Transform leftSpawnPos;

    public GameObject rightBullet;
    public Transform rightSpawnPos;

    public bool leftPressed, rightPressed;
    public int dig = 0;

    public int boomNumber = 0; 
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
        if (playerSpeed != 0)
        {
            MoveHorizontal(playerSpeed);
        }
        else
        {
            StopMoving();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            //anim.SetInteger("state", 5);
            DigHorizantalSoil();
            dig = 1;
            
        }

        if (Input.GetButtonDown("Fire2"))
        {
            //anim.SetInteger("state", 3);
            DigDownSoil();
            dig = 2;
        }

        if (Input.GetButtonDown("Fire3") && sr.flipX == true)
        {
            if (boomNumber > 0)
            {
                Instantiate(leftBullet, leftSpawnPos.position, Quaternion.identity);
                boomNumber -= 1;
            }
        }
        else if(Input.GetButtonDown("Fire3") && sr.flipX == false)
        {
            
            if (boomNumber > 0)
            {
                Instantiate(rightBullet, rightSpawnPos.position, Quaternion.identity);
                UseBoom();
            }
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
            
            anim.SetInteger("state", 4);
        }
        else
        {
            
            sr.flipX = false;
            
            anim.SetInteger("state", 4);
        }



    }
    void StopMoving()
    {

        rb.velocity = new Vector2(0, rb.velocity.y);
        
        anim.SetInteger("state", 2);
        
    }
 

    public void DigDownSoil(Collision2D cube)
    {

        anim.SetInteger("state", 3);
        dig = 2;
        //if (cube.gameObject.CompareTag("Ground"))
        //{
        //    Debug.Log("Have trigger down and tag compare");
        //    anim.SetInteger("state", 3);
        //    Destroy(cube.gameObject);
        //}

    }

    public void DigHorizantalSoil(Collision2D cube)
    {
        //if (other.gameObject.CompareTag("Ground"))
        //{
        //    Destory(other.gameObject);

        //    Debug.Log("on the ground");
        //}
        anim.SetInteger("state", 5);

    }


    void OnTriggerStay2D(Collider2D cube)
    {
        if (cube.gameObject.CompareTag("Boom"))
        {
            Destroy(cube.gameObject);
            //SFXCtrl.instance.ShowCoinParticle(cube.gameObject.transform.position);
            GameCtrl.instance.updateBoom();
            boomNumber += 1;
            //AudioCtrl.instance.CoinPick(transform.position);
            //fire_activated = true;

        }
        
        if (cube.gameObject.CompareTag("Ground") && dig == 1)
        {
            Debug.Log("Have trigger horizantal and tag compare");
            
            Destroy(cube.gameObject);
            if(dig == 1)
            {
                dig = 0;
            }

            
        }

    }

    void UseBoom()
    {
        GameCtrl.instance.deleteBoom();
        boomNumber -= 1;
    }

    //void OnCollisionStay2D(Collision2D cube)
    //{


    //    if (cube.gameObject.CompareTag("Ground") && dig == 2)
    //    {
    //        Debug.Log("Have trigger down and tag compare");

    //        Destroy(cube.gameObject);
    //        if (dig == 2)
    //        {
    //            dig = 0;
    //        }

    //    }

    //}

  
    //public void MobileMoveLeft()
    //{
    //    leftPressed = true;
    //}

    //public void MobileMoveRight()
    //{
    //    rightPressed = true;
    //}

    //public void MobilesStop()
    //{
    //    leftPressed = false;
    //    rightPressed = false;
    //    StopMoving();
    //}

}
