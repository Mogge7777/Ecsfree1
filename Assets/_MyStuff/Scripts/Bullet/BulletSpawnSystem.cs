using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class BulletSpawnSystem : SystemBase
{
    public float time;
    public float spawnTime = 1f;

    protected override void OnCreate()
    {
        time = spawnTime - 0.4f;
    }
    
    protected override void OnUpdate()
    {
        BulletSpawnComponent bulletSpawnComponent = SystemAPI.GetSingleton<BulletSpawnComponent>();

        time += SystemAPI.Time.DeltaTime;
        if (!SystemAPI.HasSingleton<BulletSpawnComponent>())
        {
            Debug.LogError("BulletSpawnComponent singleton is missing!");
            return;
        }

        if (time > spawnTime)
        {
            float3 playerPosition = float3.zero;
            
            foreach (var transform in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<PlayerTag>())
            {
                playerPosition = transform.ValueRO.Position;

                Entity spawnedEntity = EntityManager.Instantiate(bulletSpawnComponent.bulletPrefab);

                EntityManager.SetComponentData(spawnedEntity, new LocalTransform
                {
                    Position = new float3(playerPosition.x, playerPosition.y, 0),
                    Rotation = quaternion.identity,
                    Scale = 0.2f
                });
            }
            time = 0;
        }
    }
}
