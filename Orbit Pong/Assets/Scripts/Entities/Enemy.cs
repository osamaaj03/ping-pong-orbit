using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Entities
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] float health = 10f;
        public Vector3 SpawnPoint { get; set; }

        private void OnDisable()
        {
            transform.position = SpawnPoint;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Projectile"))
            {
                TakeDamage(other.gameObject.GetComponent<ProjectileHandler>().Damage);
            }
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}