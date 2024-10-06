using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeIntensity = 0.2f;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;

        GameManager.Instance.CurrentShake = this; 
    }

    public void StartShake(float duration)
    {
        StartCoroutine(Shake(duration));
    }

    private IEnumerator Shake(float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeIntensity;
            transform.localPosition = originalPosition + randomOffset;
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}