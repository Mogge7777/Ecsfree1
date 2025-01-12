using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpawnerPrefabAuthoring : MonoBehaviour
{
    public GameObject Prefab;
    public float2 spawnPosition;
    public float spawnRate;

    public class Baker : Baker<SpawnerPrefabAuthoring>
    {
        public override void Bake(SpawnerPrefabAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);

            AddComponent(entity, new SpawnerPrefabConfig
            {
                EnemyPrefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
                spawnPosition = authoring.spawnPosition,
                spawnRate = authoring.spawnRate,
            });
        }
    }

    public struct SpawnerPrefabConfig : IComponentData
    {
        public Entity EnemyPrefab;
        public float2 spawnPosition;
        public float spawnRate;
    }
}
