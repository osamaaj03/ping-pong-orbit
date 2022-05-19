using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Runes
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Runes/New Homing Barrage")]
    public class RuneHomingBarrage : Rune
    {

        public float damage = 1f;
        public int projectileAmount = 5;

        [Tooltip("amount per second")]
        public float spawnSpeed = 5f;

        public GameObject projectilePrefab;

        public override IEnumerator ActivateRoutine(ShieldPaddle paddle)
        {

            int spawnCount = projectileAmount;

            while (spawnCount > 0)
            {
                GameObject projectile = Instantiate(projectilePrefab);
                projectile.transform.position = paddle.transform.position;

                // projectile behaviour will probably be handled on its own, but it might a good idea to at least set the damage here
                if (projectile.TryGetComponent(out ProjectileHandler handler))
                {
                    handler.Damage = damage;
                }

                spawnCount--;
                yield return new WaitForSeconds(1f / spawnSpeed);
            }

        }

    }
}
