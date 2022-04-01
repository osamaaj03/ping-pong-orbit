using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pong.Entities;

namespace Pong.Core
{
    public class ObjectPool : MonoBehaviour
    {

        [SerializeField] Enemy enemy;
        [SerializeField] int poolSize;
        [SerializeField] float respawnInterval;
        [SerializeField] Transform spawnPoint;
        Enemy[] objectPool;
        
        private void Awake() {
            PopulatePool();
        }

        private void PopulatePool(){
            objectPool = new Enemy[poolSize];

            for (int i = 0; i < poolSize; i++)
            {
                objectPool[i] = Instantiate(enemy, transform);
                objectPool[i].gameObject.SetActive(false);
                objectPool[i].SpawnPoint = spawnPoint.position;
            }
        }

        private void Start() {
            StartCoroutine(RespawnCoroutine());
        }

        private IEnumerator RespawnCoroutine() {
            while (true)
            {
                RespawnEnemy();
                yield return new WaitForSeconds(respawnInterval);
            }
        }

        private void RespawnEnemy() {
            
            foreach (Enemy enemy in objectPool)
            {
                print(enemy.enabled);
                if (!enemy.isActiveAndEnabled) { 
                    enemy.gameObject.SetActive(true);
                    return;
                }
            }
        }  
    } 
}
