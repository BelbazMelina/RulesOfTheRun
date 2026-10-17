using UnityEngine;

public class PlayerRunner : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }
}