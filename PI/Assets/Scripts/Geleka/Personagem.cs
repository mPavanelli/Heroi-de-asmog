using UnityEngine;

public class Personagem : MonoBehaviour
{
	public float inputHorizontal;
	Rigidbody2D rb;
	public Vector2 velFinal;
	Transform tr;

	[SerializeField] SpriteRenderer sprite;
	[SerializeField] LayerMask layerChao;
	[SerializeField] LayerMask layerParede;
	[SerializeField] float tempoWallJump;
	[SerializeField] float forcaDoPulo = 500;
	[SerializeField] float velMovimento = 20, velMovimentoAr = 10;
	[SerializeField] Transform[] pontosVerificacao = new Transform[4];
	[SerializeField] float velocidadeDesaceleracao = 3f;

    RaycastHit2D hit;
    RaycastHit2D hit2;
    RaycastHit2D hit3;
    RaycastHit2D hit4;
	public bool estaDeslizando = false;
	public bool estaNoSlow = false;
	public bool estaNoChao;
	public bool estaNaParedeDir;
	public bool estaNaParedeEsq;
	bool podeDarWallJump;

	//estilingue
	[SerializeField] Transform objetoDeDirecaoEstilingue, pivoDaDirecaoEstilingue;
	[SerializeField] public float forcaDoEstilingue = 0, limiteDeForcaEstilingue = 0, acrescimoDeForcaEstilingue = 0;
	[SerializeField] GameObject particulaLama, particulaAgua;
	float addAnguloEstilingue = 15;
	public bool estaEstilingando = false;

	//State
	int indiceEstados = 0;
	EstadoPersonagem estado;
	EstadoPersonagem[] estados = new EstadoPersonagem[3];

	void Start()
	{
		tr = transform;
		rb = GetComponent<Rigidbody2D>();
		particulaLama.SetActive(false);
		particulaAgua.SetActive(false);

		//State
		estados[0] = new EstadoNoChao(gameObject, inputHorizontal, forcaDoPulo, velMovimento, velocidadeDesaceleracao, rb, velFinal, tr, pontosVerificacao[0], pontosVerificacao[3],
			pontosVerificacao[1], pontosVerificacao[2], sprite, layerChao, layerParede, hit, hit2, hit3, hit4, objetoDeDirecaoEstilingue, pivoDaDirecaoEstilingue, forcaDoEstilingue,
			limiteDeForcaEstilingue, acrescimoDeForcaEstilingue, addAnguloEstilingue);

		estados[1] = new EstadoNoAr(gameObject, inputHorizontal, velMovimentoAr, rb, velFinal, tr, pontosVerificacao[0], pontosVerificacao[3], pontosVerificacao[1], pontosVerificacao[2],
			sprite, layerChao, layerParede, hit, hit2, hit3, hit4);

		estados[2] = new EstadoNaParede(gameObject, inputHorizontal, forcaDoPulo, velMovimento, rb, velFinal, tr, pontosVerificacao[0], pontosVerificacao[3],
			pontosVerificacao[1], pontosVerificacao[2], sprite, layerChao, layerParede, hit, hit2, hit3, hit4);

		estado = estados[indiceEstados];

	}

	void Update()
	{
		if (!PauseMenu.current.pausado)
		{
			if (!ManagerDialogo.current.emDialogo)
			{
				estado.EstadoUpdate();
				estado = estados[indiceEstados];
                AtualizaAnimacao();
			}
		}
	}
    
	void FixedUpdate()
	{
		if (!PauseMenu.current.pausado)
		{
			indiceEstados = estado.EstaNoChaoParede();
			estado.EstadoFixedUpdate();
		}
	}

	#region DeslizaOuSlow
	public void Desliza()
	{
		if (estaDeslizando)
		{
			particulaAgua.SetActive(true);
			rb.drag = 0;
		}
		else
		{

			particulaAgua.SetActive(false);
			rb.drag = 0.6f;
		}
	}
	public void Slow()
	{
		if (estaNoSlow)
		{
			particulaLama.SetActive(true);
			rb.mass = rb.mass * 1.5f;
		}
		else
		{
			particulaLama.SetActive(false);
			rb.mass = rb.mass / 1.5f;
		}
	}
	#endregion

    void AtualizaAnimacao()
    {
        if (indiceEstados == 1)
        {
            estaNoChao = false;
            estaNaParedeDir = false;
            estaNaParedeEsq = false;
            estaEstilingando = false;
        }
        else if (indiceEstados == 2 && !estaNaParedeEsq)
        {
            estaNaParedeDir = true;
            estaNaParedeEsq = false;
            estaNoChao = false;
        }
        else if (indiceEstados == 2 && !estaNaParedeDir)
        {
            estaNaParedeEsq = true;
            estaNaParedeDir = false;
            estaNoChao = false;
        }
        else
        {
            estaNoChao = true;
            estaNaParedeDir = false;
            estaNaParedeEsq = false;
        }

        if (Input.GetKeyDown(KeyCode.Z) && estaNoChao == true)
        {
            estaEstilingando = true;
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            estaEstilingando = false;
        }
    }
}