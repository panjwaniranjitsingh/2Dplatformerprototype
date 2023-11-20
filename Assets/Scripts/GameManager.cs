using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : GenericSingleton<GameManager>
{
    private int _score;
    [SerializeField] private Transform _messageView;
    [SerializeField] private Text _messageText;
    [SerializeField] private Text _scoreText;
    private void Start()
    {
        _messageView.gameObject.SetActive(false);
        _score = 0;
        ShowScore();
    }

    private void ShowScore()
    {
        _scoreText.text = "Score : " + _score;
    }

    public void ShowMessage(string message)
    {
        _messageText.text = message;
        _messageView.gameObject.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncreaseScore()
    {
        _score++;
        ShowScore();
    }
}