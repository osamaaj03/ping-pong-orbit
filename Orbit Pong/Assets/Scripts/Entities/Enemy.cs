using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Entities
{
    public class Enemy : MonoBehaviour
    {
        public Vector3 SpawnPoint {get; set;}
        float autoDestructionTimeToTest = 3f;
        float timeAlive = 0;

        private void OnDisable() {
            transform.position = SpawnPoint;
            timeAlive = 0;
        }

        private void Update() {
            // this is only for test purpose. To check the behaviour when the enemy is deactivated (killed)
            timeAlive += Time.deltaTime;
            if (timeAlive >= autoDestructionTimeToTest) { gameObject.SetActive(false);}
        }
    }
}