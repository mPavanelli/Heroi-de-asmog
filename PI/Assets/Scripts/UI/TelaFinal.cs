using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TelaFinal : MonoBehaviour
{

    [SerializeField] Text textoTempo, textoNota;
    [SerializeField] Image imagemEstrela;
    [SerializeField] string proximaFase;
    [SerializeField] float[] limitesDeTempo;
    [SerializeField] Sprite[] spritesEstrelas; 
    float tempoFinal;

    // Update is called once per frame
    void Update()
    {
        tempoFinal = Cronometro.current.Tempo;

        if (tempoFinal <= limitesDeTempo[0])
        {
            imagemEstrela.overrideSprite = spritesEstrelas[0];
        }
        else if (tempoFinal > limitesDeTempo[0] && tempoFinal <= limitesDeTempo[1])
        {
            imagemEstrela.overrideSprite = spritesEstrelas[1];
        }
        else if (tempoFinal > limitesDeTempo[1])
        {
            imagemEstrela.overrideSprite = spritesEstrelas[2];
        }

    }

    void LateUpdate()
    {
        textoTempo.text = Cronometro.current.Tempo.ToString("0.00");
    }

    public void ProximaFase()
    {
        SceneManager.LoadScene(proximaFase);
    }

    public void RecomecaFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


