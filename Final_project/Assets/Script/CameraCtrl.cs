using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform player; // ��ɫ��Transform
    public Transform background; // ������Transform
    public Transform uiCanvas; // Canvas��Transform

    public float smoothSpeed = 0.125f; // ƽ���ƶ��ٶ�

    void Update()
    {
        if (player != null && background != null)
        {
            Vector3 desiredBackgroundPosition = new Vector3(player.position.x, player.position.y, background.position.z);
            Vector3 smoothedBackgroundPosition = Vector3.Lerp(background.position, desiredBackgroundPosition, smoothSpeed);
            background.position = smoothedBackgroundPosition;
        }

        if (player != null && uiCanvas != null)
        {
            Vector3 desiredCanvasPosition = new Vector3(player.position.x, player.position.y, uiCanvas.position.z);
            Vector3 smoothedCanvasPosition = Vector3.Lerp(uiCanvas.position, desiredCanvasPosition, smoothSpeed);
            uiCanvas.position = smoothedCanvasPosition;
        }
    }
}
