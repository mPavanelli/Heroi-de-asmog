using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour {

    [SerializeField] string nomeFase = "Level1";
    [SerializeField] string creditos = "Creditos";

    public void ClickStart()
    {
        SceneManager.LoadScene(nomeFase);
    }

    public void ClickCreditos()
    {
        SceneManager.LoadScene(creditos);
    }

    public void ClickQuit()
    {
        Application.Quit();
    }
    
}
