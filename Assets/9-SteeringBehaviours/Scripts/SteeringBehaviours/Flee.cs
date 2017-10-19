using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGL;

namespace AI
{
    public class Flee : SteeringBehaviour
    {

        public Transform target;
        public float stoppingDistance = 1f;

        public override Vector3 GetForce()
        {
            // SET force to Vector3 zero
            Vector3 force = Vector3.zero;
            // IF target == null
            if (target == null)
            {
                // return force
                return force;
            }

            // LET desiredForce = target position - transform position
            var desiredForce = transform.position - target.position;
            // IF desiredForce magnitude > stopping Distance
            if (desiredForce.magnitude > stoppingDistance)
            {
                // desiredForce = desiredForce normalized x weighting
                desiredForce = desiredForce.normalized * weighting;
                // force = desiredForce - owner.velocity
                force = desiredForce - owner.velocity;
            }

            #region GizomsGL
            GizmosGL.color = Color.red;
            GizmosGL.AddLine(transform.position, transform.position + desiredForce, 0.25f, 0.25f);
            GizmosGL.color = Color.blue;
            GizmosGL.AddLine(transform.position, transform.position + force, 0.25f, 0.25f);
            #endregion

            // Return force
            return force;
        }
    }
}
