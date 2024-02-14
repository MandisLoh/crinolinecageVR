using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class WearCage : MonoBehaviour
{
    public GameObject displayCage;
    public GameObject wearCage;
    public Rigidbody rb;


    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            Debug.Log("Hand detected");
            if (displayCage.activeInHierarchy == true)
            {
                displayCage.SetActive(false);
                wearCage.SetActive(true);

                rb = rb.GetComponent<Rigidbody>();
                Debug.Log(rb.name);
                rb.drag = 50;
                EventManager.triggerOpenDoor.Invoke();
            }
                
            

        }

    }
}

