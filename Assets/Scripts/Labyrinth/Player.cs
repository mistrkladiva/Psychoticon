using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject TextLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "NextLevel")
        {
            TextLevel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
