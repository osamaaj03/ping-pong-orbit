using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileHandler : MonoBehaviour
{
    public float maxSpeed = 1;
    public float damage;
    public Transform target;
}
