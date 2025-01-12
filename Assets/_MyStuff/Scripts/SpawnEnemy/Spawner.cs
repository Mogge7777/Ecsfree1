using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct Spawner : IComponentData
{
    public Entity Prefab;
    public float2 spawnPosition;
    //public float nextSpawnTime, spawnRate;
}