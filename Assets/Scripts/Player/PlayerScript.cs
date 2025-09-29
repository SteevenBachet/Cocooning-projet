using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Animation animations;
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;

    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;

    public LayerMask groundLayer;


    private void Start()
    {
       animations = gameObject.GetComponent<Animation>();
       playerCollider = gameObject.GetComponent<CapsuleCollider>();
       groundLayer = LayerMask.GetMask("Ground");
    }

    bool IsGrounded()
    {
        return Physics.CheckCapsule(
            playerCollider.bounds.center,
            new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z),
            0.1f,
            groundLayer
        );
    }

    void Update()
    {


        //Si on avance
        if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
            animations.Play("CharacterArmature|Walk");
        }

        //Si on sprint
        if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift)) {
            transform.Translate(0, 0, runSpeed * Time.deltaTime);
            animations.Play("CharacterArmature|Run");
        }

        //Si on recule
        if (Input.GetKey(inputBack))
        {
            transform.Translate(0, 0, -(walkSpeed / 2 ) * Time.deltaTime);
            animations.Play("CharacterArmature|Walk");
        }

        //Rotation gauche
        if (Input.GetKey(inputLeft))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }

        //Rotation droite
        if (Input.GetKey(inputRight))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }

        //Si on n'avance pas et qu'on ne recule pas
        if (!Input.GetKey(inputFront) && !Input.GetKey(inputBack))
        {
            animations.Play("CharacterArmature|Idle");
        }

        //Si on saute

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) 
        {
            animations.Play("CharacterArmature|Jump");
            // Préparation du saut (Nécessaire en C#)
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            v.y = jumpSpeed.y;

            //Saut
            gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
        }

    }

}
