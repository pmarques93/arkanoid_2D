using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed { get; set; }
    public bool BallFired { get; set; }

    public bool BallOnFire { get; set; }

    [SerializeField] GameObject brickHit;

    private Player player;
    private ParticleSystem particle;

    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer render;

    public Rigidbody2D rb { get; set; }
    [SerializeField] CircleCollider2D onFireCol;

    CameraShake camShake;

    private void Awake()
    {
        camShake = FindObjectOfType<CameraShake>();
        player = FindObjectOfType<Player>();
        particle = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        if (balls.Length <= 1) BallFired = false;
        else BallFired = true;

        ballSpeed = BallSpeed.speed;

        BallOnFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) FindObjectOfType<Player>();

        InitialPosition();
        OutOfPlay();
        BallOnFirePowerUp();
    }

    private void BallOnFirePowerUp()
    {
        // Collider if ball is small
        if (transform.localScale.x == 0.5f)
        {
            onFireCol.radius = 0.60f;
        }
        else
        {
            onFireCol.radius = 0.3f;
        }

        // ball on fire power up effects
        if (BallOnFire)
        {
            // orange sprite + different collor + enable collider
            render.sprite = sprites[1];
            particle.startColor = new Color(0.8f, 0.25f, 0.08f, 1f);
            onFireCol.enabled = true;
        }
        else
        {
            render.sprite = sprites[0];
            particle.startColor = new Color(1f, 1f, 1f, 1f);
            onFireCol.enabled = false;
        }
    }

    private void InitialPosition()
    {
        if (BallFired == false)
        {
            if (Input.GetButtonDown("Fire1") && Time.timeSinceLevelLoad > 0.5f)
            {
                BallFired = true;
                particle.enableEmission = true;
                rb.AddForce(new Vector2(ballSpeed, ballSpeed));
            }
            else
            {
                if (player != null)
                {
                    particle.enableEmission = false;
                    transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.15f);
                }
            }
        }
    }

    private void OutOfPlay()
    {
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
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

            if (transform.position.y > player.transform.position.y -0.1f)
            {
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
        }

        if (collision.gameObject.GetComponent<Brick>() != null)
        {
            StartCoroutine(camShake.Shake(0.1f, 0.05f));
            Instantiate(brickHit, transform.position, brickHit.transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<Brick>() != null)
        {
            Brick thisBrick = collision.GetComponent<Brick>();
            thisBrick.hp = 0;
        }
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(new Vector3(-15f, player.transform.position.y - 0.1f, 0f), new Vector3(15f, player.transform.position.y - 0.1f, 0f));
    }
}
