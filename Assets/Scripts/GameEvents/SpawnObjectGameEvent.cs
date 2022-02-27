
using UnityEngine;

namespace GameEvents
{
    public class SpawnObjectGameEvent : GameEvent
    {
        [SerializeField] private GameObject toSpawn;
        [SerializeField] private int min = 1;
        [SerializeField] private int max = 1;
        private void Start()
        {
            int spawnCount = Random.Range(min, max + 1);
            for (int i = 0; i < spawnCount; i++)
            {
                Instantiate(toSpawn, transform);
            }
        }
    }
}