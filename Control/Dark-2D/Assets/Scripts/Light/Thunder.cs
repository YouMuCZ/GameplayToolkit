using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Thunder : MonoBehaviour
{
    public Color color;

    [Header("Intensity参数")]
    public int   maxThunderTime    = 5;
    public float maxIntensity      = 2f;
    public float minIntensity      = 0.5f;
    public float maxIntensityDelay = 0.5f;
    public float minIntensityDelay = 0.5f;
    private Light2D light2d;

    void Start()
    {
        light2d = GetComponent<Light2D>();
        light2d.color = color;
        StartCoroutine(StartThunder());
    }

    IEnumerator StartThunder()
    {
        while(true)
        {
            int _thunder = Random.Range(0, maxThunderTime + 1);

            while(_thunder-- > 0)
            {
                float _maxIntensityDelay = Random.Range(0, maxIntensityDelay);
                float _maxIntensity = Random.Range(maxIntensity-1, maxIntensity);
                light2d.intensity = _maxIntensity;
                yield return new WaitForSeconds(_maxIntensityDelay);
                float _minIntensityDelay = Random.Range(0, minIntensityDelay);
                float _minIntensity = Random.Range(minIntensity-1, minIntensity);
                light2d.intensity = _minIntensity;
                yield return new WaitForSeconds(_minIntensityDelay);
            }

            light2d.intensity = minIntensity;
            yield return new WaitForSeconds(Random.Range(0, 5f));
        }
    }
}
