using UnityEngine;
using UnityEngine.UI;


public class UITextManager : MonoBehaviour
{
    Text myText;

    //Update the "clicks" text for each level
    private void Start()
    {
        myText = GetComponent<Text>();

        myText.text = PlayerStats.clicks.ToString();
    }

    public void UpdateClicks()
    {

        myText.text = PlayerStats.clicks.ToString();

    }
}
