using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pong.Entities;
using System.Linq;

public class BarrageProjectileHandler : ProjectileHandler
{

    Vector3 velocity;

    [SerializeField] float destroyAfterTime = 3f;
    float timeAlive = 0;

    private void Awake()
    {
        velocity = Random.insideUnitCircle * 15;

        List<Enemy> enemies = FindObjectsOfType<Enemy>().ToList();

        if (enemies.Count > 0)
        {
            // Find transforms of all enemies and store in a list
            List<Transform> enemyTransforms = new List<Transform>();
            foreach (Enemy enemy in enemies)
            {
                enemyTransforms.Add(enemy.transform);
            }

            // Find the closest enemy to the projectile
            Transform closestEnemy = enemyTransforms.OrderBy(x => Vector3.Distance(transform.position, x.position)).First();
            target = closestEnemy;
        }
    }

    private void OnDisable()
    {
        timeAlive = 0;
    }

    private void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive >= destroyAfterTime) { gameObject.SetActive(false); }

        // move towards a target
        // if no target can be found, just go to the world origin
        Vector3 targetPos = Vector3.zero;

        if (target != null)
        {
            targetPos = target.position;
        }

        Vector3 targetVel = (targetPos - transform.position).normalized * maxSpeed;

        velocity = Vector3.MoveTowards(velocity, targetVel, 40 * Time.deltaTime);

        transform.position += velocity * Time.deltaTime;
    }
}
