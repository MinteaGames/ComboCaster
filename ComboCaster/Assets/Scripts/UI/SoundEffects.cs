using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource[] sounds;

    // Start is called before the first frame update
    

    // Update is called once per frame
    public void playSound(int index)
    {
        sounds[index].Play();
    }



}
