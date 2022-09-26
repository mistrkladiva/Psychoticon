using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bonus : MonoBehaviour
{
    public GameObject Ball, RndCube;
    public GameObject[] Plochy;
    public Animator CameraShake;
    public AudioSource PickUp;
    public int TypBonus;
    float WidthMin = -8f, WidthMax = 8f, HeigtMin = -4.4f, HeightMax = 4.4f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            CameraShake.Play(0);
            PickUp.Play();

            switch (TypBonus)
            {
                case 0:
                    MultiBall();
                    break;
                case 1:
                    RandomCube();
                    break;
                case 2:
                    MovePlochy();
                    break;
                default:
                    break;
            }
        }
    }

    void MultiBall()
    {
        for (int i = 0; i < 3; i++)
        {
            gameObject.SetActive(false);
            Instantiate(Ball);
        }
    }

    void RandomCube()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 pozice = new Vector3(Random.Range(WidthMin, WidthMax), Random.Range(HeigtMin, HeightMax), 0);
            Instantiate(RndCube, pozice, Quaternion.identity);
        }        
    }

    void MovePlochy()
    {
        foreach (var obstackle in Plochy)
        {
            gameObject.SetActive(false);
            obstackle.GetComponent<Obstacle>().LeftRight = true;
        }
    }

}
