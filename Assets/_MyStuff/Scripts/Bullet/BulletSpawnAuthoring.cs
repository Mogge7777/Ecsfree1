using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class BulletSpawnAuthoring : MonoBehaviour
{
    public float spawningRate;
    public float2 position;
    public GameObject bullet;

    public class Baker : Baker<BulletSpawnAuthoring>
    {
        public override void Bake(BulletSpawnAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);

            AddComponent(entity, new BulletSpawnComponent
            {
                spawnRate = authoring.spawningRate,
                spawnPosition = authoring.position,
                bulletPrefab = GetEntity(authoring.bullet, TransformUsageFlags.Dynamic)
            });
        }
    }
}
