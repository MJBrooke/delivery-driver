using UnityEngine;

// Handles the movement of the car, including speed and steering
public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 150;

    [SerializeField] private float defaultSpeed = 10;
    [SerializeField] private float boostSpeed = 20;

    private float _currentSpeed;

    private void Start()
    {
        _currentSpeed = defaultSpeed;
    }

    // Is invoked if the car intersects with any other Collider2D that is marked with `IsTrigger = false`
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Boost")) return;

        Debug.Log("Boost");
        _currentSpeed = boostSpeed;
    }

    // Is invoked if the car intersects with any other Collider2D that is marked with `IsTrigger = true`
    private void OnCollisionEnter2D()
    {
        Debug.Log("Bump");
        _currentSpeed = defaultSpeed;
    }

    private void Update()
    {
        var moveAmount = Input.GetAxis("Vertical") * _currentSpeed * Time.deltaTime;
        
        // Only steer if the car is moving
        var steerAmount = (moveAmount != 0) ? Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime : 0;
        
        // Consistent steer direction for forward and reverse
        if (moveAmount > 0) steerAmount = -steerAmount;
        
        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}