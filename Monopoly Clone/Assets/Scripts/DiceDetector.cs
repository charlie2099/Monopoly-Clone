using System;
using UnityEngine;

public class DiceDetector : MonoBehaviour
{
    public event Action<int> OnDiceResult;
    
    private void OnTriggerStay(Collider col)
    {
        if (col.attachedRigidbody.velocity.x == 0f && col.attachedRigidbody.velocity.y == 0f &&
            col.attachedRigidbody.velocity.z == 0f)
        {
            switch (col.gameObject.name)
            {
                case "Side1":
                    OnDiceResult?.Invoke(2);
                    Destroy(col.transform.parent.gameObject);
                    break;
                case "Side2":
                    OnDiceResult?.Invoke(1);
                    Destroy(col.transform.parent.gameObject);
                    break;
                case "Side3":
                    OnDiceResult?.Invoke(5);
                    Destroy(col.transform.parent.gameObject);
                    break;
                case "Side4":
                    OnDiceResult?.Invoke(6);
                    Destroy(col.transform.parent.gameObject);
                    break;
                case "Side5":
                    OnDiceResult?.Invoke(3);
                    Destroy(col.transform.parent.gameObject);
                    break;
                case "Side6":
                    OnDiceResult?.Invoke(4);
                    Destroy(col.transform.parent.gameObject);
                    break;
            }
        }
    }
}
