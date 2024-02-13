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
        triggerFlyAway += flyAway;
        EventManager.triggerFlyAway.Invoke();
    }

    private void flyAway()
    {
        avatarAnim.Play("Fly Away");
    }

    public static Action triggerShakeHands;
    public static Action triggerFlyAway;
    public void shakeHands()
    {
        avatarAnim.Play("Shake Hands");
    }
}
