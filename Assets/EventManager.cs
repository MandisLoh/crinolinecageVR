using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public Animator avatarAnim;
    // Start is called before the first frame update
    void Awake()
    {
        triggerShakeHands += shakeHands;
        EventManager.triggerShakeHands.Invoke();
    }

    public static Action triggerShakeHands;
    public void shakeHands()
    {
        avatarAnim.Play("Shake Hands");
    }
}
