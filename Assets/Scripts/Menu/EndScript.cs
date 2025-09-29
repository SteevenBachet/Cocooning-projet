using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public TMP_Text infosTxt;
    bool canOpen = false;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "poulemom")
        {
            infosTxt.text = "Appuyez sur E pour réunir les poules avec leur maman";
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "poulemom")
        {
            infosTxt.text = "";
            canOpen = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerInfo.pi.nbPoulet >= 0 && canOpen)
        {
            SceneManager.LoadScene(2);
        }
    }
}
