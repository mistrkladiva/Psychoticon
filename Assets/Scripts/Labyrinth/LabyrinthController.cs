using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LabyrinthController : MonoBehaviour
{
    [SerializeField]
    float smerRotace = -1, rychlostRotace = 5f;
    float uhelRotace = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            smerRotace = -1;
            uhelRotace += rychlostRotace * smerRotace;
            if (uhelRotace > 360)
            {
                uhelRotace = 0;
            }
            transform.rotation = Quaternion.AngleAxis(uhelRotace, new Vector3(0, 0, 1));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            smerRotace = 1;
            uhelRotace += rychlostRotace * smerRotace;
            if (uhelRotace > 360)
            {
                uhelRotace = 0;
            }
            transform.rotation = Quaternion.AngleAxis(uhelRotace, new Vector3(0, 0, 1));
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
