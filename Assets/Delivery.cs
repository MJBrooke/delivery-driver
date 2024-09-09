using UnityEngine;

// Handles logic around picking up and dropping off packages
public class Delivery : MonoBehaviour
{
    [SerializeField] private Color32 hasPackageColour = new(207, 176, 54, 255);
    [SerializeField] private Color32 noPackageColour = new(255, 255, 255, 255);

    [SerializeField] private float packageDestroyTime = 0.1f;
    private bool _hasPackage;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        // This automatically fetches the SpriteRenderer component that this script is attached to.
        // In this case, it gets a reference to the car's render.
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Is invoked if the car intersects with any other Collider2D that is marked with `IsTrigger = true`
    // In this case, we setup triggers as a package to be collected and as a customer to be delivered to.
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Package":
                if (!_hasPackage)
                {
                    Debug.Log("Package collected!");
                    _hasPackage = true;
                    _spriteRenderer.color = hasPackageColour;
                    Destroy(other.gameObject, packageDestroyTime);
                }

                break;
            case "Customer":
                if (_hasPackage)
                {
                    Debug.Log("Package delivered!");
                    _hasPackage = false;
                    _spriteRenderer.color = noPackageColour;
                }
                break;
        }
    }
}