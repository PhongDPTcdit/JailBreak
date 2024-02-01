using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCode
{
    public class ChangePlayerMaterial : MonoBehaviour
    {
        public Renderer playerRenderer;
        public Material material_playerDefault;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Can-Hide"))
            {
                Material objectMaterial = collision.gameObject.GetComponent<Renderer>().material;

                playerRenderer.material = objectMaterial;

                gameObject.tag = "Hide State";
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.CompareTag("Can-Hide"))
            {
                playerRenderer.material = material_playerDefault;

                gameObject.tag = "Player";
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Can-Hide-Inside"))
            {
                Material objectMaterial = other.gameObject.GetComponent<Renderer>().material;

                playerRenderer.material = objectMaterial;

                gameObject.tag = "Hide State";
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Can-Hide-Inside"))
            {
                Material objectMaterial = other.gameObject.GetComponent<Renderer>().material;

                playerRenderer.material = material_playerDefault;

                gameObject.tag = "Hide State";
            }
        }
    }
}
