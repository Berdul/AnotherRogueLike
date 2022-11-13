using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public Vector2 lastVelocity {get; protected set;}

    public abstract GameObject GetBulletPrefab();
    public abstract void Fire(Vector2 pointingDirection, Vector2 bulletSpawn, float angle);
}