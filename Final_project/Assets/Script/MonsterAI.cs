using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterAI : MonoBehaviour
{
    public Transform pointA; // Ѳ�����
    public Transform pointB; // Ѳ���յ�
    public float speed = 2f; // Ѳ���ٶ�
    public float waitTime = 2f; // ���ٽ��ĵȴ�ʱ��

    private Vector3 targetPosition; // Ŀ��λ��
    private bool isWaiting = false; // �Ƿ��ڵȴ�
    private Animator animator; // ����������
    private bool isFacingLeft = true; // ��ǰ����



    void Start()
    {
        targetPosition = pointA.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isWaiting)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        animator.SetBool("isWalking", true);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            StartCoroutine(WaitAndSwitchTarget());
        }
    }

    private System.Collections.IEnumerator WaitAndSwitchTarget()
    {
        isWaiting = true;
        animator.SetBool("isWalking", false);
        yield return new WaitForSeconds(waitTime);

        if (targetPosition == pointB.position)
        {
            targetPosition = pointA.position;
        }
        else
        {
            targetPosition = pointB.position;
        }

        Flip();
        isWaiting = false;
    }

    private void Flip()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }




}

