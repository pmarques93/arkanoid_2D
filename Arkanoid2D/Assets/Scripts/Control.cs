using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    [SerializeField] Toggle startButton;

    public static bool mouseControl;
    public static bool keyboardControl;

    private void Start()
    {
        startButton.interactable = false;
        mouseControl = true;
        keyboardControl = false;
    }

    public void SetKeyboardControl()
    {
        keyboardControl = true;
        mouseControl = false;
    }

    public void SetMouseControl()
    {
        mouseControl = true;
        keyboardControl = false;
    }
}
