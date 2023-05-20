using UnityEngine;

public class EnvironmentFollow : MonoBehaviour
{
    public Transform shuttlecockTransform;
    public float scrollSpeed = 0.1f;
    private Vector3 storageVect;
    private Vector3 cameraOffset;

    void Start()
    {
        cameraOffset = transform.position - shuttlecockTransform.position;
        storageVect = cameraOffset;
    }

    void Update()
    {
        if (shuttlecockTransform.position.y - transform.position.y <= 0)
        {
            // empty to prevent environment walls from moving down
            Debug.Log("down");
        }  
        else 
        { 
            transform.position = Vector3.Lerp(transform.position, storageVect, scrollSpeed);
            Debug.Log("Up");
        }
    }
}
