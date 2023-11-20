using UnityEngine;
public class PlayerMovement : IMovement
{
    private float _moveSpeed = 1000f;
    private float _jumpForce = 400f;
    private Transform _playerTransform;
    private Rigidbody2D _rigidbody2D;
    private bool _onGround;
    public PlayerMovement(Transform transform)
    {
        _playerTransform = transform;
        _rigidbody2D = _playerTransform.GetComponent<Rigidbody2D>();
    }

    public void Movement(Vector2 direction)
    {
        
        Vector3 scale = _playerTransform.localScale;

        if (direction.x < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (direction.x > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        _playerTransform.localScale = scale;
        
        //Move player horizontally
        // Vector3 position = _playerTransform.position;
        // position.x += direction.x * _moveSpeed * Time.deltaTime;
        // _playerTransform.position = position;
        
        _rigidbody2D.velocity = new Vector2(direction.x * _moveSpeed * Time.deltaTime, _rigidbody2D.velocity.y);
        
        //Debug.Log("Direction="+direction +",onground="+_onGround);
        //Move player vertically
        if (direction.y > 0 && _onGround)
        {
            _onGround = false;
            _rigidbody2D.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Force);
        }
    }

    public void SetOnGround(bool state)
    {
        _onGround = state;
    }
}