using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : TargetPool
{
    [SerializeField] private List<Target> _targets = new List<Target>();
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapsedTime;

    public List<Target> Targets => _targets;

    private void Start()
    {
        for (int i = 0; i < _targets.Count; i++)
            Initialize(_targets[i]);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out Target target))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetTarget(target, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetTarget(Target target, Vector3 spawnPoint)
    {
        target.ActivateTarget(spawnPoint);
    }
}
