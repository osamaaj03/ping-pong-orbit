using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testControl : MonoBehaviour
{
    public GameObject enemy, wall;
    public Transform spawnEnemy, spawnWall;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(enemy, spawnEnemy.position, enemy.transform.rotation);
            Instantiate(wall, spawnWall.position, wall.transform.rotation);
        }
    }
}
