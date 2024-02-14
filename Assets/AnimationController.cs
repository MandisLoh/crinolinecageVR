using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator avatarAnim;
    // Start is called before the first frame update
    void Awake()
    {
        triggerShakeHands += shakeHands;
        triggerFlyAway += flyAway;
        EventManager.triggerShakeHands.Invoke();
    }

    private void flyAway()
    {
        avatarAnim.Play("Fly Away2");
    }

    public static Action triggerShakeHands;
    public static Action triggerFlyAway;
    public void shakeHands()
    {
        avatarAnim.Play("Shake Hands");
    }
}
