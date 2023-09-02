using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    private List<Target> _pool = new List<Target>();

    public event Action<float, bool> Hit;

    public void Initialize(Target prefab)
    {
        var spawned = Instantiate(prefab, _container.transform);

        spawned.Hit += HitRequest;

        _pool.Add(spawned);
        spawned.gameObject.SetActive(false);
    }

    public bool TryGetObject(out Target result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);
        return result != null;
    }

    private void HitRequest(float changeHealth, bool isAddHealth)
    {
        Hit?.Invoke(changeHealth, isAddHealth);
    }
}
