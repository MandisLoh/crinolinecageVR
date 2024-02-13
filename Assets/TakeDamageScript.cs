using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TakeDamageScript : MonoBehaviour
{
    public float intensity = 0.0f;

    Volume _volume;
    Vignette _vignette;
    // Start is called before the first frame update
    void Start()
    {
        print("Testing TakeDamage");
        _volume = GetComponent<Volume>();
        if (!_volume)
        {
            Debug.Log("Volume Empty");
        }
        else
        {
            Debug.Log("Volume found");
            
        }

        _volume.profile.TryGet<Vignette>(out _vignette);

        if (!_vignette)
        {
            Debug.Log("Vignette Empty");
        }
        else
        {
            print(_vignette);
            
        }

        TakeDamage += TakeDamageCoroutine;
    }

    private void TakeDamageCoroutine()
    {
        StartCoroutine(TakeDamageEffect());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            StartCoroutine(TakeDamageEffect());
        }
    }

    public static Action TakeDamage;



    private IEnumerator TakeDamageEffect()
    {
        intensity = 0.4f;

        
        _vignette.intensity.Override(intensity);
        yield return new WaitForSeconds(0.4f);

        while(intensity < 1.0f)
        {
            intensity += 0.02f;

            if(intensity > 1f) 
            {
                intensity = 1f;
            }

            _vignette.intensity.Override(intensity);
            yield return new WaitForSeconds(0.1f);
        }

        yield break;
    }
}
