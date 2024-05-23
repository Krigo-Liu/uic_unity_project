using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSwitcher : MonoBehaviour
{
    public Transform playerTransform; // 角色的 Transform
    public GameObject groundBackground; // 地面背景
    public GameObject undergroundBackground; // 地下背景
    public float undergroundThreshold = -5.0f; // 判断地下的阈值

    private bool isUnderground = false; // 角色是否在地下

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 检查角色是否在地下
        if (playerTransform.position.y < undergroundThreshold)
        {
            if (!isUnderground)
            {
                // 切换到地下背景
                groundBackground.SetActive(false);
                undergroundBackground.SetActive(true);
                isUnderground = true;
            }
        }
        else
        {
            if (isUnderground)
            {
                // 切换到地面背景
                groundBackground.SetActive(true);
                undergroundBackground.SetActive(false);
                isUnderground = false;
            }
        }

        // 背景图跟随角色移动
        Vector3 newPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        groundBackground.transform.position = newPosition;
        undergroundBackground.transform.position = newPosition;
    }
}
