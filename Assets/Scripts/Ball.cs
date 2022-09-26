using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField]
    AudioSource blob;

    Rigidbody2D body;
    float force = 0.9f;
    public Vector3 velocity;
 
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Debug.Log(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity = body.velocity;
            body.velocity = body.velocity / force;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        blob.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "NextLevel")
        {
            for (int i = 0; i < GameController.Levels.Length; i++)
            {
                if(i == GameController.Levels.Length-1)
                {
                    SceneManager.LoadScene(GameController.Levels[0]);
                    return;
                }

                if (GameController.Levels[i] == SceneManager.GetActiveScene().name)
                {
                    SceneManager.LoadScene(GameController.Levels[i+1]);
                    return;
                }
            }                      
        }
    }
}
