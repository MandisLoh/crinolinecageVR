using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class TakeDamageScript : MonoBehaviour
{
    public float intensity = 0.0f;
    public GameObject blackScreen;

    Volume[] volumeList;
    Vignette _vignette;

    Volume _volume1;

    // Start is called before the first frame update
    void Start()
    {
        print("Testing TakeDamage");
        _volume1 = GetComponent<Volume>();
         
        if (!_volume1)
        {
            Debug.Log("Volume Empty");
        }
        else
        {
            Debug.Log("Volume found");
            
        }

        _volume1.profile.TryGet<Vignette>(out _vignette);

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

            if(intensity >= 1f) 
            {
                intensity = 1f;
                EventManager.triggerGameOver.Invoke();
                //SceneManager.LoadScene("GameOverScene");
                blackScreen.SetActive(true);
            }

            _vignette.intensity.Override(intensity);
            yield return new WaitForSeconds(0.34f);
        }

        
        yield break;
    }
}
