using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet {

    public GameObject GetBulletPrefab();
    public void Fire(Vector2 pointingDirection, Vector2 bulletSpawn, float angle);

}