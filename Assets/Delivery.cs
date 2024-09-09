using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private Color32 hasPackageColour = new(207, 176, 54, 255);
    [SerializeField] private Color32 noPackageColour = new(255, 255, 255, 255);

    [SerializeField] private float packageDestroyTime = 0.1f;
    private bool _hasPackage;

    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
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