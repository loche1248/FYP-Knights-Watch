//Reference - https://www.youtube.com/watch?v=hk6cUanSfXQ
//Reference - https://www.youtube.com/watch?v=XNQQLr0E9TY
//Reference - https://www.youtube.com/watch?v=G9Wa0XZ2a2o
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] objects;

    private void Start()
    {
        int rand = Random.Range(0, objects.Length);
        GameObject instance = (GameObject)Instantiate(objects[rand], transform.position, Quaternion.identity);
        instance.transform.parent = transform;
    }
}
