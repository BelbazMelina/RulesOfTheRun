using System.Collections;
using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerRunner player;
    [SerializeField] private GameObject choicePanel;

    [Header("Settings")]
    [SerializeField] private float timeBeforeChoice = 5f;

    private void Start()
    {
        choicePanel.SetActive(false);
    }

    public void BeginChoices()
    {
        StartCoroutine(ChoiceSequence());
    }

    private IEnumerator ChoiceSequence()
    {
        yield return new WaitForSeconds(timeBeforeChoice);

        player.StopRunning();
        choicePanel.SetActive(true);
    }

    public void ChooseRed()
    {
        Debug.Log("Correct choice! You survived.");
        choicePanel.SetActive(false);
        player.StartRunning();
    }

    public void ChooseCrows()
    {
        Debug.Log("Wrong choice! The scarecrow gets closer.");
        choicePanel.SetActive(false);
        player.StartRunning();
    }

    public void ChooseDarkness()
    {
        Debug.Log("Wrong choice! The scarecrow gets closer.");
        choicePanel.SetActive(false);
        player.StartRunning();
    }
}