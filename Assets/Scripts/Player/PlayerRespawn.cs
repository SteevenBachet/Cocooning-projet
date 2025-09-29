using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// pour respawn
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint; 

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur touche un danger
        if (other.CompareTag("water") || other.CompareTag("hurt") || other.CompareTag("fall"))
        {
            SceneManager.LoadScene(1);
        }
    }

  
}