using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCtrl : MonoBehaviour
{
    public GameObject sfx_coin_pickup;
    public GameObject sfx_explosion;
    public static SFXCtrl instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCoinParticle(Vector3 pos)
    {
        Instantiate(sfx_coin_pickup, pos, Quaternion.identity);
    }
    public void ShowExplosion(Vector3 pos)
    {
        Instantiate(sfx_explosion, pos, Quaternion.identity);
    }
}
