using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 mouseOnScreen;
    private Vector2 mousePosition;

    private Ball ball;
    private bool ballHit;

    public bool HasGuns { get; set; }
    [SerializeField] GameObject ammunitionPrefab;
    [SerializeField] Transform[] ammunitionPositions;
    [SerializeField] GameObject[] guns;

    Animator anim;
    CameraShake camShake;

    private void Start()
    {
        transform.position = new Vector3(0f, -4.25f, 0f);
        ball = FindObjectOfType<Ball>();
        anim = GetComponent<Animator>();
        camShake = FindObjectOfType<CameraShake>();

        ballHit = false;
        HasGuns = false;
    }


    // Update is called once per frame
    void Update()
    {
        Position();
        Guns();
        Animations();
    }


    private void Position()
    {
        // Turns mouse pixel pos into world pos
        mouseOnScreen = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mouseOnScreen);

        // Position on screen boards and default chase mouse position
        transform.position = new Vector2(Mathf.Clamp(mousePosition.x, -8.7f + transform.localScale.x/2, 8.7f - transform.localScale.x / 2), transform.position.y);
    }

    private void Guns()
    {
        if (HasGuns)
        {
            foreach (GameObject gun in guns)
                if (gun.activeSelf == false)
                    gun.SetActive(true);

            if (ball.BallFired)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    foreach (Transform pos in ammunitionPositions)
                    {
                        SoundManager.PlaySound(SoundClips.shoot);
                        StartCoroutine(camShake.Shake(0.03f, 0.1f));
                        Instantiate(ammunitionPrefab, pos.position, pos.rotation);
                    }
                }
            }
        }
        else
        {
            foreach (GameObject gun in guns)
                if (gun.activeSelf)
                    gun.SetActive(false);
        }
        
    }

    private void Animations()
    {
        anim.SetBool("hit", ballHit);
    }

    private void BallHitToFalse()
    {
        ballHit = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            ballHit = true;
        }
    }
}
