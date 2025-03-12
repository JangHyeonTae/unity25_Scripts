using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager instance;

    [Header("Elements")]
    [SerializeField] private LevelSO[] levels;
    private GameObject finishline;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        GenerateLevel();

        finishline = GameObject.FindWithTag("Finish");
    }

    void Update()
    {

    }

    private void GenerateLevel()
    {
        int currentLevel = GetLevel();
        currentLevel = currentLevel % levels.Length;

        LevelSO level = levels[currentLevel];

        CreateLevel(level.chunks);
    }

    private void CreateLevel(Chunk[] levelChunks)
    {
        Vector3 chunkPosition = Vector3.zero;

        for (int i = 0; i < levelChunks.Length; i++)
        {
            Chunk chunkToCreate = levelChunks[i];

            if (i > 0)
            {
                chunkPosition.z += chunkToCreate.GetLength() / 2;
            }

            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);

            chunkPosition.z += chunkInstance.GetLength() / 2;
        }
    }

    #region chunk무작위생성


    //private void CreateRandomLevel()
    //{
    //    Vector3 chunkPosition = Vector3.zero;

    //    for (int i = 0; i < 5; i++)
    //    {
    //        Chunk chunkToCreate = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];

    //        if (i > 0)
    //        {
    //            chunkPosition.z += chunkToCreate.GetLength() / 2;
    //        }

    //        Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);

    //        chunkPosition.z += chunkInstance.GetLength() / 2;
    //    }
    //}
    #endregion

    public float GetFinishZ()
    {
        return finishline.transform.position.z;
    }

    public int GetLevel()
    {
        return PlayerPrefs.GetInt("level", 0);
    }
}
