using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceRoller : MonoBehaviour
{
    public event Action OnDiceThrown;
    
    [SerializeField] private GameObject dicePrefab;
    [SerializeField] private Transform diceOneSpawnLocation;
    [SerializeField] private Transform diceTwoSpawnLocation;
    [SerializeField] private float throwForce = 350.0f;
    private GameObject _diceOne;
    private GameObject _diceTwo;
    private Rigidbody _diceOneRb;
    private Rigidbody _diceTwoRb;

    private void Awake()
    {
        _diceOne = Instantiate(dicePrefab, diceOneSpawnLocation.position, Quaternion.identity);
        _diceTwo = Instantiate(dicePrefab, diceTwoSpawnLocation.position, Quaternion.identity);
        _diceOneRb = _diceOne.GetComponent<Rigidbody>();
        _diceTwoRb = _diceTwo.GetComponent<Rigidbody>();
        HideDice();
    }

    public void Throw()
    {
        ShowDice();
        ApplyForcesAndTorque();
        OnDiceThrown?.Invoke();
    }

    private void ShowDice()
    {
        _diceOne.SetActive(true);
        _diceTwo.SetActive(true);
    }

    public void HideDice()
    {
        _diceOne.SetActive(false);
        _diceTwo.SetActive(false);
    }

    public void ResetDice()
    {
        _diceOne.transform.position = diceOneSpawnLocation.position;
        _diceTwo.transform.position = diceTwoSpawnLocation.position;

        const int SIDES = 6;
        for (var i = 0; i < SIDES; i++)
        {
            _diceOne.transform.GetChild(i).transform.gameObject.SetActive(true);
            _diceTwo.transform.GetChild(i).transform.gameObject.SetActive(true);
        }
    }

    private void ApplyForcesAndTorque()
    {
        float diceOneDirX = Random.Range(0, 500);
        float diceOneDirY = Random.Range(0, 500);
        float diceOneDirZ = Random.Range(0, 500);
        Vector3 diceOneDirection = new Vector3(diceOneDirX, diceOneDirY, diceOneDirZ);
        
        float diceTwoDirX = Random.Range(0, 500);
        float diceTwoDirY = Random.Range(0, 500);
        float diceTwoDirZ = Random.Range(0, 500);
        Vector3 diceTwoDirection = new Vector3(diceTwoDirX, diceTwoDirY, diceTwoDirZ);
        
        _diceOneRb.AddForce(-transform.right * throwForce);
        _diceOneRb.AddTorque(diceOneDirection);
        
        _diceTwoRb.AddForce(-transform.right * throwForce);
        _diceTwoRb.AddTorque(diceTwoDirection);
    }
}
