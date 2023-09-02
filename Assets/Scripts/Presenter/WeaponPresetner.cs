public class WeaponPresenter
{
    private PlayerView _playerView;
    private Weapon _weapon;
    private WeaponModel _weaponModel;

    public WeaponPresenter(PlayerView playerView, Weapon weapon, WeaponModel weaponModel)
    {
        _playerView = playerView;
        _weapon = weapon;
        _weaponModel = weaponModel;
    }

    public void Enable()
    {
        _weapon.Initialized += OnWeaponInit;
        _weapon.TryFired += OnTryFired;
        _weapon.Reloaded += OnReoladed;

        _weaponModel.DataSet += OnWeaponDataSet;
        _weaponModel.Fired += OnShoot;
        _weaponModel.Reload += OnReload;
    }

    public void Disable()
    {
        _weapon.Initialized -= OnWeaponInit;
        _weapon.TryFired -= OnTryFired;
        _weapon.Reloaded -= OnReoladed;

        _weaponModel.DataSet -= OnWeaponDataSet;
        _weaponModel.Fired -= OnShoot;
        _weaponModel.Reload -= OnReload;
    }

    private void OnWeaponInit(float clips, float bulletInClips)
    {
        _weaponModel.SetData(clips, bulletInClips);
    }
    
    private void OnWeaponDataSet(float clips, float bulletInClips)
    {
        _playerView.SetWeaponData(clips, bulletInClips);
    }
    
    private void OnTryFired(float bulletInClips)
    {
        _weaponModel.TryShoot(bulletInClips);
    }

    private void OnShoot(float bulletInClips)
    {
        _weapon.Shoot(bulletInClips);
        _playerView.ChangeBulletInClip(bulletInClips);
    }

    private void OnReload()
    {
        _weapon.StartReload();
    }

    private void OnReoladed(float bulletInClips)
    {
        _playerView.ChangeBulletInClip(bulletInClips);
    }    
}
