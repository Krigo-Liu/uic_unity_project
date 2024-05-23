using UnityEngine;
using TMPro;
public class ToolDescription : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text descriptionText;

    public void OnButton1Click()
    {
        descriptionText.text = "A pickaxe made from an all-natural, easily available material, but it does not seem to be very durable";
    }

    public void OnButton2Click()
    {
        descriptionText.text = "Tools that are more handy and durable symbolize that you have explored the underground and successfully entered the Iron Age";
    }

    public void OnButton3Click()
    {
        descriptionText.text = "Boom~ The underground rocks collapsed. It is not only a tool to improve efficiency, but also a weapon to challenge strange creatures";
    }
}