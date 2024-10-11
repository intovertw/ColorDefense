using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class retry : MonoBehaviour
{
    public Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(gameStart);
    }

    void gameStart()
    {
        SceneManager.LoadScene("ColorDefense");
    }
}
