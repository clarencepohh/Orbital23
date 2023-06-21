using UnityEngine;
using System.Collections;

public class SizeFinder : MonoBehaviour
{
    void Start()
    {
        Debug.Log(GetComponent<Collider2D>().bounds.size);
        Debug.Log(GetComponent<Collider2D>().bounds.size.x * transform.localScale.x);
        Debug.Log(GetComponent<Collider2D>().bounds.size.y * transform.localScale.y);
        // Vector3[] vertices = mesh.vertices;
        // Vector2[] uvs = new Vector2[vertices.Length];
        // Bounds bounds = mesh.bounds;
        // // q: how to find out the size of the gameobject that this script is attached to in the x and y directions
        // // a: use the bounds.size property
        // Debug.Log(bounds.size);
        // Debug.Log(bounds.size.x);
        // Debug.Log(bounds.size.y);
        // Debug.Log(mesh.bounds.size.x);
        // Debug.Log(mesh.bounds.size.y);
        // Debug.Log(mesh.bounds.size);
    }
}