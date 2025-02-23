using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f; // Speed of rotation in degrees per second

    // Update is called once per frame
    void Update()
    {
        // Rotate the gold around its Y-axis
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
