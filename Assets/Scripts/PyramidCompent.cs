
using Unity.Entities;
[GenerateAuthoringComponent]
public struct PyramidComponent : IComponentData
{
    public float speedX;
    public float speedY;
    public float speedZ;
    public int index;
}
