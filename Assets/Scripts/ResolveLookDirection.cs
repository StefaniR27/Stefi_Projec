using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class ResolveLookDirection : MonoBehaviour
{
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!rb2d)
        {
            return;
        }

        float horizontal_velocity = rb2d.linearVelocity.x;
        if (Abs(horizontal_velocity) > 0.01f)
        {
            float look_direction = (horizontal_velocity > 0) ? 1 : -1;
            transform.localScale = new Vector3(look_direction, 1, 1);
        }
    }
}
