using System;

public class PlayerModel
{
    private float _maxHealth = 100;
    private float _health = 20;

    public event Action<float> TransferredHealth;
    public event Action<float> ChangedHealth;

    public void GetHealth()
    {
        TransferredHealth?.Invoke(_health);
    }

    public void ChangeHealth(float changeHealth, bool isAddHealth)
    {
        if (isAddHealth)
            if ((_health + changeHealth) <= _maxHealth)
                _health += changeHealth;

        if (!isAddHealth)
            if ((_health - changeHealth) >= 0)
                _health -= changeHealth;

        ChangedHealth?.Invoke(_health);
    }
}
