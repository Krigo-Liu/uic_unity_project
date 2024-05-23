using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCtrl : MonoBehaviour
{
    public GameObject sfx_boom;
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

    public void ShowBoom(Vector3 pos)
    {
        Instantiate(sfx_boom, pos, Quaternion.identity);
    }

}
