using UnityEngine;

public class PositiveTarget : Target
{
    [SerializeField] private float _addHealth;

    public override void TakeHit()
    {
        TryHit(_addHealth, true);
        gameObject.SetActive(false);
    }
}
