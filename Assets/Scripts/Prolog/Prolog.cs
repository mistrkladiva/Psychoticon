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
    

    string Text1;
    int stringIndex = 0, pageIndex = 0;
    bool stop = true;
    string time;

    void Start()
    {
        time = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm");
        Text1 = $"ZULU: {time}\nNa vìdecké konferenci se sešlo pár chytrých hlav a rozhodli se prozkouman robotovu mysl\nChceš opravdu pokraèovat? A/N";

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
                    Text1 = "Nezáleží na tom jak se rozhodneš..\nUž teï tì pøipojují k psychotickému mozku robota. " +
                        "Projdi sekce mozku a postupnì otevírej obvody jinak se zpìt nedostaneš!";
                    Pages[pageIndex].SetActive(false);
                    Pages[pageIndex + 1].SetActive(true);
                    TextMesh.text = string.Empty;
                    stringIndex = 0;
                    pageIndex++;
                    stop = true;
                    StartCoroutine(Wait());
                    return;
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
