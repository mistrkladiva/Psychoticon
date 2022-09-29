using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prolog : MonoBehaviour
{
    [SerializeField]
    TextMeshPro TextMesh;
    [SerializeField]
    AudioSource beep;
    [SerializeField]
    GameObject[] Pages;
    

    string Text1 = "ZULU: 1223456\nNa vìdecké konferenci se sešlo pár chytrých hlav a rozhodli se prozkouman robotovu mysl\nChceš opravdu pokraèovat? A/N";
    int stringIndex = 0, pageIndex = 0;
    bool stop = true;

    void Start()
    {
        StartCoroutine(Wait());
    }

    private void Update()
    {
        if(!stop)
        {
            if (Input.anyKeyDown)
            {
                if (pageIndex == 0)
                {
                    Text1 = "Nezáleží na tom jak se rozhodneš.. už teï tì pøipojují k psychotickému mozku robota";
                    Pages[pageIndex].SetActive(false);
                    Pages[pageIndex + 1].SetActive(true);
                    TextMesh.text = string.Empty;
                    stringIndex = 0;
                    pageIndex++;
                    stop = true;
                    StartCoroutine(Wait());
                }
                if (pageIndex == 1)
                {
                    SceneManager.LoadScene("LevelExtra");
                }
            }
        }
    }
    IEnumerator Wait()
    {
        while (stop)
        {
            TextMesh.text += Text1[stringIndex];
            if (Text1[stringIndex] != ' ')
                beep.Play();
            stringIndex++;
            if (stringIndex > Text1.Length-1)
            {
                stop = false;
                StopAllCoroutines();
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

}
