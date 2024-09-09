using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 150;

    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float slowSpeed = 5;
    [SerializeField] private float boostSpeed = 20;

    private float _currentSpeed;

    private void Start()
    {
        _currentSpeed = moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Boost")) return;

        Debug.Log("Boost");
        _currentSpeed = boostSpeed;
    }

    private void OnCollisionEnter2D()
    {
        Debug.Log("Bump");
        _currentSpeed = slowSpeed;
    }

    // Update is called once per frame
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