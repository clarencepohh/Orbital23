using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.CompareTag("Ground"))
        {
          Destroy(this.gameObject);
        }
    }
}
