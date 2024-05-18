//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using DG.Tweening;

//public class BeeAI : MonoBehaviour
//{
//    public GameObject player;
//    public float beeSpeed;
//    public int v = 10;


//    // Start is called before the first frame update
//    void Start()
//    {
//        transform.DOShakePosition(10f, new Vector3(0.5f, 0.5f, 0.5f), vibrato : v, randomness : 10);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        float dist = Vector3.Distance(player.transform.position, transform.position);
//        Debug.Log(dist);
//        if(dist < 5)
//        {
//            ActivateBee(player.transform.position);
//        }
//    }

//    public void ActivateBee(Vector3 playerPos)
//    {
//        transform.DOMove(playerPos, beeSpeed);
//    }

//    private void OnCollisionEnter2D(Collision2D othter)
//    {
//        if (othter.gameObject.CompareTag("bullet"))
//        {
//            Destroy(gameObject);
//            SFXCtrl.instance.ShowExplosion(gameObject.transform.position);
//        }
//    }
//}
