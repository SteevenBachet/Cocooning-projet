using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "coin")
        {
            //Recuperer les info via le script public
            PlayerInfo.pi.GetCoin();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "hurt")
        {
            print("aie !");
        }

       if (collision.gameObject.tag == "mob")
        {
            print("Tuer");
            iTween.PunchScale(collision.gameObject.transform.parent.gameObject, new Vector3(2, 2, 2), 0.4f);

            //retirer le tag hurt de hurtPart pour éviter que la zone nous blesse pendant l'animation
            Transform hurtPart = collision.gameObject.transform.parent.Find("hurt");
            if (hurtPart != null)
            {
                hurtPart.tag = "Untagged";
            }

            Destroy(collision.gameObject.transform.parent.gameObject, 0.3f);
        }
    }
}
