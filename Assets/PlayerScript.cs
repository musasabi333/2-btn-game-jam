using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private enum Buttons
    {
        None = -1,
        A = 0,
        B = 1,
        AB = 3,
        ABHold = 4
    }

    private Buttons _currentButton = Buttons.None;
    private const float jumpTime = 1f;
    private float _elapsedTime = 0f;
    private bool _aBHeld;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var aDown = Input.GetButtonDown("A");
        var bDown = Input.GetButtonDown("B");

        var aUp = Input.GetButtonUp("A");
        var bUp = Input.GetButtonUp("B");

        var aHeld = Input.GetButton("A");
        var bHeld = Input.GetButton("B");

        if (aHeld && bHeld)
            _aBHeld = true;
        else
            _aBHeld = false;

        if (aDown && bDown)
            _currentButton = Buttons.AB;
        else if (aUp)
            _currentButton = Buttons.A;
        else if (bUp)
            _currentButton = Buttons.B;
        else
            _currentButton = Buttons.None;

        if (_aBHeld)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > jumpTime)
            {
                _currentButton = Buttons.ABHold;
                _elapsedTime = 0f;
            }
        }

        Debug.Log(_currentButton);
        Debug.Log(_aBHeld);
    }
}
