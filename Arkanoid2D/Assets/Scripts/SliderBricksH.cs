using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBricksH : MonoBehaviour
{
    public static float bricksH;

    public Slider slider;
 
    private void Update()
    {
        bricksH = slider.value;
    }
}
