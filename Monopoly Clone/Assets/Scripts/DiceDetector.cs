using System;
using System.Collections;
using UnityEngine;

public class DiceDetector : MonoBehaviour
{
    public event Action<int> OnDiceResult;
    public event Action OnDiceLandFailed;
    
    private Coroutine _checkDiceLandHasFailedCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dice") && _checkDiceLandHasFailedCoroutine == null)
        {
            _checkDiceLandHasFailedCoroutine = StartCoroutine(BeginDiceLandedCheck());
        }
    }

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
                        StopCoroutine(_checkDiceLandHasFailedCoroutine);
                        col.gameObject.SetActive(false);
                        break;
                    case "Side2":
                        OnDiceResult?.Invoke(1);
                        StopCoroutine(_checkDiceLandHasFailedCoroutine);
                        col.gameObject.SetActive(false);
                        break;
                    case "Side3":
                        OnDiceResult?.Invoke(5);
                        StopCoroutine(_checkDiceLandHasFailedCoroutine);
                        col.gameObject.SetActive(false);
                        break;
                    case "Side4":
                        OnDiceResult?.Invoke(6);
                        StopCoroutine(_checkDiceLandHasFailedCoroutine);
                        col.gameObject.SetActive(false);
                        break;
                    case "Side5":
                        OnDiceResult?.Invoke(3);
                        StopCoroutine(_checkDiceLandHasFailedCoroutine);
                        col.gameObject.SetActive(false);
                        break;
                    case "Side6":
                        OnDiceResult?.Invoke(4);
                        StopCoroutine(_checkDiceLandHasFailedCoroutine);
                        col.gameObject.SetActive(false);
                        break;
                }
            }
        }
    }
    
    /// <summary>
    /// Invokes a failure event if both dice fail to land successfully after x amount of time
    /// </summary>
    private IEnumerator BeginDiceLandedCheck()
    {
        yield return new WaitForSeconds(6f);
        OnDiceLandFailed?.Invoke();
        _checkDiceLandHasFailedCoroutine = null;
    }
}
