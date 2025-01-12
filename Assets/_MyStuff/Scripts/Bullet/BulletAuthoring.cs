using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Unity.Transforms;

public class BulletAuthoring : MonoBehaviour
{
    class BulletAuthoringBaker : Baker<BulletAuthoring>
    {
        public override void Bake(BulletAuthoring authoring)
        {
            Entity BulletEntity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(BulletEntity, new LocalTransform { Position = new float3(0, 0, 0) });
            AddComponent(BulletEntity, new BulletMoveSpeed
            {
                Value = 5f
            });
        }
    }

}
public struct BulletMoveSpeed : IComponentData
{
    public float Value;
}
