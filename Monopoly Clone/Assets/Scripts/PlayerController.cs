using Commands;
using Tiles;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [FormerlySerializedAs("piece")] [SerializeField] private Token token;
    private CommandInvoker _commandInvoker = new CommandInvoker();
    private Token selectedToken;
    private Tile selectedPropertyTile;

    private void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hitInfo.transform.GetComponent<Token>() == token)
                {
                    Debug.Log("Piece: <color=orange>" + hitInfo.transform.GetComponent<Token>().PieceName + "</color>");
                    selectedToken = hitInfo.transform.GetComponent<Token>();
                }
                
                if (selectedToken == null)
                {
                    Debug.LogError("A Piece must be selected before a Tile can be selected!");
                    return;
                }
               
                // if clicked object is a Tile and it is empty, move piece to it
                if (hitInfo.transform.GetComponent<Tile>() != null /*&& hitInfo.transform.GetComponent<Tile>().IsEmpty*/) 
                {
                    Debug.Log("Tile: <color=lime>" + hitInfo.transform.name + "</color>");
                    
                    selectedPropertyTile = hitInfo.transform.GetComponent<Tile>(); 
                    Tile previousPropertyTile = token.CurrentTile;
                    
                    _commandInvoker.AddCommand(new MoveCommand(token, previousPropertyTile, selectedPropertyTile));

                    // Update the state of the tile
                    //previousTile.IsEmpty = true;
                    //_selectedTile.IsEmpty = false; // Nullifies(?) the if statement condition here

                    // Clear selection after move
                    selectedToken = null;
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
