using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public float MonsterSpeed;
    public int v = 10;

    void Start()
    {
        //transform.DOShakePosition(10f, new Vector3(0.5f, 0.5f, 0.5f), vibrato: v, randomness: 10);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log(dist);
        if (dist < 5 ) 
        {
            ActivateMonster(player.transform.position);
        }
    }

    public void ActivateMonster(Vector3 playerPos)
    {
        //transform.DOMove(player.transform.position, MonsterSpeed);

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            //SFXCtrl.instance.ShowEnemyExplosion(gameObject.transform.position);
        }
    }



}





