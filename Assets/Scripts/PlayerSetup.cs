using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private TargetPool _targetPool;
    [SerializeField] private Weapon _weapon;

    private PlayerPresetner _playerPresetner;
    private WeaponPresenter _weaponPresenter;

    private void OnEnable()
    {
        _playerPresetner.Enable();
        _weaponPresenter.Enable();
    }

    private void OnDisable()
    {
        _playerPresetner.Disable();
        _weaponPresenter.Disable();
    }

    private void Awake()
    {
        PlayerModel playerModel = new PlayerModel();
        WeaponModel weaponModel = new WeaponModel();

        _playerPresetner = new PlayerPresetner(_playerView, playerModel, _targetPool);
        _weaponPresenter = new WeaponPresenter(_playerView, _weapon, weaponModel);
    }
}
