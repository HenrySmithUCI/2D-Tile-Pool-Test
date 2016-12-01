using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

  public GameObject pooledObject;
  public int pooledAmmount = 20;
  public bool willGrow = true;

  private List<GameObject> pooledObjects;

  void Start() {
    pooledObjects = new List<GameObject>();
    for (int i = 0; i < pooledAmmount; i++) {
      makeNewObject();
    }
  }

  public GameObject GetPooledObject() {
    for(int i = 0; i < pooledObjects.Count; i++) {
      if (pooledObjects[i].activeInHierarchy == false) {
        return pooledObjects[i];
      }
    }

    if (willGrow) {
      return makeNewObject();
    }

    return null;
  }

  GameObject makeNewObject() {
    GameObject obj = (GameObject)Instantiate(pooledObject);
    obj.SetActive(false);
    obj.transform.parent = transform;
    pooledObjects.Add(obj);
    return obj;
  }
}
