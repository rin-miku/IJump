using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviourPun
{
    // 生成平台
    public List<GameObject> platforms = new List<GameObject>();
    public float spawnTime;

    private float countTime;
    private Vector3 spawnPosition;
    private bool hasSpikes;
    private int spikesCount;

    // Start is called before the first frame update
    void Start()
    {
       
    }

 

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
        if (Time.timeSinceLevelLoad  < 30f)
            spawnTime = 2;
        else if (Time.timeSinceLevelLoad < 60f)
            spawnTime = 1.75f;
        else if (Time.timeSinceLevelLoad  < 90f)
            spawnTime = 1.5f;
        else if (Time.timeSinceLevelLoad < 120f)
            spawnTime = 1.25f;
        else
            spawnTime = 1f;
    }

    public void SpawnPlatforms()
    {
        countTime += Time.deltaTime;
        spawnPosition = transform.position;
        spawnPosition.x = Random.Range(-3.5f, 3.5f);

        if(countTime >= spawnTime)
        {
            CreatePlatforms();
            countTime = 0;
        }
    }

    public void CreatePlatforms()
    {
        int index = Random.Range(0, platforms.Count);

        if(hasSpikes)
        {
            if (index == 12)
                index = 0;
            spikesCount--;
        }
        if(spikesCount == 0)
        {
            spikesCount = 4;
            hasSpikes = false;
        }
        if(index == 12 && !hasSpikes)
        {
            hasSpikes = true;
        }

        Instantiate(platforms[index], spawnPosition, Quaternion.identity, transform);
        //PhotonNetwork.Instantiate(platforms[index].name, spawnPosition, Quaternion.identity, 0);
    }
}
