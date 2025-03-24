using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    public static MenuController Instance;

    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject loseMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseMenuFirstSelected;
    [SerializeField] GameObject winMenuFirstSelected;
    [SerializeField] GameObject loseMenuFirstSelected;
    [SerializeField] GameObject startMenuFirstSelected;
    //[SerializeField] GameObject closedMenuUnSelected;
    public bool pausedGame;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        if(loseMenu != null) {
            loseMenu.SetActive(false);
        }
        if (winMenu != null) { 
            winMenu.SetActive(false);
        }
        if (pauseMenu != null) { 
            pauseMenu.SetActive(false);
            pausedGame = pauseMenu.activeSelf;
        }
    }

    public void ShowHidePauseMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PauseGame();
        }
    }

    public void LoadLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    public void ReloadScene()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }
    public void PauseGame()
    {
        pausedGame = !pausedGame;
        //clear selected options
        EventSystem.current.SetSelectedGameObject(null);
        if (pausedGame)
        {
            EventSystem.current.SetSelectedGameObject(pauseMenuFirstSelected);
        }
        //pause and unpause the pause menu
        pauseMenu.SetActive(pausedGame);
    }
    public void WinGame()
    {
        pausedGame = true;
        winMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(winMenuFirstSelected);
    }
    public void LoseGame()
    {
        pausedGame = true;
        loseMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(loseMenuFirstSelected);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
