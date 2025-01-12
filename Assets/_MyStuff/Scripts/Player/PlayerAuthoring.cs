using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Unity.Transforms;

public class PlayerAuthoring : MonoBehaviour
{
    public float  moveSpeed;

    class PlayerAuthoringBaker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            Entity playerEntity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent<PlayerTag>(playerEntity);
            AddComponent(playerEntity, new MoveSpeed { Value = authoring.moveSpeed });
            AddComponent(playerEntity, new LocalTransform { Position = new float3(0, 0, 0) });
        }
    }



    }
public struct MoveSpeed : IComponentData
{
    public float Value;
}

//Regular built-in Translation was missing a assembly reference for some reason..
public struct Translation2D : IComponentData
{
    public float2 Value;
}
public struct PlayerTag : IComponentData { }
