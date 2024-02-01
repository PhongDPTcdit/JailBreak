using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyCode
{
    
    public class LevelPassTrigger : MonoBehaviour
    {
        public GameObject panel_WinPopUp;

        private void Start()
        {
            panel_WinPopUp.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.SetActive(false);
                panel_WinPopUp.SetActive(true);
            }
            
        }
    }
}
