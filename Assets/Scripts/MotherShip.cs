using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    public int scoreValue;

    private const float MAX_LEFT = -5f;
    private float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime*speed);

        if(transform.position.x<= MAX_LEFT)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
