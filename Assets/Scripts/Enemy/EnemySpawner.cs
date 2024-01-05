using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private int _count;

    private float _spawnInterval = 2;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds spawnInterval = new WaitForSeconds(_spawnInterval);

        for (int i = _count; i > 0; i--)
        {
            Enemy newEnemy = Instantiate(_template, transform.position, Quaternion.identity);

            yield return spawnInterval;
        }
    }
}
