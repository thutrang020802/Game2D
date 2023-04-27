using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1 : MonoBehaviour
{
    public Transform player;
    bool isFalling = false;

    private void Update()
    {

        Vector2 positionTrap = new Vector2(transform.position.x, transform.position.y);
        Vector2 positionPlayer = new Vector2(player.position.x, player.position.y);

        // nếu khoảng cách của bẫy và player <= 25 thì bẫy rơi !
        float distanceToPlayer = Vector2.Distance(positionTrap, positionPlayer);

        if (distanceToPlayer <= 25f && !isFalling)
        {
            isFalling = true;
            Falling();
        }


        void Falling()
        {
            // bẫy đang là static thì đổi thành dynamic
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}