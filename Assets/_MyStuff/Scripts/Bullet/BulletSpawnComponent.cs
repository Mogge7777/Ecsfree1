using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct BulletSpawnComponent : IComponentData
{
    public float2 spawnPosition;
    public Entity bulletPrefab;
    public float spawnRate;
    public float moveSpeed;
}
