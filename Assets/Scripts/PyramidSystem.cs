using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public partial class CreateSystem : SystemBase
{
    float accelerateValue = 1;
    protected override void OnUpdate()
    {
        if(PyramidEntity.Instance.isStart!=true)
            return;
        float deltaTime = Time.DeltaTime;
        float NextWiderIndex = (float)Time.ElapsedTime + accelerateValue;
        double elapsedTime = Time.ElapsedTime;
        // Debug.Log("currentTime="+currentTime);
        Entities.ForEach((ref Translation trans, ref PyramidComponent pyramidComponent) =>
        {
            if (pyramidComponent.index < NextWiderIndex)
            {
                trans.Value.x = trans.Value.x + pyramidComponent.speedX * deltaTime;
                trans.Value.y = trans.Value.y + pyramidComponent.speedY * deltaTime;
                trans.Value.z = trans.Value.z + pyramidComponent.speedZ * deltaTime;
            }
        }).Schedule();
        accelerateValue = accelerateValue + 100;
    }
}
