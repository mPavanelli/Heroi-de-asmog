using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerDialogo : MonoBehaviour
{

    #region Singleton
    public static ManagerDialogo current;

    private void Awake()
    {
        if (current != null)
        {
            Debug.LogWarning("Mais de uma instancia de ManagerDialogo!!");
            return;
        }
        current = this;
    }
    #endregion

    public Image imagemRosto;
    public Text textoDialogo;
    public Text nome;
    public Animator animator;
    public List<TriggerDialogo> dialogos;
    public bool emDialogo = false;
    Queue<string> frases;
    Personagem player;
    Humano humano;

    // Use this for initialization
    void Start()
    {
        frases = new Queue<string>();
        humano = FindObjectOfType<Humano>();
        animator.SetBool("EstaAberto", false);
    }

    public void ComecaDialogo(Dialogo dialogo)
    {
        //Debug.Log("Iniciando Dialogo");
        emDialogo = true;
        Cronometro.current.Tempo = Time.timeSinceLevelLoad / 2f;
        Cronometro.current.enabled = false;
        if (humano != null)
        {
            humano.enabled = false;
        }
        animator.SetBool("EstaAberto", true);
        imagemRosto.sprite = dialogo.rosto;
        nome.text = dialogo.nome;
        frases.Clear();
        if (dialogo.trocaDeAlvo)
        {
            ControleDaCamera.current.TrocaAlvo(dialogo.novoAlvo);
            ControleDaCamera.current.velocidadeDaCamera = dialogo.velocidadeCamera;
        }
        foreach (string frase in dialogo.frases)
        {
            frases.Enqueue(frase);
        }

        ProximaFrase();
    }

    public void ProximaFrase()
    {
        if (frases.Count == 0)
        {
            TerminaDialogo();
            return;
        }

        string frase = frases.Dequeue();
        StopAllCoroutines();
        StartCoroutine(EscreveDialogo(frase));
    }

    IEnumerator EscreveDialogo(string frase)
    {
        textoDialogo.text = "";
        foreach (char letra in frase.ToCharArray())
        {
            textoDialogo.text += letra;
            yield return null;
        }
    }

    public void TerminaDialogo()
    {
        //Debug.Log("Terminando Dialogo");
        ControleDaCamera.current.VoltaAlvo();
        Cronometro.current.enabled = true;
        if (humano != null)
        {
            humano.enabled = true;
        }
        emDialogo = false;
        animator.SetBool("EstaAberto", false);
    }
}