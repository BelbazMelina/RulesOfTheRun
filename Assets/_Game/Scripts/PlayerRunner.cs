using UnityEngine;

public class PlayerRunner : MonoBehaviour
{
    [SerializeField] private float runSpeed = 5f;

    private void Update()
    {
        transform.position += Vector3.forward * runSpeed * Time.deltaTime;
    }
}