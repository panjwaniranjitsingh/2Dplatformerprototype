public class MyPlayer 
{
    IInput keyInput;
    IMovement playerMovement;
    public MyPlayer(IInput input, IMovement movement)
    {
        keyInput = input;
        playerMovement = movement;
    }

    public void Update()
    {
        playerMovement.Movement(keyInput.MyInput());
    }

    public void SetOnGround(bool state)
    {
        playerMovement.SetOnGround(state);
    }
}