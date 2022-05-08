using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageProjectileHandler : ProjectileHandler
{

    Vector3 velocity;

    private void Awake() {
        velocity = Random.insideUnitCircle * 15;

        // try to find a target
        // for now, just get the ball
        target = GameObject.Find("Ball").transform;
    }

    private void Update() {
        // move towards a target
        // if no target can be found, just go to the world origin
        Vector3 targetPos = Vector3.zero;

        if (target != null) {
            targetPos = target.position;
        }

        Vector3 targetVel = (targetPos - transform.position).normalized * maxSpeed;

        velocity = Vector3.MoveTowards(velocity, targetVel, 40 * Time.deltaTime);

        transform.position += velocity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // if other can be damaged, deal damage
        // and disable or destroy the projectile

        if (other.CompareTag("Ball")) {
            Destroy(gameObject);
        }
    }
}
