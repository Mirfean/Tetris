using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MaskableGraphic))]
public class StartScreenFader : MonoBehaviour
{
    [SerializeField]
    float startAlpha = 1f;
    [SerializeField]
    float endAlpha = 0f;
    [SerializeField]
    float delay = 0f;
    [SerializeField]
    float timeToFade = 1f;

    float inc;
    float currentAlpha;
    MaskableGraphic graphic;
    Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        graphic = GetComponent<MaskableGraphic>();
        originalColor = graphic.color;
        currentAlpha = startAlpha;
        
        Color tempColor = new Color(originalColor.r, originalColor.g, originalColor.b, currentAlpha);

        graphic.color = tempColor;
        
        inc = ((endAlpha - startAlpha) / timeToFade) * Time.deltaTime;

        StartCoroutine("FadeRoutine2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FadeRoutine2()
    {
        yield return new WaitForSeconds(delay);
        graphic.CrossFadeAlpha(endAlpha, timeToFade, true);
    }
}
