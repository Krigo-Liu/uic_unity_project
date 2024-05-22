using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour
{
    public GameObject player;
    public static GameCtrl instance;
    public Text txtCoinCount;
    public Text txtScore;
    public Text txtTimer;
    int coinCnt =0;
    int score = 0;
    int remaindTime;
    //int Totaltime = 100;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDie()
    {
        player.SetActive(false);
        Invoke("restartLevel", 3);// Invoke : to call a function after a delay
    }

    public void PlayerDieAnimationa()
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-150f, 400f));
        player.transform.Rotate(new Vector3(0, 0, 45f));

        player.GetComponent<PlayerCtrl>().enabled = false;
        player.GetComponent<Animator>().enabled = false;

        //foreach(Collider2D c2d)
    }


    public void updateBoom()
    {
        coinCnt++;
        txtCoinCount.text = "x " + coinCnt;
    }

    public void deleteBoom()
    {
        coinCnt--;
        txtCoinCount.text = "x " + coinCnt;
    }

    public void updateScore(int value)
    {
        score += value;
        txtScore.text = "Score: " + score;
    }

    private void updateTime(int time)
    {
        txtTimer.text = "Time: " + time;
    }
}
