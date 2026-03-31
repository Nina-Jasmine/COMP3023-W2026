using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [Header("Parallax Settings")]
    [Range(0f, 1f)]
    public float parallaxStrength;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        // Calculate the movement of the camera since the last frame.
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        // Update the transform of the parallaxed image
        // Parallax Strength = 1 - 0 movement (static)
        // Parallax Strength = 0 - Full movement (follows camera)
        transform.position += new Vector3(
            deltaMovement.x * (1 - parallaxStrength), 
            deltaMovement.y * (1 - parallaxStrength), 
            0);

        lastCameraPosition= cameraTransform.position;
    }
}
