using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform destination;   // joueur
    private NavMeshAgent agent;
    private bool playerInRange = false; // est-ce que le joueur est dans la zone ?

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (destination != null && agent.isOnNavMesh)
        {
            if (playerInRange)
            {
                // Poursuit le joueur tant qu’il est dans le rayon
                agent.SetDestination(destination.position);
            }
            else
            {
                // Stoppe ou met idle quand le joueur est hors du rayon
                agent.ResetPath();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}