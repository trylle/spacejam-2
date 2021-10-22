using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWarning : MonoBehaviour
{
    public Material NormalMaterial;
    public Material WarningMaterial;
    GameObject player;
    PlayerSounds playerSounds;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerSounds = player.GetComponent<PlayerSounds>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            Debug.Log("Warning!");
            //AudioSource audioData = player.GetComponent<AudioSource>();
            //audioData.Play(0);
            playerSounds.Scream();
        }

    }
}
