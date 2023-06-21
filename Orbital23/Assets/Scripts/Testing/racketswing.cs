using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racketswing : MonoBehaviour
{
    public float lerpDuration = 0.5f;
    bool rotating;

    private void Update() {
        if (Input.GetMouseButtonDown(0) && !rotating)
        {
            StartCoroutine(RotateLeft());
        } else if (Input.GetMouseButtonDown(1) && !rotating)
        {
            StartCoroutine(RotateRight());
        }
    }

    IEnumerator RotateLeft()
    {
        rotating = true;
        float timeElapsed = 0;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = transform.rotation * Quaternion.Euler(0, 0, 90);
        while (timeElapsed < lerpDuration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endRotation;
        rotating = false;
    }

    IEnumerator RotateRight()
    {
        rotating = true;
        float timeElapsed = 0;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = transform.rotation * Quaternion.Euler(0, 0, -90);
        while (timeElapsed < lerpDuration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endRotation;
        rotating = false;
    }
}
