using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public static StaminaBar barInstance { get; private set; }

    public Image bar;
    float originalSize;
    void Awake()
    {
        barInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        originalSize = bar.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        bar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
