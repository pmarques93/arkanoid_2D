using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : MonoBehaviour
{
    private Rigidbody2D rb;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * 10f; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
