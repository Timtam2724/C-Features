using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Tower : MonoBehaviour
    {
        public Cannon cannon; // Reference to cannon inside of tower
        public float attackRate = 0.25f; // Rate of attack in seconds
        public float attackRadius = 5f; // Distance of attack in world units
        private float attackTimer = 0f; // Timer to count up to attackRate
        private List<Enemy> enemies = new List<Enemy>(); // List of enemies within radius
        
        void OnTriggerEnter(Collider col)
        {
            // LET e = col's Enemy component
            Enemy e = col.GetComponent<Enemy>();
            // IF e != null
            if (e != null)
            {
                // Add e to enemies list
                enemies.Add(e);
            }
        }

        void OnTriggerExit(Collider col)
        {
            // LET e = col's Enemy component
            Enemy e = col.GetComponent<Enemy>();
            // IF e != null
            if (e != null)
            {
                // Remove e from enemies list
                enemies.Remove(e);
            }            
        }
        Enemy GetClosestEnemy()
        {
            // SET enemies = RemoveAllNulls(enemies)
            enemies = RemoveAllNulls(enemies);
            // LET closest = null
            Enemy closest = null;
            // LET minDistance = float.MaxValue
            float minDistance = float.MaxValue;
            // FOREACH enemy in enemies
            foreach (Enemy enemyUnit in enemies) {
                // LET distance = the distance between transform's position and enemy's position
                float distance = Vector3.Distance(transform.position, enemyUnit.transform.position);
                /*
                float instead of int coz distance can be a decimal 
                using Vector3 . Distance with tower position and each enemy units position
                */
                // IF distance < minDistance
                if (distance < minDistance)
                {
                    /*
                    if the distance between the tower and the target is less than min distance
                    */
                    // SET minDistance = distance
                    /*
                    giving us a new min distance
                    */
                    minDistance = distance;
                    // SET closest = enemy
                    closest = enemyUnit;
                }
            }
            // RETURN closest
            return closest;
        }
        void Attack()
        {
            // LET closest to GetClosestEnemy()
            Enemy closest = GetClosestEnemy();            
            // If closest != null
            if (closest != null)
            {
                cannon.Fire(closest);
            }
        } 
        void Update()
        {
            attackTimer = attackTimer + Time.deltaTime;
            if (attackTimer >= attackRate)
            {
                Attack();
                attackTimer = 0;
            }
        }
        List<Enemy> RemoveAllNulls(List<Enemy> listWithNulls)
        {
            // LET listWithoutNulls = new List
            List<Enemy> listWithoutNulls = new List<Enemy>();

            // Loop through listWithNulls
            foreach (Enemy enemyUnit in listWithNulls)
            {
                // IF element is NOT null
                if (enemyUnit != null)
                {
                    // Add element to listWithoutNulls
                    listWithoutNulls.Add(enemyUnit);
                }
            }
            // RETURN
            return listWithoutNulls;
        }
    }    
}
