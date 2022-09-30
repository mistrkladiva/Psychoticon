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
    [SerializeField]
    GameObject DoorEnd;

    private void Start()
    {
        //Zapni obvody ve scénì podle uložených bool v GameController.s_Circuits
        for (int i = 0; i < Circuits.Count; i++)
        {
            Circuits[i].SetActive(GameController.s_Circuits[i]);
        }

        if (GameController.s_Circuits.Any(x => x == true))
        {
            return;
        }
        else
        {
            DoorEnd.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //pokud je kolize s objektem NextLevel vypiš úspìšné dokonèení mise
        if(collision.name == "NextLevel")
        {
            TextLevel.SetActive(true);
            for (int i = 0; i < GameController.s_Circuits.Count; i++)
            {
                GameController.s_Circuits[i] = true;
            }
            //Destroy(gameObject);
        }
        //pokud je kolize s circuit (obvod)
        if(collision.tag == "Circuit")
        {
            //Zjisti, o který se jedná
            for (int i = 0; i < Circuits.Count; i++)
            {
                //Nalezení indexu obvodu
                if(collision.gameObject == Circuits[i])
                {
                    GameController.s_Circuits[i] = false; // zapiš vypnutí objektu
                    collision.gameObject.SetActive(false); // vypni objekt ve scénì
                    string[] doorCircuit = collision.gameObject.name.Split('-'); // rozdìl název obvodu
                    SceneManager.LoadScene(doorCircuit[1]); // použij index 1 jako název následující scény
                    

                }
            }
            
        }
    }
}
