using UnityEngine;

// Script to keep music playing between scenes
public class MusicHandover : MonoBehaviour
{
    private void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
