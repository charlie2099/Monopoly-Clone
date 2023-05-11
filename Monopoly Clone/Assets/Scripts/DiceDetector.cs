using System;
using System.Collections;
using UnityEngine;

public class DiceDetector : MonoBehaviour
{
    public event Action<int> OnDiceResult;
    public event Action OnDiceResultFailed;

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Dice"))
        {
            Rigidbody diceRb = col.attachedRigidbody;
            if (diceRb.velocity == Vector3.zero)
            {
                switch (col.gameObject.name)
                {
                    case "Side1":
                        OnDiceResult?.Invoke(2);
                        col.gameObject.SetActive(false);
                        break;
                    case "Side2":
                        OnDiceResult?.Invoke(1);
                        col.gameObject.SetActive(false);
                        break;
                    case "Side3":
                        OnDiceResult?.Invoke(5);
                        col.gameObject.SetActive(false);
                        break;
                    case "Side4":
                        OnDiceResult?.Invoke(6);
                        col.gameObject.SetActive(false);
                        break;
                    case "Side5":
                        OnDiceResult?.Invoke(3);
                        col.gameObject.SetActive(false);
                        break;
                    case "Side6":
                        OnDiceResult?.Invoke(4);
                        col.gameObject.SetActive(false);
                        break;
                    default:
                        OnDiceResultFailed?.Invoke();
                        break;
                }
            }
        }
    }
}
