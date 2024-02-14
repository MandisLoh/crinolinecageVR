using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public Animator avatarAnim;
    public Animator avatarAnim1;
    public Animator avatarAnim2;
    public Animator doorAnim;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Awake()
    {
        triggerShakeHands += shakeHands;
        triggerFlyAway += flyAway;
        triggerFlyAway1 += flyAway1;
        triggerFlyAway2 += flyAway2;
        triggerOpenDoor += openDoor;
        gameOver.SetActive(false);
        triggerGameOver += Gg;
    }

    private void Gg()
    {
        gameOver.SetActive(true);
    }

    public static Action triggerShakeHands;
    public static Action triggerFlyAway;
    public static Action triggerFlyAway1;
    public static Action triggerFlyAway2;
    public static Action triggerOpenDoor;
    public static Action triggerGameOver;

    private void flyAway()
    {
        print("awesome");
        avatarAnim.Play("Fly Away2");
    }

    private void flyAway1()
    {
        avatarAnim1.Play("victorianman1");
    }

    private void flyAway2()
    {
        avatarAnim2.Play("victorianman2");
    }

    private void openDoor()
    {
        doorAnim.Play("door open");
    }

    public void shakeHands()
    {
        avatarAnim.Play("Shake Hands");
    }
}
