using UnityEngine;

public class InputHandler : IInput
{
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";

    public Vector2 MyInput()
    {
        Vector2 direction;
        direction.x = Input.GetAxis(HORIZONTAL);
        direction.y = Input.GetAxis(VERTICAL);
        return direction;
    }
}