using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolsManager : MonoBehaviour
{
    public List<GameObject> poolingObjects;
    [SerializeField]
    private List<GameObject> pooledObjects = new List<GameObject>();

    public static PoolsManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject Spawn(string name)
    {
        return Spawn(name, Vector3.zero, Quaternion.identity);
    }
    public GameObject Spawn(string name, Vector3 position, Quaternion rotation)
    {
        var pooledObject = SpawnFromPooled(name);
        if(pooledObject == null)
        {
            pooledObject = SpawnFromPoolingObjects(name);
        }
        pooledObject.transform.position = position;
        pooledObject.transform.rotation = rotation;
        pooledObject.gameObject.SetActive(true);
        return pooledObject;
    }

    public void Despawn(GameObject item)
    {
        item.SetActive(false);
        pooledObjects.Add(item);
    }

    public void DelayDespawn(GameObject item,float second)
    {
        StartCoroutine(DespawnDelayCoroutine(item, second));
    }
    private IEnumerator DespawnDelayCoroutine(GameObject item, float delay)
    {
        yield return new WaitForSeconds(delay);
        Despawn(item);
    }
    private GameObject SpawnFromPooled(string name)
    {
        return pooledObjects.Find(itm => itm.name == name);
    }

    private GameObject SpawnFromPoolingObjects(string name)
    {
        var item = poolingObjects.Find(itm=>itm.name == name);
        if(item == null)
        {
            throw new KeyNotFoundException($"Given prefab {name} is not in pooling object");
        }
        var newSpawnedObject = Instantiate(item);
        newSpawnedObject.name = item.name;
        return newSpawnedObject;
    }
}
