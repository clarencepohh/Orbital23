using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racketswing : MonoBehaviour
{
    public float lerpDuration = 0.5f;
    bool rotating;
    public float scalarForce = 200f;

    private void Update() {
        if (Input.GetMouseButtonDown(0) && !rotating)
        {
            StartCoroutine(RotateLeft());
        } 
        else if (Input.GetMouseButtonDown(1) && !rotating)
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
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Shuttlecock" && rotating)
        {
            Renderer childRenderer = transform.GetChild(0).GetComponent<Renderer>();
            Vector3 center = childRenderer.bounds.center;
            ContactPoint2D pointOfCollision = other.GetContact(0);
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 stringsPosition = new Vector2(center.x, center.y);
            Vector2 directionHit = stringsPosition - pointOfCollision.point;
            rb.AddForce(directionHit * scalarForce, ForceMode2D.Impulse);
        }
    }  
}
