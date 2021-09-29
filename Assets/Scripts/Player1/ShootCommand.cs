public class ShootCommand : Command1
{

    PlayerShooting1 playerShooting;

    public ShootCommand(PlayerShooting1 _playerShooting)
    {
        playerShooting = _playerShooting;
    }

    public override void Execute()
    {

        playerShooting.shoot();
    }

    public override void UnExecute()
    {

    }
}