//using UnityEngine;

//public class backgroundSwitcher : MonoBehaviour
//{
//    public Transform playerTransform; // ��ɫ�� Transform
//    public GameObject groundBackground; // ���汳��
//    public GameObject undergroundBackground; // ���±���
//    public float undergroundThreshold = -5.0f; // �жϵ��µ���ֵ

//    private bool isUnderground = false; // ��ɫ�Ƿ��ڵ���

//    void Update()
//    {
//        // ����ɫ�Ƿ��ڵ���
//        if (playerTransform.position.y < undergroundThreshold)
//        {
//            if (!isUnderground)
//            {
//                // �л������±���
//                groundBackground.SetActive(false);
//                undergroundBackground.SetActive(true);
//                isUnderground = true;
//            }
//        }
//        else
//        {
//            if (isUnderground)
//            {
//                // �л������汳��
//                groundBackground.SetActive(true);
//                undergroundBackground.SetActive(false);
//                isUnderground = false;
//            }
//        }

//        // ����ͼ�����ɫ�ƶ�
//        Vector3 newPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
//        groundBackground.transform.position = newPosition;
//        undergroundBackground.transform.position = newPosition;
//    }
//}
