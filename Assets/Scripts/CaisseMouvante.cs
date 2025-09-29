using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaisseMouvante : MonoBehaviour
{
    public float amplitude;
    public float vitesse;

    private Vector3 positionInitiale;
    private Vector3 dernierePosition;

    private GameObject joueurSurCaisse;

    void Start()
    {
        // On enregistre la position de départ
        positionInitiale = transform.position;
        dernierePosition = positionInitiale;
    }

    void Update()
    {
        // Mouvement sinusoidal gauche ↔ droite
        float deplacement = Mathf.Sin(Time.time * vitesse) * amplitude;
        transform.position = positionInitiale + new Vector3(deplacement, 0, 0);

        // Déplacement appliqué au joueur s'il est sur la caisse
        if (joueurSurCaisse != null)
        {
            Vector3 delta = transform.position - dernierePosition;
            joueurSurCaisse.transform.position += delta;
        }

        dernierePosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            joueurSurCaisse = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            joueurSurCaisse = null;
        }
    }
}