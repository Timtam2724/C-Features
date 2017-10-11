using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{
   
    public class Ball : MonoBehaviour
    {
        //public int score;        
        public float stopSpeed = 0.2f;
        public Billiards.ScoreManager scoreManager; // Assigns the ScoreManager script as scoreManager
        private Rigidbody rigid;

        // Activates the script at the start of the game
        void Awake()
        {
            scoreManager = GameObject.Find("ScoreManager").GetComponent<Billiards.ScoreManager>();//Get the ScoreMAnager at the start of the game
        }

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void FixedUpdate()
        {
            Vector3 vel = rigid.velocity;

            // Check if velocity is going up
            if (vel.y > 0)
            {
                // Cap velocity
                vel.y = 0;
            }

            // If the velocity's speed is less than the stop speed
            if (vel.magnitude < stopSpeed)
            {
                // Cancel out velocity
                vel = Vector3.zero;
            }
            // Apply desired 'vel' to rigid's velocity
            rigid.velocity = vel;
        }
        
        public void Hit(Vector3 direction, float impactForce)
        {
            rigid.AddForce(direction * impactForce, ForceMode.Impulse);
        }
        // This script activates when the ball hit the bottom of each pocket
        void OnTriggerEnter (Collider col)
        {
            if (col.tag == "Mat")
            {
                scoreManager.score += 1;//scoreManagers score = score + 1;
                Destroy(gameObject);
            }
        }
    }
}
