using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static PauseMenu current;

    [SerializeField] GameObject PauseUI; 
    public bool pausado = false;
	public float mytime;

    void Awake()
    {
        if(current != null)
        {
            Debug.LogWarning("Mais de uma instancia de PauseMenu!!");
            return;
        }
        current = this;
    }

    void Start()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 2f;
		mytime = Time.timeScale;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausado = !pausado;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !pausado)
        {
            Time.timeScale = mytime;
        }

        if (pausado)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseUI.SetActive(false);
        }
    }

    public void Resume()
    {
        pausado = false;
        Time.timeScale = mytime;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = mytime;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
