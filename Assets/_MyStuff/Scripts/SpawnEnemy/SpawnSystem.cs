using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static SpawnerPrefabAuthoring;

public partial class SpawnSystem : SystemBase
{
    public float time;
    protected override void OnCreate()
    {
        time = 0f;
    }
    protected override void OnDestroy()
    {

    }

    
    
    protected override void OnUpdate()
    {
        //this.Enabled = false;
        SpawnerPrefabConfig spawnCubeAuthoring = SystemAPI.GetSingleton<SpawnerPrefabConfig>();
        time += SystemAPI.Time.DeltaTime;
        if (time >= spawnCubeAuthoring.spawnRate) 
        {
            Entity spawnedEntity = EntityManager.Instantiate(spawnCubeAuthoring.EnemyPrefab);
            EntityManager.SetComponentData(spawnedEntity, new LocalTransform
            {
                Position = new float3(UnityEngine.Random.Range(-3.7f, 3.7f), 5f, 0),
                Rotation = quaternion.identity,
                Scale = 1f
            });

            time = 0f;
        }

    }

}


/*
        SpawnerPrefabConfig spawnCubeAuthoring = SystemAPI.GetSingleton<SpawnerPrefabConfig>();

        for (int i = 0; i < 3f; i++)
        {
            Entity spawnedEntity = EntityManager.Instantiate(spawnCubeAuthoring.EnemyPrefab);
            EntityManager.SetComponentData(spawnedEntity, new LocalTransform {
                Position = new float3(UnityEngine.Random.Range(-3.7f, 3.7f), 3.7f, 0),
                Rotation = quaternion.identity,
                Scale = 1f
            });
        }
*/