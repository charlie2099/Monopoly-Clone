using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static AnimationController Instance;

    private Token token;
    private Vector3 _destination;
    private bool _isPlaying;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (_isPlaying)
        {
            MoveTo(token, _destination);
        }
    }

    public void MoveTo(Token token, Vector3 destination)
    {
        this.token = token;
        _destination = destination;
        _isPlaying = true;
        var speed = 2.5f * Time.deltaTime;
        token.transform.position = Vector3.MoveTowards(token.transform.position, destination, speed);
        //piece.transform.LookAt(destination);
        //piece.transform.position = Vector3.Lerp(piece.transform.position, destination, speed);

        if (token.transform.position == destination)
        {
            _isPlaying = false;
        }
    }
}
