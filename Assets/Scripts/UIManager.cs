using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
  public TMP_InputField nameField;

  private DataController dataController;

  public void Start()
  {
    dataController = DataController.Instance;
  }

  public void StartGame()
  {
    dataController.SetPlayerName( nameField.text );
    SceneManager.LoadScene( "main" );
  }

  public static void QuitGame()
  {
#if UNITY_EDITOR
    EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
  }
}

