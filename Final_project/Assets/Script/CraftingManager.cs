using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    // UI Elements
    public Button tool1Button, tool2Button, tool3Button, craftButton;
    public Text item1Text, item2Text, item3Text, item4Text;
    public Text tool1Text, tool2Text, tool3Text;
    public Text tool1Text_eq, tool2Text_eq, tool3Text_eq;

    // Inventory
    public int item1Count = 10; // Red Stone
    public int item2Count = 10; // Coal
    public int item3Count = 10; // Iron
    public int item4Count = 10; // Wood

    public int tool1Count = 0;
    public int tool2Count = 0;
    public int tool3Count = 0;

    public int tool1Count_eq = 0;
    public int tool2Count_eq = 0;
    public int tool3Count_eq = 0;

    // Current selected tool
    private int selectedTool = 0;

    public static CraftingManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        // Initialize UI text
        UpdateUI();

        // Add listeners to buttons
        tool1Button.onClick.AddListener(() => SelectTool(1));
        tool2Button.onClick.AddListener(() => SelectTool(2));
        tool3Button.onClick.AddListener(() => SelectTool(3));
        craftButton.onClick.AddListener(CraftTool);
    }

    void SelectTool(int tool)
    {
        selectedTool = tool;
        UpdateUI();
    }

    void CraftTool()
    {
        bool success = false;

        switch (selectedTool)
        {
            case 1:
                if (item1Count >= 4 )
                {
                    item1Count -= 4;
                    tool1Count += 1;
                    tool1Count_eq += 1;
                    success = true;
                }
                break;
            case 2:
                if (item2Count >= 2 && item1Count >= 2)
                {
                    item2Count -= 2;
                    item1Count -= 2;
                    tool2Count += 1;
                    tool2Count_eq += 1;
                    success = true;
                }
                break;
            case 3:
                if (item3Count >= 3 && item4Count >= 1)
                {
                    item3Count -= 3;
                    item4Count -= 1;
                    tool3Count += 1;
                    tool3Count_eq += 1;
                    success = true;
                }
                break;
        }

        if (success)
        {
            UpdateUI();
        }
    }


    public void UpdateItem1()
    {
        item1Count++;
        UpdateUI();
    }

    public void UpdateItem2()
    {
        item2Count++;
        UpdateUI();
    }

    public void UpdateItem3()
    {
        item3Count++;
        UpdateUI();
    }

    public void UpdateItem4()
    {
        item4Count++;
        UpdateUI();
    }

    public void UseBoom()
    {
        tool3Count--;
        tool3Count_eq--;
        UpdateUI();
    }

    public void UseWood()
    {
        tool1Count--;
        tool1Count_eq--;
        UpdateUI();
    }

    public void UseIron()
    {
        tool2Count--;
        tool2Count_eq--;
        UpdateUI();
    }

    void UpdateUI()
    {
        item1Text.text = item1Count.ToString();
        item2Text.text = item2Count.ToString();
        item3Text.text = item3Count.ToString();
        item4Text.text = item4Count.ToString();

        tool1Text.text = tool1Count.ToString();
        tool2Text.text = tool2Count.ToString();
        tool3Text.text = tool3Count.ToString();

        tool1Text_eq.text = tool1Count_eq.ToString();
        tool2Text_eq.text = tool2Count_eq.ToString();
        tool3Text_eq.text = tool3Count_eq.ToString();
    }
}


