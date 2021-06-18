using System.Collections;
using System.Collections.Generic;
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
        startButton.onClick.AddListener(() => SceneManager.LoadScene(""));
        exitButton.onClick.AddListener(() => Application.Quit(0));
    }
}
