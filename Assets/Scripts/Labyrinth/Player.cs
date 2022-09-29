using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject TextLevel;
    [SerializeField]
    List<GameObject> Circuits;

    private void Start()
    {
        for (int i = 0; i < Circuits.Count; i++)
        {
            Circuits[i].SetActive(GameController.s_Circuits[i]);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "NextLevel")
        {
            TextLevel.SetActive(true);
            Destroy(gameObject);
        }
        if(collision.tag == "Circuit")
        {
            for (int i = 0; i < Circuits.Count; i++)
            {
                if(collision.gameObject == Circuits[i])
                {
                    GameController.s_Circuits[i] = false;
                    collision.gameObject.SetActive(false);
                    string[] doorCircuit = collision.gameObject.name.Split('-');
                    SceneManager.LoadScene(doorCircuit[1]);
                    return;
                }
            }
            
        }
    }
}
