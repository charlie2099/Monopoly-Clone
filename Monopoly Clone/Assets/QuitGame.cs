using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    [SerializeField] private Button quitGameButton;
    
    private void OnEnable() => quitGameButton.onClick.AddListener(Quit);
    private void OnDisable() => quitGameButton.onClick.RemoveListener(Quit);

    private void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
