using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenController : MonoBehaviour
{
    [SerializeField]
    Button startButton;

    [SerializeField]
    Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(() => SceneManager.LoadScene(1));
        exitButton.onClick.AddListener(() => gameObject.AddComponent<ExitGameComponent>());
    }
}
