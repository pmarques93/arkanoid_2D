using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // Stats
    [SerializeField] private Sprite[] color;
    private int hp;

    // Stuff
    private SpriteRenderer render;

    // Powerups
    [SerializeField] private GameObject[] items;

    // Destroy effect
    [SerializeField] GameObject destroyEffectPrefab;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();

        hp = Random.Range(1, 4);
    }

    private void Update()
    {
        Colors();
        DestroyBrick();
    }

    private void Colors()
    {
        switch (hp)
        {
            case 3:
                render.sprite = color[0];
                break;
            case 2:
                render.sprite = color[1];
                break;
            case 1:
                render.sprite = color[2];
                break;
        }
    }

    private void DestroyBrick()
    {
        if (hp < 1)
        {
            int randChance = Random.Range(0, 25);
            GameObject item;

            switch (randChance)
            {
                case 0: // moresize
                    item = Instantiate(items[0], new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f), Quaternion.identity);
                    item.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-40f, 40f), 150f));
                    break;
                case 1: // lesssize
                    item = Instantiate(items[1], new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f), Quaternion.identity);
                    item.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-40f, 40f), 150f));
                    break;
                case 2: // guns
                    item = Instantiate(items[2], new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f), Quaternion.identity);
                    item.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-40f, 40f), 150f));
                    break;
            }

            Instantiate(destroyEffectPrefab, transform.position, destroyEffectPrefab.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D()
    {
        hp--;
    }
}
