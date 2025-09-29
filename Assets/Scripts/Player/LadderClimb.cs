using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public float climbSpeed = 3f;
    private bool isClimbing = false;
    private Rigidbody rb;

    void Start()
    {
        // On récupère le Rigidbody déjà présent sur ton perso
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ladder"))
        {
            isClimbing = true;
            rb.useGravity = false; // désactive la gravité pendant la montée
            rb.velocity = Vector3.zero; // évite que le joueur glisse
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ladder"))
        {
            isClimbing = false;
            rb.useGravity = true; // remet la gravité quand on sort de l’échelle
        }
    }

    void Update()
    {
        if (isClimbing)
        {
            float vertical = Input.GetAxis("Vertical"); // W/S ou ↑/↓
            rb.velocity = new Vector3(0, vertical * climbSpeed, 0);
        }
    }
}