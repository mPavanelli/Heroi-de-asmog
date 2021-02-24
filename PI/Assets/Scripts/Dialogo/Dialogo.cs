using UnityEngine;

[System.Serializable]
public class Dialogo {

	public Sprite rosto;

	public string nome;

    public Transform novoAlvo;

    public bool trocaDeAlvo = false;

    public float velocidadeCamera;

	[TextArea(3,10)]
	public string[] frases;
}
