using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFlyAway3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cage")
        {
            Debug.Log("Fire is Catching, If we burn, you burn with us");
            EventManager.triggerFlyAway1.Invoke();
        }
    }
}
