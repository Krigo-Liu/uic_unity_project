using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMyBag : MonoBehaviour
{
    public GameObject gamebagPanel; // �������
    public GameObject EquipmentPanel; // װ�����
    public GameObject SynthesisPanel; // �ϳ����

    private bool isBagOpen = false; // �����Ƿ��
    private bool isEquipmentOpen = false; // װ������Ƿ��
    private bool isSynthesisPanelOpen = false; // �ϳ�����Ƿ��

    // Start is called before the first frame update
    void Start()
    {
        // ��ʼ��ʱ�����������
        gamebagPanel.SetActive(false);
        EquipmentPanel.SetActive(false);
        SynthesisPanel.SetActive(false);
    }

    // ��/�رձ���
    public void ToggleBag()
    {
        isBagOpen = !isBagOpen;
        gamebagPanel.SetActive(isBagOpen);
    }

    // ��/�ر�װ�����
    public void ToggleEquipmentPanel()
    {
        isEquipmentOpen = !isEquipmentOpen;
        EquipmentPanel.SetActive(isEquipmentOpen);
    }

    // ��/�رպϳ����
    public void ToggleSynthesisPanel()
    {
        isSynthesisPanelOpen = !isSynthesisPanelOpen;
        SynthesisPanel.SetActive(isSynthesisPanelOpen);
    }
}
