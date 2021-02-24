using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ControladorCutscene : MonoBehaviour
{

    [SerializeField] GameObject botaoContinua, botaoPula;
    [SerializeField] VideoPlayer cutscene;
    [SerializeField] string fase1;
    int etapaAtual;

    float puloTempo = 0.5f;

    // Use this for initialization
    void Start()
    {
        botaoContinua.SetActive(false);
        botaoPula.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Ativa botão e fim da cutscene
        if (cutscene.time > 78f)
        {
            SceneManager.LoadScene(fase1);
        }
        if(cutscene.time > 2f)
        {
            botaoPula.SetActive(true);
        }
        if(cutscene.time > 73f)
        {
            botaoPula.SetActive(false);
        }

        // Pausas da cutscene
        if (cutscene.time > 5.5f && cutscene.time < 5.55f && etapaAtual == 0)
        {
            PausaCutscene();
        }
        else if (cutscene.time > 12f && cutscene.time < 12.05f && etapaAtual == 1)
        {
            PausaCutscene();
        }
        else if (cutscene.time > 17f && cutscene.time < 17.05f && etapaAtual == 2)
        {
            PausaCutscene();
        }
        else if (cutscene.time > 21f && cutscene.time < 21.05f && etapaAtual == 3)
        {
            PausaCutscene();
        }
        else if (cutscene.time > 25f && cutscene.time < 25.05f && etapaAtual == 4)
        {
            PausaCutscene();
        }
        else if (cutscene.time > 31f && cutscene.time < 31.05f && etapaAtual == 5)
        {
            PausaCutscene();
        }
        else if (cutscene.time > 38f && cutscene.time < 38.05f && etapaAtual == 6)
        {
            PausaCutscene();
        }
        else if (cutscene.time > 44f && cutscene.time < 44.05f && etapaAtual == 7)
        {
            PausaCutscene();
        }
        else if (cutscene.time > 50f && cutscene.time < 50.05f && etapaAtual == 8)
        {
            PausaCutscene();
        }
        else if (cutscene.time > 56f && cutscene.time < 56.05f && etapaAtual == 9)
        {
            PausaCutscene();
        }
        else if (cutscene.time > 63f && cutscene.time < 63.05f && etapaAtual == 10)
        {
            PausaCutscene();
        }
        else if (cutscene.time > 68f && cutscene.time < 68.05f && etapaAtual == 11)
        {
            PausaCutscene();
        }
    }

    /// <summary>
    /// Método para o botão de continuar
    /// </summary>
    public void ContinuaVideo()
    {
        cutscene.time = cutscene.time + puloTempo;
        cutscene.Play();
        botaoContinua.SetActive(false);
        etapaAtual++;
    }

    /// <summary>
    /// Método para o botao de pular a cutscene
    /// </summary>
    public void PulaCutscene()
    {
        SceneManager.LoadScene(fase1);
    }

    /// <summary>
    /// Método que pausa a cutscene e ativa o botão para continuar
    /// </summary>
    void PausaCutscene()
    {
        cutscene.Pause();
        botaoContinua.SetActive(true);
    }
}
