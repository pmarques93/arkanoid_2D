using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float ballSpeed;
    public bool BallFired { get; set; }

    [SerializeField] GameObject brickHit;


    private Player player;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();

        BallFired = false;
        ballSpeed = BallSpeed.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) FindObjectOfType<Player>();

        InitialPosition();
    }

    private void InitialPosition()
    {
        if (BallFired == false)
        {
            if (Input.GetButtonDown("Fire1") && Time.timeSinceLevelLoad > 0.5f)
            {
                BallFired = true;
                rb.AddForce(new Vector2(ballSpeed, ballSpeed));
            }
            else
            {
                if (player != null)
                {
                    transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.25f);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>()!=null)
        {
            // Calculates the distance from mid to impact point
            ContactPoint2D hitPoint = collision.GetContact(0);
            float playerCenter = player.transform.position.x;
            float difference = playerCenter - hitPoint.point.x;

            if (transform.position.y > player.transform.position.y + 0.08f)
            rb.velocity = Vector3.zero;
            
            // Gains speed if it hits the middle, loses speed if it hits the corners
            if (hitPoint.point.x < playerCenter)
            {
                // Controls the angle of the impact and gives a new velocity
                rb.AddForce(new Vector2(Mathf.Clamp(-(Mathf.Abs(difference * ballSpeed)), -350f, 350f), ballSpeed));
            }
            else
            {
                // Controls the angle of the impact and gives a new velocity
                rb.AddForce(new Vector2(Mathf.Clamp((Mathf.Abs(difference * ballSpeed)), -350f, 350f), ballSpeed));
            }
        }

        if (collision.gameObject.GetComponent<Brick>() != null)
        {
            Instantiate(brickHit, transform.position, brickHit.transform.rotation);
        }
    }
}
