
using UnityEngine;

namespace GameEvents
{
    public class SpawnObjectGameEvent : GameEvent
    {
        [SerializeField] private GameObject toSpawn;
        [SerializeField] private int min = 1;
        [SerializeField] private int max = 1;
        [SerializeField] private bool randomRotation;
        private void Start()
        {
            int spawnCount = Random.Range(min, max + 1);
            for (int i = 0; i < spawnCount; i++)
            {
                Quaternion rotation = transform.rotation;
                if (randomRotation)
                {
                    rotation = Quaternion.Euler(0f, Random.Range(0, 359), 0f);
                }
                Instantiate(toSpawn, transform.position, rotation);
            }
            
            Destroy(gameObject);
        }
    }
}