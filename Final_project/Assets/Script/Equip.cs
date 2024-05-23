using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equip : MonoBehaviour
{
    public static Equip Instance
    {
        get;
        private set;
    }

    public Button woodPickaxeButton; // ľ�䰴ť
    public Button ironPickaxeButton; // ���䰴ť
    public Button equipButton; // Equip ��ť

    private bool woodPickaxeSelected = false;
    private bool ironPickaxeSelected = false;
    private float currentDelayModifier = 0f; // ��ǰ����ʱ�޸�ֵ

    public int IronTimes = 0; 
    public int WoodTimes = 0;

    private Dictionary<string, float> baseDelays = new Dictionary<string, float>
    {
        { "Ground", 0.1f },
        { "Tree", 0.2f },
        { "Coal", 0.3f },
        { "Iron", 0.4f },
        { "Red", 0.5f },
    };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // ��Ӱ�ť����¼�������
        woodPickaxeButton.onClick.AddListener(OnWoodPickaxeButtonClick);
        ironPickaxeButton.onClick.AddListener(OnIronPickaxeButtonClick);
        equipButton.onClick.AddListener(OnEquipButtonClick);
    }

    private void OnWoodPickaxeButtonClick()
    {
        woodPickaxeSelected = true;
        ironPickaxeSelected = false;
        Debug.Log("Wood Pickaxe selected.");
    }

    private void OnIronPickaxeButtonClick()
    {
        ironPickaxeSelected = true;
        woodPickaxeSelected = false;
        Debug.Log("Iron Pickaxe selected.");
    }

    private void OnEquipButtonClick()
    {
        if (woodPickaxeSelected)
        {
            EquipWoodPickaxe();
            WoodTimes += 7;
            IronTimes = 0;
            CraftingManager.instance.UseWood();
        }
        else if (ironPickaxeSelected)
        {
            EquipIronPickaxe();
            WoodTimes = 0;
            IronTimes += 12;
            CraftingManager.instance.UseIron();
        }
        else
        {
            Debug.Log("No pickaxe selected.");
        }
    }

    private void EquipWoodPickaxe()
    {
        Debug.Log("Equipping Wood Pickaxe.");
        SpeedUpMining(); // �����ٶȼӿ�ķ���
        woodPickaxeSelected = false; // ���װ��������ѡ��״̬
    }

    private void EquipIronPickaxe()
    {
        Debug.Log("Equipping Iron Pickaxe.");
        SpeedUpMining(); // �����ٶȼӿ�ķ���
        ironPickaxeSelected = false; // ���װ��������ѡ��״̬
    }

    private void SpeedUpMining()
    {
        if (woodPickaxeSelected)
        {
            currentDelayModifier -= 0.02f;
        }
        else if (ironPickaxeSelected)
        {
            currentDelayModifier -= 0.05f;
        }
    }

    public float GetModifiedDelay(string blockType)
    {
        if (baseDelays.TryGetValue(blockType, out float baseDelay))
        {
            return baseDelay + currentDelayModifier;
        }
        else
        {
            Debug.LogError($"Block type {blockType} not found in dictionary.");
            return 0f;
        }
    }

    public void digafter()
    {
        if (WoodTimes > 0)
        {
            WoodTimes--;
        }
        else if(IronTimes > 0)
        {
            IronTimes--;
        }
    }
}