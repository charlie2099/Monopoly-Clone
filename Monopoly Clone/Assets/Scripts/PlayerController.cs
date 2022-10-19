using Commands;
using Tiles;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Piece piece;
    private CommandInvoker _commandInvoker = new CommandInvoker();
    private Piece _selectedPiece;
    private Tile selectedPropertyTile;

    private void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hitInfo.transform.GetComponent<Piece>() == piece)
                {
                    Debug.Log("Piece: <color=orange>" + hitInfo.transform.GetComponent<Piece>().PieceName + "</color>");
                    _selectedPiece = hitInfo.transform.GetComponent<Piece>();
                }
                
                if (_selectedPiece == null)
                {
                    Debug.LogError("A Piece must be selected before a Tile can be selected!");
                    return;
                }
               
                // if clicked object is a Tile and it is empty, move piece to it
                if (hitInfo.transform.GetComponent<Tile>() != null /*&& hitInfo.transform.GetComponent<Tile>().IsEmpty*/) 
                {
                    Debug.Log("Tile: <color=lime>" + hitInfo.transform.name + "</color>");
                    
                    selectedPropertyTile = hitInfo.transform.GetComponent<Tile>(); 
                    Tile previousPropertyTile = piece.CurrentTile;
                    
                    _commandInvoker.AddCommand(new MoveCommand(piece, previousPropertyTile, selectedPropertyTile));

                    // Update the state of the tile
                    //previousTile.IsEmpty = true;
                    //_selectedTile.IsEmpty = false; // Nullifies(?) the if statement condition here

                    // Clear selection after move
                    _selectedPiece = null;
                    selectedPropertyTile = null;
                }
            }
        }
    }
    
    // If mouse at piece position and mouse is clicked
    //    Select piece
    //    If a tile is clicked that is not the pieces current tile
    //        Move piece to tile
    //    If anything other than a tile is clicked
    //        Clear the selected piece (null)
}
