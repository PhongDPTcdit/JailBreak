using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

namespace MyCode
{
    public class GuardMovement : MonoBehaviour
    {
        public Transform[] patrolPositions;
        private int currentPositionIndex = 0;

        private NavMeshAgent agent;
        private Vector3 targetPosition;
        private bool isMoving = false;

        public float detectionRange = 10f; 
        private GameObject player;
        public GameObject questionMark;
        public GameObject panelPopUp;
        //public TextMeshProUGUI text_PopUp;

        private Animator animator;
        private void Awake()
        {
            transform.position = patrolPositions[0].position;
            PatrolMovement();
        }

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            questionMark.SetActive(false);
            player = GameObject.FindGameObjectWithTag("Player");
            panelPopUp.SetActive(false);
        }

        void Update()
        {           
            if(player.tag != "Player")
            {
                agent.SetDestination(targetPosition);
                questionMark.SetActive(false);
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    PatrolMovement();
                }
                Debug.Log("tag da doi");
            }

            if (Vector3.Distance(transform.position, player.transform.position) <= detectionRange)
            {
                StartCoroutine(SuspiciousTime());
            }
            else if (!isMoving)
            {
                agent.SetDestination(targetPosition);
                questionMark.SetActive(false);
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    PatrolMovement();
                }
            }
        }
        IEnumerator SuspiciousTime()
        {
            animator.SetBool("IsStanding", true);
            agent.SetDestination(gameObject.transform.position);
            yield return new WaitForSeconds(1);
            animator.SetBool("IsStanding", false);
            agent.SetDestination(player.transform.position);
            isMoving = true;
            questionMark.SetActive(true);
        }
        void PatrolMovement()
        {
            currentPositionIndex = (currentPositionIndex + 1) % patrolPositions.Length;

            targetPosition = patrolPositions[currentPositionIndex].position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                panelPopUp.SetActive(true);
                //text_PopUp.text = "You lose";
                player.SetActive(false);
                Debug.Log("touch player");
            }
        }
    }
}

