using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Unity.Transforms;

public class EnemyAuthoring : MonoBehaviour
{
    public float moveSpeed = 2f;
    class EnemyAuthoringBaker : Baker<EnemyAuthoring>
    {
        public override void Bake(EnemyAuthoring authoring)
        {
            Entity EnemyEntity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(EnemyEntity, new LocalTransform { Position = new float3(0, 0, 0) });
            AddComponent(EnemyEntity, new EnemyMoveSpeed { Value = authoring.moveSpeed});
        }
    }
}
public struct EnemyMoveSpeed : IComponentData
{
    public float Value;
}

