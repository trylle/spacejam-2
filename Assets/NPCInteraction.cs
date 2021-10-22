using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCInteraction : MonoBehaviour
{
    MeshRenderer meshR;
    public MeshRenderer ParentMeshR;

    private void Start()
    {
        //meshR = GetComponent<MeshRenderer>();
        //GameObject parent = this.
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            Debug.Log("Collided with NPC");
            ParentMeshR.enabled = false;
            GameObject.Find("GameManager")?.GetComponent<GameManager>()?.Restart();
        }

    }
}
