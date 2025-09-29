using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    public float time;
    public float x;
    public Vector3 RotateAmount;

    void Start()
    {
        iTween.MoveBy(gameObject, iTween.Hash(
            
            "x", x,
            "time", time,
            "looptype", iTween.LoopType.pingPong,
            "easetype", iTween.EaseType.easeInOutSine

         ));

        iTween.RotateBy(gameObject, iTween.Hash(
           "amount", RotateAmount,
           "time", time,
           "easetype", iTween.EaseType.easeInOutSine,
           "looptype", iTween.LoopType.pingPong
        ));
    }

}
