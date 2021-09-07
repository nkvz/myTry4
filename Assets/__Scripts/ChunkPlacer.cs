using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Transform POI;
    public Chunk[] ChunkPrefabs;
    public Chunk FirstChunk;

    private List<Chunk> spawnChunks = new List<Chunk>();

    private void Start()
    {
        spawnChunks.Add(FirstChunk);
    }

    private void Update()
    {
        if (POI.position.x > spawnChunks[spawnChunks.Count - 1].End.position.x - 20)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        
        Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        newChunk.transform.position = spawnChunks[spawnChunks.Count-1].End.position - newChunk.Begin.localPosition;
        newChunk.transform.position += new Vector3(0, 20, 0);
        spawnChunks.Add(newChunk);

        if(spawnChunks.Count >= 4)
        {
            Destroy(spawnChunks[1].gameObject);
            spawnChunks.RemoveAt(1);
            //first chunk not delited....
        }
        
    }





}
