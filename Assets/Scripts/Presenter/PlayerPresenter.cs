public class PlayerPresetner
{
    private PlayerView _playerView;
    private TargetPool _targetPool;
    private PlayerModel _playerModel;

    public PlayerPresetner(PlayerView playerView, PlayerModel playerModel, TargetPool targetPool)
    {
        _playerView = playerView;
        _playerModel = playerModel;
        _targetPool = targetPool;
    }

    public void Enable()
    {
        _playerView.Initialize += OnPlayerInit;

        _playerModel.TransferredHealth += OnTransferredHealth;
        _playerModel.ChangedHealth += OnChangedHealth;

        _targetPool.Hit += OnHit;
    }

    public void Disable()
    {
        _playerView.Initialize -= OnPlayerInit;

        _playerModel.TransferredHealth -= OnTransferredHealth;
        _playerModel.ChangedHealth -= OnChangedHealth;

        _targetPool.Hit -= OnHit;
    }

    private void OnPlayerInit()
    {
        _playerModel.GetHealth();
    }

    private void OnTransferredHealth(float health)
    {
        _playerView.SetHealthData(health);
    }

    private void OnHit(float changeHealth, bool isAddHealth)
    {
        _playerModel.ChangeHealth(changeHealth, isAddHealth);
    }

    private void OnChangedHealth(float newHealth)
    {
        _playerView.ChangeHealth(newHealth);
    }
}
