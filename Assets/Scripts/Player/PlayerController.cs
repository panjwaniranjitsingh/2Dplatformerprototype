using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MyPlayer _myPlayer;
    const string GROUND = "Ground";
    [SerializeField] private CameraController _cameraController;
    private bool _isAlive;
    private void Start()
    {
        IInput input = new InputHandler();
        IMovement movement = new PlayerMovement(transform);
        _myPlayer = new MyPlayer(input, movement);
        _isAlive = true;
    }

    private void Update()
    {
        if (_isAlive)
        {
            _myPlayer.Update();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(GROUND))
        {
            _myPlayer.SetOnGround(true);
        }
        if (other.gameObject.GetComponent<CameraTrigger>())
        {
            _cameraController.SetCameraPosition(other.gameObject.transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(GROUND))
        {
            _myPlayer.SetOnGround(false);
        }
    }
    
    public void CoinCollected()
    {
        GameManager.GetInstance().IncreaseScore();
    }

    public void LevelComplete()
    {
        GameManager.GetInstance().ShowMessage("Level Complete");
        _isAlive = false;
    }

    public void PlayerDied()
    {
        GameManager.GetInstance().ShowMessage("You died");
        _isAlive = false;
    }
}