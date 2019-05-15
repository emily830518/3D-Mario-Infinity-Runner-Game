using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftToRight : MonoBehaviour
{
    public float speed = 0.1f;
    int changeDirection = 1;
    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = this.transform.position;
        newPos.z += changeDirection * speed;
        if (newPos.z <= 11.0f && newPos.z >= -5.0f)
        {
            this.transform.position = newPos;
        }
        else
        {
            changeDirection = (-1) * changeDirection;
        }
    }
}
