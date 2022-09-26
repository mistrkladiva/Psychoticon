using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField]
    float moveLeftMin = -5f, moveRightMax = 5f, moveUpMax = 3f, moveDownMin = -3f, moveSpeed = 7f;
    [SerializeField]
    public bool LeftRight, UpDown, Rotation, cikcak;
    int smer = 1;

    [SerializeField]
    float smerRotace = -1, rychlostRotace = 7f;
    float uhelRotace = 0;

    void FixedUpdate()
    {
        if (LeftRight)
        {
            if (transform.position.x > moveRightMax)
            {
                smer = -1;
            }
            if (transform.position.x < moveLeftMin)
            {
                smer = 1;
            }
            transform.position += new Vector3(1, 0, 0) * smer * moveSpeed * Time.deltaTime;
        }

        if (UpDown)
        {
            if (transform.position.y > moveUpMax)
            {
                smer = -1;
            }
            if (transform.position.y < moveDownMin)
            {
                smer = 1;
            }
            transform.position += new Vector3(0, 1, 0) * smer * moveSpeed * Time.deltaTime;
        }

        if (Rotation)
        {
            uhelRotace += rychlostRotace * smerRotace;
            if (uhelRotace > 360)
            {
                uhelRotace = 0;
            }
            transform.rotation = Quaternion.AngleAxis(uhelRotace, new Vector3(0, 0, 1));
        }

        if (cikcak)
        {
            uhelRotace += rychlostRotace * smerRotace;
            if (uhelRotace > 360)
            {
                smerRotace = -1;
            }
            if (uhelRotace < 0)
            {
                smerRotace = 1;
            }
            transform.rotation = Quaternion.AngleAxis(uhelRotace, new Vector3(0, 0, 1));
        }
    }
}
