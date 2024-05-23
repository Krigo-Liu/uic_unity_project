using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    public float speedBoost = 3;
    public bool leftPressed, rightPressed;
    private bool isDigging = false;

    // 定义三个检测器
    public Collider2D leftDetector;
    public Collider2D rightDetector;
    public Collider2D downDetector;

    public GameObject leftBullet;
    public GameObject rightBullet;
    public Transform leftSpawnPos;
    public Transform rightSpawnPos;


    public static PlayerCtrl instance; 
    // 矿块类型与延时的映射关系
    public Dictionary<string, float> mineBlockDelays = new Dictionary<string, float>
    {
        { "Ground", 0.1f },
        { "Tree", 0.2f },
        { "Coal", 0.3f },
        { "Iron", 0.4f },
        { "Red", 0.5f },
    };

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        anim = this.GetComponent<Animator>();
        UpdateMineBlockDelays();
    }

    void UpdateMineBlockDelays()
    {
        if (Equip.Instance.WoodTimes >= 0 || Equip.Instance.IronTimes >= 0)
        {
            mineBlockDelays["Ground"] = Equip.Instance.GetModifiedDelay("Ground");
            mineBlockDelays["Tree"] = Equip.Instance.GetModifiedDelay("Tree");
            mineBlockDelays["Coal"] = Equip.Instance.GetModifiedDelay("Coal");
            mineBlockDelays["Iron"] = Equip.Instance.GetModifiedDelay("Iron");
            mineBlockDelays["Red"] = Equip.Instance.GetModifiedDelay("Red");
            Debug.Log("Pickaxe selected.");
        }
        else
        {
            mineBlockDelays["Ground"] = 0.1f;
            mineBlockDelays["Tree"] = 0.2f;
            mineBlockDelays["Coal"] = 0.3f;
            mineBlockDelays["Iron"] = 0.4f;
            mineBlockDelays["Red"] = 0.5f;
        }
    }

    void Update()
    {
        float playerSpeed = Input.GetAxisRaw("Horizontal") * speedBoost;
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
            DigHorizantalSoil();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            DigDownSoil();
        }

        if (Input.GetButtonDown("Fire3")&& CraftingManager.instance.tool3Count_eq > 0)
        {
            SetBoom();
            CraftingManager.instance.UseBoom();
            Debug.Log("Boom -1.");
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
        if(playerSpeed < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        anim.SetInteger("state", 4);
    }

    void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        anim.SetInteger("state", 2);
    }

    public void DigDownSoil()
    {
        anim.SetInteger("state", 3);
        StartCoroutine(DiggingCoroutine(downDetector));
    }

    public void DigHorizantalSoil()
    {
        anim.SetInteger("state", 5);
        Collider2D detector = sr.flipX ? leftDetector : rightDetector;
        StartCoroutine(DiggingCoroutine(detector));
    }

    private IEnumerator DiggingCoroutine(Collider2D detector)
    {
        isDigging = true;
        yield return new WaitForSeconds(0.1f); // Make sure action with the animition

        Collider2D[] hits = Physics2D.OverlapCircleAll(detector.transform.position, 0.1f);
        foreach (Collider2D hit in hits)
        {
            
            
             // 获取矿块类型
             MineBlock mineBlock = hit.GetComponent<MineBlock>();
             if (mineBlock != null && mineBlockDelays.TryGetValue(mineBlock.blockType, out float delay))
             {
                 // 延时销毁矿块
                 StartCoroutine(DestroyWithDelay(hit.gameObject, delay));
             }
            
        }

        isDigging = false;
    }

    private IEnumerator DestroyWithDelay(GameObject mineBlock, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(mineBlock);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Item_wood"))
        {
            CraftingManager.instance.UpdateItem4();
            Destroy(other.gameObject);
            Equip.Instance.digafter();
        }

        if (other.gameObject.CompareTag("Item_Iron"))
        {
            CraftingManager.instance.UpdateItem3();
            Destroy(other.gameObject);
            Equip.Instance.digafter();
        }

        if (other.gameObject.CompareTag("Item_coal"))
        {
            CraftingManager.instance.UpdateItem2();
            Destroy(other.gameObject);
            Equip.Instance.digafter();
        }

        if (other.gameObject.CompareTag("Item_red_stone"))
        {
            CraftingManager.instance.UpdateItem1();
            Destroy(other.gameObject);
            Equip.Instance.digafter();
        }
    }

    public void SetBoom()
    {
        if (sr.flipX)
        {
            Instantiate(leftBullet, leftSpawnPos.position, Quaternion.identity);
        }
        else
        {
            Instantiate(rightBullet, rightSpawnPos.position, Quaternion.identity);
        }
    }
}
