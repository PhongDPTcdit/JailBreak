using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardState : MonoBehaviour
{
    public enum StatementOfGuard
    {
        NormalState,
        TriggerState,
        RunningState,
        LostSignalState
    }
    private StatementOfGuard statementOfGuard;

    public GameObject _questionMark;

    public float detectionRange = 10f;
    public GameObject player;
    private bool playerInRange = false;

    public static GuardState instance;

    private void Awake()
    {
        instance = this;
        statementOfGuard = StatementOfGuard.NormalState;
    }
    private void Update()
    {
        switch (statementOfGuard)
        {
            case StatementOfGuard.NormalState:
                NormalStateFunction();
                break;
            case StatementOfGuard.TriggerState:
                TriggerStateFunction();
                break;
            case StatementOfGuard.RunningState:
                RunningStateFunction();
                break;
            case StatementOfGuard.LostSignalState:
                LostSignalStateFunction();
                break;
        }
    }
    private void NormalStateFunction()
    {
        _questionMark.SetActive(false);
        if (Vector3.Distance(transform.position, player.transform.position) <= detectionRange)
        {
            // Set flag to true if player is in range
            playerInRange = true;
        }
        else
        {
            // Set flag to false if player is out of range
            playerInRange = false;
        }

        if (playerInRange)
        {
            // Move towards the player if in range
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 4 * Time.deltaTime);
        }
        else
        {
            // Move towards the current point if player is out of range
            //if (transform.position != movePoints[currentPointIndex].position)
            //{
            //    transform.position = Vector3.MoveTowards(transform.position, movePoints[currentPointIndex].position, moveSpeed * Time.deltaTime);
            //}
            //else
            //{
            //    // If the object has reached the current point, move to the next point
            //    currentPointIndex = (currentPointIndex + 1) % movePoints.Length;
            //}
        }
    }
    private void TriggerStateFunction()
    {
        _questionMark.SetActive(true);
    }
    private void RunningStateFunction()
    {

    }
    private void LostSignalStateFunction()
    {

    }
}
