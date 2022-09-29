using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField]
    AudioSource blob;

    Rigidbody2D body;
    float force = 0.99f;
    public Vector3 velocity;
 
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
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
            // projdi názvy levelù a zjisti ve kterém jsi
            for (int i = 0; i < GameController.Levels.Length; i++)
            {
                //Pokud jsi na konci pole levelù zaèni od zaèátku
                if (i == GameController.Levels.Length - 1)
                {
                    SceneManager.LoadScene(GameController.Levels[0]);
                    return;
                }
                //Najdi index aktuálního levelu
                if (GameController.Levels[i] == SceneManager.GetActiveScene().name)
                {
                    StartGame.MusicTime = StartGame.Music.time;
                    //Rozdìl název levelu a pokud je to boss naèti mozek jiak naèti level o úroveò výš
                    string[] levelName = SceneManager.GetActiveScene().name.Split('-');
                    if (levelName[0] == "Boss" )
                    {
                        SceneManager.LoadScene("LevelExtra");
                        StartGame.MusicTime = 0;
                        return;
                    }
                    SceneManager.LoadScene(GameController.Levels[i + 1]);
                    return;
                }
            }
        }
    }
}
