using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public static AudioSource Music;
    public static float MusicTime = 0f;
    void Start()
    {
        Music = FindObjectsOfType<AudioSource>().Where(x => x.name == "Music").FirstOrDefault();
        Music.time = MusicTime;
        Music.Play();
    }
}
