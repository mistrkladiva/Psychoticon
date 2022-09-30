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
        //Zapni obvody ve sc�n� podle ulo�en�ch bool v GameController.s_Circuits
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
        //pokud je kolize s objektem NextLevel vypi� �sp�n� dokon�en� mise
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
            //Zjisti, o kter� se jedn�
            for (int i = 0; i < Circuits.Count; i++)
            {
                //Nalezen� indexu obvodu
                if(collision.gameObject == Circuits[i])
                {
                    GameController.s_Circuits[i] = false; // zapi� vypnut� objektu
                    collision.gameObject.SetActive(false); // vypni objekt ve sc�n�
                    string[] doorCircuit = collision.gameObject.name.Split('-'); // rozd�l n�zev obvodu
                    SceneManager.LoadScene(doorCircuit[1]); // pou�ij index 1 jako n�zev n�sleduj�c� sc�ny
                    

                }
            }
            
        }
    }
}
