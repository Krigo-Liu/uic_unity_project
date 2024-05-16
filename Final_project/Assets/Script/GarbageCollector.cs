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
            Invoke("restartLevel", 3);// Invoke : to call a function after a delay
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

        void restartLevel()
        {
            SceneManager.LoadScene("GamePlay_desert");
    }
}
