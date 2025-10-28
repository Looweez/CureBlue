using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor = 0.5f;
    private Transform cam;
    private Vector3 lastPos;

    void Start()
    {
        cam = Camera.main.transform;
        lastPos = cam.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cam.position - lastPos;
        transform.position += delta * parallaxFactor;
        lastPos = cam.position;
    }
}