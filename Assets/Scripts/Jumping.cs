using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GetComponentInChildren<Animator>().CrossFadeInFixedTime("Jumping", 0.01f);
            var rb = collision.transform.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, 22F); // add cho nhân vật nhảy
        }
    }
}
