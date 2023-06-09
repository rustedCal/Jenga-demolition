using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
    public AudioClip[] musicClips;
    public AudioSource player;
    int pointer = 0;
    void Update()
    {
        if(pointer > musicClips.Length)
        {
            pointer = 0;
        }
        if (!player.isPlaying)
        {
            player.PlayOneShot(musicClips[pointer]);
            pointer++;
        }
    }
}
