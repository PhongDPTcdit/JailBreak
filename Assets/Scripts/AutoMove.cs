using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCode
{
    public class AutoMove : MonoBehaviour
    {
        public Transform[] movePoints; // Array to hold the points the object will move to
        public float moveSpeed = 5f; // Speed of movement between points
        public float detectionRange = 10f; // Range to detect the player
        public GameObject player; // Reference to the player object

        private int currentPointIndex = 0; // Index of the current point in the movePoints array
        private bool playerInRange = false; // Flag to track if player is in range
        private Vector3 originalPosition; // Original position of the bot

        void Start()
        {
            //player = FindObjectOfType<SpatialAvatar>();
            // Make sure there are move points assigned
            if (movePoints.Length == 0)
            {
                Debug.LogWarning("No move points assigned!");
                enabled = false; // Disable the script if there are no move points
            }

            // Save the original position of the bot
            originalPosition = transform.position;
        }

        void Update()
        {
            // Check if the player is in range
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
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                // Move towards the current point if player is out of range
                if (transform.position != movePoints[currentPointIndex].position)
                {
                    transform.position = Vector3.MoveTowards(transform.position, movePoints[currentPointIndex].position, moveSpeed * Time.deltaTime);
                }
                else
                {
                    // If the object has reached the current point, move to the next point
                    currentPointIndex = (currentPointIndex + 1) % movePoints.Length;
                }
            }
        }
    }
}