using System.Collections;
using UnityEngine;

public class EndPageScript : MonoBehaviour
{
    public GameObject panelScreamer;
    public GameObject panelVraiFin;

    void Start()
    {
        // On lance la coroutine au démarrage
        StartCoroutine(ShowScreamerThenEnd());
    }

    IEnumerator ShowScreamerThenEnd()
    {
        // Active le screamer
        panelScreamer.SetActive(true);
        panelVraiFin.SetActive(false);

        // Attend 1 seconde
        yield return new WaitForSeconds(1.5f);

        // Cache le screamer et affiche la vraie fin
        panelScreamer.SetActive(false);
        panelVraiFin.SetActive(true);
    }
}