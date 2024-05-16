using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileUICtrl : MonoBehaviour
{
    public GameObject player;
    PlayerCtrl playerCtrl;
    
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = player.GetComponent<PlayerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MobileMoveLeft()
    {
        playerCtrl.MobileMoveLeft();
    }

    public void MobileMoveRight()
    {
        playerCtrl.MobileMoveRight();
    }

    public void MobileStop()
    {
        playerCtrl.MobilesStop();
    }

    public void MobileFire()
    {
        playerCtrl.FireBullet();
    }

    public void MobileJump()
    {
        playerCtrl.Jump();
    }
}
