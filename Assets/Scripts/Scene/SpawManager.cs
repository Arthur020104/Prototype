using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawManager : MonoBehaviour
{
    [SerializeField] private GameObject _previewObject;
    [SerializeField] private GameObject[] _objectsToSpawn;
    [Header("Time Between preview and objects")]
    [SerializeField] private float _time = 0.3f, _spawnXRange = 10f, _spawnYRange = 10f;
    [SerializeField]private float _intervalTesteSpawnEnemy = 0.5f;
    void Start()
    {
        StartCoroutine("SpawnEnemyTeste");
    }
    private IEnumerator SpawnEnemyTeste()
    {
        while(true)
        {
            StartCoroutine(SpawnObject(_objectsToSpawn[Random.Range(0, _objectsToSpawn.Length)], GenerateRandomPos()));
            yield return new WaitForSeconds(_intervalTesteSpawnEnemy);
        }
    }
    private IEnumerator SpawnObject(GameObject obj, Vector2 pos)
    {
        GameObject previewInstance = Instantiate(_previewObject, pos, Quaternion.identity);
        yield return new WaitForSeconds(_time);
        Instantiate(obj, pos, Quaternion.identity);
        Destroy(previewInstance);
    }
    private Vector2 GenerateRandomPos()
    {
        return new Vector2(Random.Range(-_spawnXRange, _spawnXRange), Random.Range(-_spawnYRange, _spawnYRange));
    }
}
