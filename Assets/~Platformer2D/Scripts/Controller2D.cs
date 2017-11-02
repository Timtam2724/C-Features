using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Controller2D : MonoBehaviour
    {
        public float accelerate = 20f;
        public float jumphieght = 10f;
        public float rayDistance = 1f;
        public LayerMask ignoresLayers;
        public bool isGrounded = false;

        private Rigidbody2D rigid2D;

        // Use this for initialization
        void Start()
        {
            rigid2D = GetComponent<Rigidbody2D>();
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, transform.position + -transform.up * rayDistance);
        }

        void FixedUpdate()
        {
            // Perform the racast and only detect for ground (ignoreLayers)
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, rayDistance, ~ignoresLayers);
            // Detect if ray hit something
            if (hit.collider != null)
            {
                // Set isGrounded to true when you are grounded
                isGrounded = true;
            }
            else
            {
                // Set isGrounded to false when you are NOT grounded
                isGrounded = false;
            }
        }

        public void Move(float inputH)
        {
            rigid2D.AddForce(transform.right * inputH * accelerate);           
        }

        public void Jump()
        {
            rigid2D.AddForce(transform.up * jumphieght, ForceMode2D.Impulse);
           
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
