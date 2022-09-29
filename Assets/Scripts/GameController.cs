using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static string[] Levels;

    public List<GameObject> Bricks;
    public static List<GameObject> s_Bricks;
    public static List<bool> s_Circuits = new List<bool>() { true, true, true };
    [SerializeField]
    GameObject Wall_door;
    [SerializeField]
    TextMeshPro TextNextLevel;
    
    void Start()
    {
        Levels = new string[] { "Level1", "Level2", "Boss-1", "Level3", "Level4", "Boss-1", "Level5" };
        s_Bricks = Bricks;
    }

    void Update()
    {
        if(s_Bricks.Count == 0)
        {
            Destroy(Wall_door);
            TextNextLevel.gameObject.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
