using UnityEngine;

public class RulesScreen : MonoBehaviour
{
    [SerializeField] private GameObject rulesPanel;

    public void HideRules()
    {
        rulesPanel.SetActive(false);
    }
}