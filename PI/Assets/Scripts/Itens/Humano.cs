using UnityEngine;

public class Humano : Item
{

	float tempoAtual;
	[SerializeField] float tempoAteCair = 5f;
	Rigidbody2D rb2D;
	public int indice = 0;
	public float TempoAtual
	{
		get { return tempoAtual;}
	}
	public float TempoAteCair
	{
		get { return tempoAteCair; }
	}

	[SerializeField] Transform groundCheck;
	[SerializeField]LayerMask layerChao;
	RaycastHit2D hit;
	public bool estaNoChao;

	// Use this for initialization
	void Start()
	{
		tempoAtual = tempoAteCair;
        particula.SetActive(false);
		rb2D = GetComponent<Rigidbody2D>();
		rb2D.bodyType = RigidbodyType2D.Static;
	}

	// Update is called once per frame
	void Update()
	{
		//Debug.Log(Inventario.instancia.listaDeItens.Count);
		tempoAtual -= Time.deltaTime / 2f;
		if (tempoAtual <= 0)
		{
			rb2D.bodyType = RigidbodyType2D.Dynamic;
		}
		if (Inventario.instancia.listaDeItens.Count != 0)
		{
			if (Inventario.instancia.listaDeItens[indice] == this)
			{
				rb2D.bodyType = RigidbodyType2D.Kinematic;
				rb2D.simulated = false;
			}
			return;
			
		}
	}
	
	void FixedUpdate()
	{
		estaNoChao = EstaNoChao();
	}

	bool EstaNoChao()
	{
		hit = Physics2D.Linecast(transform.position, groundCheck.position, layerChao.value);
		if (hit.collider != null)
			return true;
		else
			return false;
	}

}
