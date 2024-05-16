using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeTrigger : MonoBehaviour
{
    public GameObject bee;
    BeeAI beeAi;
    // Start is called before the first frame update
    void Start()
    {
        beeAi = bee.GetComponent<BeeAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            beeAi.ActivateBee(collision.gameObject.transform.position);
        }
    }
}