using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public partial class PlayerMovementSystem : SystemBase
{
    protected override void OnCreate()
    {

    }
    protected override void OnDestroy()
    {

    }
    protected override void OnUpdate()
    {
        //!any key return (?)
        if (Input.GetKey(KeyCode.W)) 
        {

            foreach (var (localTransform, moveSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<MoveSpeed>>())
            {
                if (localTransform.ValueRO.Position.y > 3.5f)
                {
                    return;
                }
                float deltaTime = SystemAPI.Time.DeltaTime;
                localTransform.ValueRW.Position.y += moveSpeed.ValueRO.Value * deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {

            foreach (var (localTransform, moveSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<MoveSpeed>>())
            {
                if (localTransform.ValueRO.Position.y < -3.5f)
                {
                    return;
                }

                float deltaTime = SystemAPI.Time.DeltaTime;
                localTransform.ValueRW.Position.y -= moveSpeed.ValueRO.Value * deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {

            foreach (var (localTransform, moveSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<MoveSpeed>>())
            {
                if (localTransform.ValueRO.Position.x < -3.5f)
                {
                    return;
                }

                float deltaTime = SystemAPI.Time.DeltaTime;
                localTransform.ValueRW.Position.x -= moveSpeed.ValueRO.Value * deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {

            foreach (var (localTransform, moveSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<MoveSpeed>>())
            {
                if (localTransform.ValueRO.Position.x > 3.5f)
                {
                    return;
                }

                float deltaTime = SystemAPI.Time.DeltaTime;
                localTransform.ValueRW.Position.x += moveSpeed.ValueRO.Value * deltaTime;
            }
        }
    }
}
