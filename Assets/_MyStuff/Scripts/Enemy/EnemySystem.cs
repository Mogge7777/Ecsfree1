using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial class EnemySystem : SystemBase
{
    protected override void OnUpdate()
    {
        var thisEntity = new EntityCommandBuffer(Allocator.Temp);
        foreach (var (localTransform, enemyMoveSpeed, entity) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<EnemyMoveSpeed>>().WithEntityAccess())
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            if (localTransform.ValueRO.Position.y < -6f)
            {
                thisEntity.DestroyEntity(entity);
            }
            localTransform.ValueRW.Position.y -= enemyMoveSpeed.ValueRO.Value * deltaTime;
        }
        thisEntity.Playback(EntityManager);
        thisEntity.Dispose();
    }
}
