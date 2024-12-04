using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Optimization.Baseline
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Spawner[] spawnerPrefabs;

        [SerializeField, Min(0)] private float minShootTime;
        [SerializeField, Min(0)] private float maxShootTime;
        [SerializeField, Min(0)] private float minForceModifier;
        [SerializeField, Min(0)] private float maxForceModifier;
        [SerializeField, Range(0, 90)] private float deviationDegrees;

        [SerializeField, Min(1)] private int minProjectiles;
        [SerializeField, Min(1)] private int maxProjectiles;

        [SerializeField] private Transform shootingPoint;

        private float _currentTime;
        void Awake()
        {
            ResetSpawner();
        }
        void Update()
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime < 0)
            {
                Shoot();
            }
        }
        void Shoot()
        {
            int n = Random.Range(minProjectiles, maxProjectiles);
            for (int i = 0; i < n; i++)
            {
                //Spawner s = SpawnerPool.Instance.AddToPool(spawnerPrefabs[Random.Range(0, spawnerPrefabs.Length)], shootingPoint.position, shootingPoint.rotation);
                float forceModifier = Random.Range(minForceModifier, maxForceModifier);
                float xDeviation = Random.Range(-deviationDegrees, deviationDegrees);
                float yDeviation = Random.Range(-deviationDegrees, deviationDegrees);

                Vector3 direction = Quaternion.AngleAxis(yDeviation, Vector3.right) * (Quaternion.AngleAxis(xDeviation, Vector3.up) * shootingPoint.forward);

                //s.Launch(direction * forceModifier);
            }


            ResetSpawner();
        }

        void ResetSpawner()
        {
            _currentTime = Random.Range(minShootTime, maxShootTime);
        }
    }
}
