using UnityEngine;

public class Board : MonoBehaviour
{
    private IBoard _board;

    public void SetBoard(IBoard board)
    {
        _board = board;
    }
}
