using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TakeDamageScript : MonoBehaviour
{
    public float intensity = 0.0f;

    PostProcessVolume _volume;
    Vignette _vignette;
    // Start is called before the first frame update
    void Start()
    {
        _volume = GetComponent<PostProcessVolume>();
        _volume.profile.TryGetSettings<Vignette>(out _vignette);

        if(!_vignette)
        {
            Debug.Log("Vignette Empty");
        }
        else
        {
            _vignette.enabled.Override(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            StartCoroutine(TakeDamageEffect());
        }
    }

    private IEnumerator TakeDamageEffect()
    {
        intensity = 0.4f;

        _vignette.enabled.Override(true);
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

        _vignette.enabled.Override(false);
        yield break;
    }
}
