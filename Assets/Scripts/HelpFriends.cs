using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HelpFriends : MonoBehaviour
{
    GameObject cage;
    public TMP_Text infosTxt;
    bool canOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "cage")
        {
            cage = other.gameObject;
            infosTxt.text = "Appuyez sur E pour ouvrir la cage...";
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "cage")
        {
            cage = null;
            infosTxt.text = "";
            canOpen = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canOpen )
        {
            iTween.ShakeRotation(cage, new Vector3(0.3f, 0.3f, 0.3f), 0.8f);
            Destroy(cage, 1.2f);
            infosTxt.text = "";
            canOpen = false;
            PlayerInfo.pi.GetPoulet();
        }
    }
}


