using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioCtrl instance;
    public Transform player;
    public GameObject bgMusic;
    //private bool bgMusicOn;

    [Header("Part1")]
    public AudioClip playerJump;
    public AudioClip coinPickup;

    [Header("Part2")]
    public AudioClip materSplash;
    public AudioClip keyFound;


    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerJump(Vector3 playerPos)
    {
        AudioSource.PlayClipAtPoint(playerJump, playerPos);
    }

    public void CoinPick(Vector3 playerPos)
    {
        AudioSource.PlayClipAtPoint(coinPickup, playerPos);
    }

    public void MuteBG()
    {
        if(bgMusic.activeSelf == true)
        {
            bgMusic.SetActive(false);
        }
        else
        {
            bgMusic.SetActive(true);
        }
    }
}
