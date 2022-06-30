using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsSpawn : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    public bool hasFruit;
    private Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        hasFruit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Fruit") == null)
        {
            hasFruit = false;
        }
        else
        {
            hasFruit= true;
        }
        SpawnFruits();
    }
    public void SpawnFruits()
    {
        if(!hasFruit)
        {
            int index = Random.Range(0, platforms.Count);
            float x = Random.Range(-4f, 4f);
            float y = Random.Range(-2.5f, 7.5f);
            spawnPosition = new Vector3(x, y, 0);
            Instantiate(platforms[index], spawnPosition, Quaternion.identity, transform);
        }
    }
}
