using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMixer : MonoBehaviour
{
    public AudioSource relaxing;
    public AudioSource intense;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        relaxing.volume = 1;
        intense.volume = 0;

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var npcs = GameObject.FindGameObjectsWithTag("NPC");
        var closest = Mathf.Infinity;

        foreach (var npc in npcs)
        {
            var dist = Vector3.Distance(npc.transform.position, player.transform.position);

            closest = Mathf.Min(dist, closest);
        }

        var mix = Mathf.Clamp01(closest - 6);

        relaxing.volume = mix;
        intense.volume = 1 - mix;
    }
}
