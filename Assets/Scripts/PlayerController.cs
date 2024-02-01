using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCode
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private Animator animator; 
        private Rigidbody rb; 

        void Start()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

            if (moveDirection.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

                Vector3 movePosition = transform.forward * moveSpeed * Time.deltaTime;
                rb.MovePosition(rb.position + movePosition);

                animator.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }
            
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Can-hide")
            {
                gameObject.tag = "Hide State";
            }
        }
    }
}
