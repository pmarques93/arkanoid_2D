using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 mouseOnScreen;
    public Vector2 MousePosition { get; set; }


    private void Start()
    {
        transform.position = new Vector3(0f, -4.25f, 0f);
    }


    // Update is called once per frame
    void Update()
    {
        Position();
    }


    private void Position()
    {
        // Turns mouse pixel pos into world pos
        mouseOnScreen = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(mouseOnScreen);

        // Position on screen boards and default chase mouse position
        transform.position = new Vector2(Mathf.Clamp(MousePosition.x, -8.7f + transform.localScale.x/2, 8.7f - transform.localScale.x / 2), transform.position.y);
    }
}
