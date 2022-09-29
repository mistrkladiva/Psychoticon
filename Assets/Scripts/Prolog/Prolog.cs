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
        Text1 = $"M�stn� �as: {time}\nNa tajn� v�deck� konferenci se se�lo p�r chytr�ch hlav a rozhodli se prozkoumat robotovu mysl\n" +
            $"Oslovili tebe jako pokusn�ho kr�l�ka, kter�ho p�ipoj� k mozku robota\nChce� opravdu pokra�ovat? A/N";

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
                    Text1 = "Nez�le�� na tom jak se rozhodne�..\nU� te� t� p�ipojuj� k psychotick�mu robotu. " +
                        "Projdi sekce mozku a postupn� otev�rej obvody jinak se zp�t nedostane�!\n" +
                        "Ovl�d�n�: �ipka vlevo, vpravo,\n�ipka nahoru akcelerace, Esc restart levelu.";
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
