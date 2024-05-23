using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMyBag : MonoBehaviour
{
    public GameObject gamebagPanel; // 背包面板
    public GameObject EquipmentPanel; // 装备面板
    public GameObject SynthesisPanel; // 合成面板

    private bool isBagOpen = false; // 背包是否打开
    private bool isEquipmentOpen = false; // 装备面板是否打开
    private bool isSynthesisPanelOpen = false; // 合成面板是否打开

    // Start is called before the first frame update
    void Start()
    {
        // 初始化时隐藏所有面板
        gamebagPanel.SetActive(false);
        EquipmentPanel.SetActive(false);
        SynthesisPanel.SetActive(false);
    }

    // 打开/关闭背包
    public void ToggleBag()
    {
        isBagOpen = !isBagOpen;
        gamebagPanel.SetActive(isBagOpen);
    }

    // 打开/关闭装备面板
    public void ToggleEquipmentPanel()
    {
        isEquipmentOpen = !isEquipmentOpen;
        EquipmentPanel.SetActive(isEquipmentOpen);
    }

    // 打开/关闭合成面板
    public void ToggleSynthesisPanel()
    {
        isSynthesisPanelOpen = !isSynthesisPanelOpen;
        SynthesisPanel.SetActive(isSynthesisPanelOpen);
    }
}
