using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

public partial class BulletSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        var thisEntity = new EntityCommandBuffer(Allocator.Temp);
        foreach (var (localTransform, bulletMoveSpeed, entity) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<BulletMoveSpeed>>().WithEntityAccess())
        {
            localTransform.ValueRW.Position.y += bulletMoveSpeed.ValueRO.Value * deltaTime;

            if (localTransform.ValueRO.Position.y > 6f) 
            {
                thisEntity.DestroyEntity(entity);
            }
        }
        thisEntity.Playback(EntityManager);
        thisEntity.Dispose();
    }
}
