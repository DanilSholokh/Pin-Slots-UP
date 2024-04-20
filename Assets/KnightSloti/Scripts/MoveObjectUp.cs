using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectUp : MonoBehaviour
{

    public float speed = 5f; // скорость движения
    private Rigidbody2D rb;

    private bool isUp = false;

    public bool IsUp { get => isUp; set => isUp = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (IsUp)
        {
            rb.simulated = true;
            rb.velocity = new Vector2(0, speed);
        }
        
    }

}
