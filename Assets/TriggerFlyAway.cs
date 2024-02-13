using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFlyAway : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cage")
        {
            Debug.Log("Fire is Catching, If we burn, you burn with us");
            EventManager.triggerFlyAway.Invoke();
        }
    }
}
