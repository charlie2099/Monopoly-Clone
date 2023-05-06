using UnityEngine;
using UnityEngine.UI;

public class EndTurnInputHandler : MonoBehaviour
{
    [SerializeField] private Button endTurnButton;

    private void OnEnable() => endTurnButton.onClick.AddListener(EndTurn);
    private void OnDisable() => endTurnButton.onClick.RemoveListener(EndTurn);

    private void EndTurn()
    {
        GameManager.Instance.EndTurn();
    }
}
