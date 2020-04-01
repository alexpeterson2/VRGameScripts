using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatAdvancedMovement : MonoBehaviour
{
    // In game water
    public GameObject water;
    // Water elevation
    private float waterLevel;

    // Boat's Rigidbody
    public Rigidbody rbBoat;

    // Oar locks
    public GameObject leftOarLock;
    public GameObject rightOarLock;
    private Vector3 leftLockPos;
    private Vector3 rightLockPos;

    // Left and Right Oars
    public GameObject leftOar;
    public GameObject rightOar;
    // Position of Oar Ends
    private Vector3 leftPos;
    private Vector3 rightPos;

    // Thrust from Oars moving through water
    private Vector3 leftThrust;
    private Vector3 rightThrust;

    // Previous transform positions of Oars
    private Vector3 prevLeftPos;
    private Vector3 prevRightPos;

    void Start()
    {
        waterLevel = water.transform.position.y;
        leftLockPos = leftOarLock.transform.position;
        rightLockPos = rightOarLock.transform.position;
        leftPos = leftOar.transform.position;
        rightPos = rightOar.transform.position;
        prevLeftPos = leftPos;
        prevRightPos = rightPos;
    }

    private void FixedUpdate()
    {
       if (leftPos.y > 0)
        {
            prevLeftPos = leftPos;
            return;
        }
        else if (leftPos.y < 0)
        {
            leftThrust = (prevLeftPos - leftPos);
            leftThrust *= waterLevel * -leftPos.y;
            leftThrust.y = 0;
            rbBoat.AddForceAtPosition(leftThrust, leftLockPos);
            prevLeftPos = leftPos;
        }

        if (rightPos.y > 0)
        {
            prevRightPos = rightPos;
            return;
        }
        else if (rightPos.y < 0)
        {
            rightThrust = (prevRightPos - rightPos);
            rightThrust *= waterLevel * -rightPos.y;
            rightThrust.y = 0;
            rbBoat.AddForceAtPosition(rightThrust, rightLockPos);
            prevRightPos = rightPos;
        }
    }

}
