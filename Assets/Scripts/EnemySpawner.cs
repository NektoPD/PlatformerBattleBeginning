using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private int _count;
    [SerializeField] private Transform _path;

    private float _spawnInterval = 2;
    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        _spawnCoroutine = StartCoroutine(Spawn());
    }

    private void Update()
    {
        if(_count < 0)
        {
            StopCoroutine(_spawnCoroutine);
        }
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds spawnInterval = new WaitForSeconds(_spawnInterval);

        while( _count > 0 )
        {
            Enemy newEnemy = Instantiate(_template, transform.position, Quaternion.identity);
            newEnemy.SetTarget(_path);
            _count--;

            yield return spawnInterval;
        }
    }
}
