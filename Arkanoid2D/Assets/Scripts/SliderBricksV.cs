using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBricksV : MonoBehaviour
{
    public static float bricksV;

    public Slider slider;

    private void Update()
    {
        bricksV = slider.value;
    }
}
