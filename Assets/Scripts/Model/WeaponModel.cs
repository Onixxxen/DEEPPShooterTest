using System;

public class WeaponModel
{
    private float _clips;
    private float _bulletInClips;

    public event Action<float, float> DataSet;
    public event Action<float> Fired;
    public event Action Reload;

    public void SetData(float clips, float bulletInClips)
    {
        _clips = clips;
        _bulletInClips = bulletInClips;

        DataSet?.Invoke(_clips, _bulletInClips);
    }

    public void TryShoot(float bulletInClips)
    {
        _bulletInClips = bulletInClips;

        if (_bulletInClips > 0)
            Shoot();
        else
            Reload?.Invoke();
    }

    private void Shoot()
    {
        _bulletInClips--;
        Fired?.Invoke(_bulletInClips);
    }
}
