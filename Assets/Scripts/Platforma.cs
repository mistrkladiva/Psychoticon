using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforma : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 7f;

    float moveLeftMin = -5.45f, moveRightMax = 5.45f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > moveLeftMin)
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < moveRightMax)
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
