using UnityEngine;
using UnityEngine.UI;

public class ChangeImages : MonoBehaviour
{
    public Button changeButton; // 按钮对象
    public Image image1; 
    public Image image2;
    public Image image3;
    public Sprite newSprite1; 
    public Sprite newSprite2; 
    public Sprite newSprite3; 

    void Start()
    {
   
        changeButton.onClick.AddListener(OnChangeButtonClick);
    }

    void OnChangeButtonClick()
    {
        // 改变两个Image组件的图片
        image1.sprite = newSprite1;
        image2.sprite = newSprite2;
        image3.sprite = newSprite3;
    }
}

