using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileHandler : MonoBehaviour
{
    public float maxSpeed = 1;
    [SerializeField] float damage;
    public Transform target;

    public float Damage
    {
        get => damage; set => damage = value;
    }
}
