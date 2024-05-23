using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarbageCollector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            Invoke("RestartLevel", 3); // µ÷ÓÃÑÓ³Ùº¯Êý£¬ÑÓ³Ù3Ãë
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene("Game_1");
    }
}
