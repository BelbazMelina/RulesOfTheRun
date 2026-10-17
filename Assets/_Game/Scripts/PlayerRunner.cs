using UnityEngine;

public class PlayerRunner : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float laneChangeSpeed = 8f;
    [SerializeField] private float laneWidth = 4f;

    [Header("Intersection")]
    [SerializeField] private float choiceStartZ = 20f;
    [SerializeField] private float choiceEndZ = 30f;

    [Header("UI")]
    [SerializeField] private GameObject pathLabels;

    private bool isRunning = false;
    private bool choiceLocked = false;

    private int currentLane = 1;

    private void Start()
    {
        if (pathLabels != null)
            pathLabels.SetActive(false);
    }

    private void Update()
    {
        if (!isRunning)
            return;

        Vector3 position = transform.position;

        // Always move forward
        position.z += runSpeed * Time.deltaTime;

        // Check if player is approaching intersection
        bool canChoose =
            position.z >= choiceStartZ &&
            position.z < choiceEndZ &&
            !choiceLocked;

        // Show path labels during choice window
        if (pathLabels != null)
            pathLabels.SetActive(canChoose);

        // Allow choosing only near intersection
        if (canChoose)
        {
            if (Input.GetKeyDown(KeyCode.A))
                currentLane = 0;

            if (Input.GetKeyDown(KeyCode.W))
                currentLane = 1;

            if (Input.GetKeyDown(KeyCode.D))
                currentLane = 2;
        }

        // Lock choice once intersection is reached
        if (position.z >= choiceEndZ)
            choiceLocked = true;

        // Smoothly move toward chosen lane
        float targetX = (currentLane - 1) * laneWidth;

        position.x = Mathf.MoveTowards(
            position.x,
            targetX,
            laneChangeSpeed * Time.deltaTime
        );

        transform.position = position;
    }

    public void StartRunning()
    {
        isRunning = true;
    }

    public void StopRunning()
    {
        isRunning = false;
    }
}