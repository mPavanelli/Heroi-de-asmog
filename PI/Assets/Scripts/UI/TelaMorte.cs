using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TelaMorte : MonoBehaviour {

    public string texto;
    [SerializeField] Text textoMorte;

    public static TelaMorte current;

    void Awake()
    {
        if(current != null)
        {
            Debug.LogWarning("Mais de uma instância de TelaMorte!");
            return;
        }
        current = this;
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if(texto != null)
            textoMorte.text = texto;
    }

    public void RecomecaFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
