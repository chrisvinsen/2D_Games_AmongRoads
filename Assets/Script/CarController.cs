using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed, range;
    Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
        if (speed == 0)
        {
            speed = 1;
        }
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * speed, range);

        if (this.gameObject.tag == "Row Left")
        {
            transform.position = startPos + Vector2.right * newPos;
        }
        else if (this.gameObject.tag == "Row Right")
        {
            transform.position = startPos + Vector2.left * newPos;
        }
    }
}

