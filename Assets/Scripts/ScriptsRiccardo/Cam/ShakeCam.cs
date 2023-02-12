using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCam : MonoBehaviour
{
    public IEnumerator Shake(float duration , float magnitude) // magnitude : the strenght of our shake;
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f; 

        while (elapsed < duration) 
        {
            float x = Random.Range(-1f,1f) * magnitude; // the strenght of the shake by axis
            float y = Random.Range(-1f,1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z); // shake changed transform

            elapsed += Time.deltaTime; // timer

            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
