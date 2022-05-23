using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonHandler : MonoBehaviour
{
    [SerializeField]
    string buttonType;

    [SerializeField]
    Sprite mode1;

    [SerializeField]
    Sprite mode2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeButton()
    {
        switch (buttonType)
        {
            case "FX":
                if (GameObject.FindObjectOfType<SoundManager>().FxEnabled)
                {
                    gameObject.GetComponent<Button>().colors = ReverseColor(Color.white);
                }
                else
                {
                    gameObject.GetComponent<Button>().colors = ReverseColor(Color.black);
                }
                break;
            case "BG":
                if (GameObject.FindObjectOfType<SoundManager>().MusicEnabled)
                {
                    gameObject.GetComponent<Button>().colors = ReverseColor(Color.white);
                }
                else
                {
                    gameObject.GetComponent<Button>().colors = ReverseColor(Color.black);
                }
                break;
            case "PushDown":
                if (gameObject.transform.Find("PushDownIcon").GetComponent<Image>().sprite == mode1)
                {
                    gameObject.transform.Find("PushDownIcon").GetComponent<Image>().sprite = mode2;
                }
                else
                {
                    gameObject.transform.Find("PushDownIcon").GetComponent<Image>().sprite = mode1;
                }
                break;
            default:
                break;
        }

    }

    ColorBlock ReverseColor(Color color)
    {
        ColorBlock colors = GetComponent<Button>().colors;
        colors.normalColor = color;
        colors.selectedColor = color;
        return colors;
    }

    public void SwapShapes()
    {

    }
}
