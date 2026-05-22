using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnerActivator : MonoBehaviour
{
    [SerializeField] private List<Spawner> _spawners;
    [SerializeField] private float _cooldown = 2f;

    private void Start()
    {
        StartCoroutine(Active());
    }

    public IEnumerator Active()
    {
        while (true)
        {
            int randomValueSpawner = Random.Range(0, _spawners.Count);

            _spawners[randomValueSpawner].Spawn();

            yield return new WaitForSeconds(_cooldown);
        }
    }
}