
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;

public class PyramidEntity : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject block;
    [SerializeField] GameObject gameObjectPrefab;
    [SerializeField] int maxLayer = 1;
    Entity entityPrefab;
    World defaultWorld;
    EntityManager entityManager;
    float x_offset = 0;
    float z_offset = 0;
    float y_offset = 0;
    [SerializeField] public bool isStart = false;
    public static PyramidEntity Instance { get; private set; } // static singleton
    public bool isEntity = true;
    void Start()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
        defaultWorld = World.DefaultGameObjectInjectionWorld;
        entityManager = defaultWorld.EntityManager;
        entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(block, GameObjectConversionSettings.FromWorld(defaultWorld, null));
        InstantiatePyramid(entityPrefab);
    }
    public void EnableMoving()
    {
        isStart = true;
    }
    void InstantiateEntity(Entity entityPrefab, float3 position)
    {
        Entity entity = entityManager.Instantiate(entityPrefab);
        entityManager.SetComponentData(entity, new Translation { Value = position });
        entityManager.SetComponentData(entity, new PyramidComponent
        {
            speedX = UnityEngine.Random.Range(-3f, 3f),
            speedY = UnityEngine.Random.Range(1f, 3f),
            speedZ = UnityEngine.Random.Range(1f, 3f),
            index = GameManager.ObjectsCount
        });

    }
    void InstantiateGameObject(GameObject gameObjectPrefab, float3 position)
    {
        GameObject gameObject = Instantiate(gameObjectPrefab, position, Quaternion.identity);
        gameObject.GetComponent<GameObjectComponent>().speedX = UnityEngine.Random.Range(-3f, 3f);
        gameObject.GetComponent<GameObjectComponent>().speedY = UnityEngine.Random.Range(1f, 3f);
        gameObject.GetComponent<GameObjectComponent>().speedZ = UnityEngine.Random.Range(1f, 3f);
        gameObject.GetComponent<GameObjectComponent>().index = GameManager.ObjectsCount;
    }
    void InstantiatePyramid(Entity entityPrefab)
    {
        for (int layer = 1; layer <= maxLayer; layer++)
        {
            for (int quantity = 0; quantity < layer * layer; quantity++)
            {
                if (quantity == 0)
                {
                    z_offset = -0.5f * (layer - 1);
                }
                else if (quantity % layer == 0 && quantity != 0)
                {
                    z_offset = z_offset + 1;
                }

                x_offset = -0.5f * (layer - 1) + (1 * (quantity % layer));
                if (layer == 0)
                    y_offset = 0;
                else
                    y_offset = -1 * layer + 1;
                if (isEntity)
                {
                    InstantiateEntity(entityPrefab, new float3(x_offset, y_offset, z_offset));
                }
                else
                {
                    InstantiateGameObject(gameObjectPrefab, new float3(x_offset, y_offset, z_offset));
                }
                GameManager.ObjectsCount++;
            }
        }
    }
}
