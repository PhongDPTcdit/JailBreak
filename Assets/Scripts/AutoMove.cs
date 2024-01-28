using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCode
{
    public class AutoMove : MonoBehaviour
    {
        public Transform[] movePoints; 
        public float moveSpeed = 5f; 

        private int currentPointIndex = 0;

        void Start()
        {
            if (movePoints.Length == 0)
            {
                Debug.LogWarning("No move points assigned!");
                enabled = false;
            }
        }

        void Update()
        {
            if (transform.position != movePoints[currentPointIndex].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, movePoints[currentPointIndex].position, moveSpeed * Time.deltaTime);
            }
            else
            {
                currentPointIndex = (currentPointIndex + 1) % movePoints.Length;
            }
        }
    }
}