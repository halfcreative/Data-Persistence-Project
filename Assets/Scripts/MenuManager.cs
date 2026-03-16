using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInputField;

    public void StartGame()
    {
        if (!string.IsNullOrEmpty(playerNameInputField.text))
        {
            GameManager.instance.playerName = playerNameInputField.text;
            SceneManager.LoadScene(1);
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
