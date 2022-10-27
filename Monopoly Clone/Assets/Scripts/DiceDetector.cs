using UnityEngine;

public class DiceDetector : MonoBehaviour
{
    private void OnTriggerStay(Collider col)
    {
        if (col.attachedRigidbody.velocity.x == 0f && col.attachedRigidbody.velocity.y == 0f &&
            col.attachedRigidbody.velocity.z == 0f)
        {
            switch (col.gameObject.name)
            {
                case "Side1":
                    Debug.Log("2");
                    // use event?
                    BoardMaster.Instance.Dice.DiceOneOutput = 2;
                    BoardMaster.Instance.Dice.CalculateDiceOutput();
                    Destroy(col.transform.parent.gameObject);
                    break;
                case "Side2":
                    Debug.Log("1");
                    BoardMaster.Instance.Dice.DiceOneOutput = 1;
                    BoardMaster.Instance.Dice.CalculateDiceOutput();
                    Destroy(col.transform.parent.gameObject);
                    break;
                case "Side3":
                    Debug.Log("5");
                    BoardMaster.Instance.Dice.DiceOneOutput = 5;
                    BoardMaster.Instance.Dice.CalculateDiceOutput();
                    Destroy(col.transform.parent.gameObject);
                    break;
                case "Side4":
                    Debug.Log("6");
                    BoardMaster.Instance.Dice.DiceOneOutput = 6;
                    BoardMaster.Instance.Dice.CalculateDiceOutput();
                    Destroy(col.transform.parent.gameObject);
                    break;
                case "Side5":
                    Debug.Log("3");
                    BoardMaster.Instance.Dice.DiceOneOutput = 3;
                    BoardMaster.Instance.Dice.CalculateDiceOutput();
                    Destroy(col.transform.parent.gameObject);
                    break;
                case "Side6":
                    Debug.Log("4");
                    BoardMaster.Instance.Dice.DiceOneOutput = 4;
                    BoardMaster.Instance.Dice.CalculateDiceOutput();
                    Destroy(col.transform.parent.gameObject);
                    break;
            }
        }
    }
}
