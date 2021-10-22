using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip scream;
    public AudioClip thud;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Scream()
    {
        Debug.Log("Scream");
        audio.PlayOneShot(scream);
    }

    public void Thud()
    {
        audio.PlayOneShot(thud);
    }
}
