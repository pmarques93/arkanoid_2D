using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSpeed : MonoBehaviour
{
    public static float speed;

    public Slider slider;

    private void Update()
    {
        speed = slider.value;
    }
}
