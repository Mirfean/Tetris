using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonHandler : MonoBehaviour
{
    [SerializeField]
    string buttonType;

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
            case "Rotate":
                 gameObject.transform.Find("RotateIcon").Rotate(0f,180f,0f,Space.Self);

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
}
