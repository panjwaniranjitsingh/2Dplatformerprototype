using UnityEngine;

public interface IMovement
{
    public void Movement(Vector2 direction);
    public void SetOnGround(bool state);
}