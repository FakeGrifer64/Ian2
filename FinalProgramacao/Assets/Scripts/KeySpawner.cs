using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public GameObject[] keyPrefabs;
    public Transform[] spawnPoints; 

    void Start()
    {
        if (keyPrefabs.Length != 3 || spawnPoints.Length != 6)
        {
            return;
        }

        int[] selectedIndices = GenerateUniqueIndices(3, spawnPoints.Length);

        for (int i = 0; i < keyPrefabs.Length; i++)
        {
            Instantiate(keyPrefabs[i], spawnPoints[selectedIndices[i]].position, Quaternion.identity);
        }
    }

    int[] GenerateUniqueIndices(int count, int maxRange)
    {
        int[] indices = new int[count];
        for (int i = 0; i < count; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, maxRange);
            } while (System.Array.Exists(indices, x => x == randomIndex));

            indices[i] = randomIndex;
        }
        return indices;
    }
}
