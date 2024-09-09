using UnityEngine;

// Programs the camera to follow the car
public class FollowCamera : MonoBehaviour
{
    // This allows us to set which GameObject is being followed via the Unity UI.
    // We set it explicitly there to follow the car.
    [SerializeField] private GameObject thingToFollow;
    
    // Ensures that the camera only updates after the car's position has updated, so that it stays properly in-sync.
    private void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
