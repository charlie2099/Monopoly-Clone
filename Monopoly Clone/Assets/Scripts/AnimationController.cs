using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static AnimationController Instance;

    private Piece _piece;
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
            MoveTo(_piece, _destination);
        }
    }

    public void MoveTo(Piece piece, Vector3 destination)
    {
        _piece = piece;
        _destination = destination;
        _isPlaying = true;
        var speed = 2.5f * Time.deltaTime;
        piece.transform.position = Vector3.MoveTowards(piece.transform.position, destination, speed);
        //piece.transform.LookAt(destination);
        //piece.transform.position = Vector3.Lerp(piece.transform.position, destination, speed);

        if (piece.transform.position == destination)
        {
            _isPlaying = false;
        }
    }
}
