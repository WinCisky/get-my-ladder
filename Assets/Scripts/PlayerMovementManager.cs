using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// enum ladder statuses
public enum LadderStatus
{
    Swing,
    Extend,
    Check
}

public class PlayerMovementManager : MonoBehaviour
{
    private LadderStatus ladderStatus;
    private float ladderAngle;
    private bool rotatingForward;
    private float ladderRotationSpeed = .5f;
    public GameObject player, ladder;
    // Start is called before the first frame update
    void Start()
    {
        ladderStatus = LadderStatus.Swing;
        ladderAngle = 0;
        rotatingForward = true;
    }

    // Update is called once per frame
    void Update()
    {
        //swing ladder
        UpdateLadder();
    }

    private void UpdateLadder() {
        switch (ladderStatus)
        {
            case LadderStatus.Swing:
                RotateLadder();
                break;
            case LadderStatus.Extend:
                break;
            case LadderStatus.Check:
                break;
            default:
                break;
        }
    }

    private void RotateLadder()
    {
        // rotate ladder from 0 to 180 degrees and back above player
        if (rotatingForward){
            ladderAngle += ladderRotationSpeed;
            if (ladderAngle >= 90)
            {
                rotatingForward = false;
            }
        }
        else
        {
            ladderAngle -= ladderRotationSpeed;
            if (ladderAngle <= -90)
            {
                rotatingForward = true;
            }
        }
        ladder.transform.rotation = Quaternion.Euler(0, 0, ladderAngle);
    }
}
