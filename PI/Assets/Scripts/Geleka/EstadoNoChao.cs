using UnityEngine;

public class EstadoNoChao : EstadoPersonagem
{
	float inputHorizontal, forcaDoPulo, velMovimento, velDesaceleracao;
	Rigidbody2D rb;
	public Vector2 velFinal;
	Transform tr, groundCheck1, groundCheck2, checaParedeDireita, checaParedeEsquerda;
	SpriteRenderer sprite;
	LayerMask layerChao, layerParede;
	RaycastHit2D hit, hit2, hit3, hit4;
	Transform objetoDirecao, pivoDirecao;
	float forcaEstilingue, limiteForcaEstilingue, acrescimoDeForca, addAnguloEstilingue;
	Animator animator;
	SetaGrafico seta;

	bool estaEstilingando = false;

	public EstadoNoChao(GameObject gobj, float inputHorizontal, float forcaDoPulo, float velMovimento, float velDesaceleracao, Rigidbody2D rb, Vector2 velFinal,
		Transform tr, Transform groundCheck1, Transform groundCheck2, Transform checaParedeDireita, Transform checaParedeEsquerda, SpriteRenderer sprite,
		LayerMask layerChao, LayerMask layerParede, RaycastHit2D hit, RaycastHit2D hit2, RaycastHit2D hit3, RaycastHit2D hit4, Transform objetoDirecao, Transform pivoDirecao, float forcaEstilingue,
		float limiteForcaEstilingue, float acrescimoDeForca, float addAnguloEstilingue) : base(gobj)
	{
		this.inputHorizontal = inputHorizontal;
		this.forcaDoPulo = forcaDoPulo;
		this.velMovimento = velMovimento;
		this.velDesaceleracao = velDesaceleracao;
		this.velFinal = velFinal;
		this.rb = rb;
		this.tr = tr;
		this.groundCheck1 = groundCheck1;
		this.groundCheck2 = groundCheck2;
		this.checaParedeDireita = checaParedeDireita;
		this.checaParedeEsquerda = checaParedeEsquerda;
		this.sprite = sprite;
		this.layerChao = layerChao;
		this.layerParede = layerParede;
		this.hit = hit;
		this.hit2 = hit2;
		this.hit3 = hit3;
		this.hit4 = hit4;
		this.objetoDirecao = objetoDirecao;
		this.pivoDirecao = pivoDirecao;
		this.forcaEstilingue = forcaEstilingue;
		this.limiteForcaEstilingue = limiteForcaEstilingue;
		this.acrescimoDeForca = acrescimoDeForca;
		this.addAnguloEstilingue = addAnguloEstilingue;
		animator = gobj.GetComponentInChildren<Animator>();
		seta = gobj.GetComponentInChildren<SetaGrafico>();
	}

	public override void EstadoUpdate()
	{
		if (!ManagerDialogo.current.emDialogo)
		{
			LeInput();
			if (estaEstilingando)
			{
				AdicionaForcaEstilingue();
			}
			AtualizaAnimacao();
		}
	}

	public override void EstadoFixedUpdate()
	{
		EstaNoChaoParede();
		if (!ManagerDialogo.current.emDialogo)
		{
			AplicaMovimento();
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, 20);
			if (inputHorizontal == 0)
				rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, velDesaceleracao * Time.fixedDeltaTime);
			seta.forca = forcaEstilingue / limiteForcaEstilingue;
		}
	}

	public override void LeInput()
	{
		if (!estaEstilingando)
		{
			inputHorizontal = Input.GetAxisRaw("Horizontal");
		}
		else
			inputHorizontal = 0;

		if (Input.GetKeyDown(KeyCode.Z))
		{
			estaEstilingando = true;
			if (!sprite.flipX)
				pivoDirecao.eulerAngles = new Vector3(0, 0, 45f);
			else if (sprite.flipX)
				pivoDirecao.eulerAngles = new Vector3(0, 0, 135f);
		}
		if (Input.GetKeyUp(KeyCode.Z))
		{
			AplicaEstilingue();
			forcaEstilingue = 0;
			estaEstilingando = false;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			CancelaEstilingue();
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (!sprite.flipX)
			{
				pivoDirecao.Rotate(tr.forward * addAnguloEstilingue);
			}
			else
			{
				pivoDirecao.Rotate(tr.forward * -addAnguloEstilingue);
			}
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			if (!sprite.flipX)
			{
				pivoDirecao.Rotate(tr.forward * -addAnguloEstilingue);
			}
			else
			{
				pivoDirecao.Rotate(tr.forward * addAnguloEstilingue);
			}
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(Vector2.up * forcaDoPulo);
			animator.SetTrigger("Pulou");
		}

	}

	public override int EstaNoChaoParede()
	{
		hit = Physics2D.Linecast(tr.position, groundCheck1.position, layerChao);
		hit2 = Physics2D.Linecast(tr.position, groundCheck2.position, layerChao);
		hit3 = Physics2D.Linecast(tr.position, checaParedeDireita.position, layerParede);
		hit4 = Physics2D.Linecast(tr.position, checaParedeEsquerda.position, layerParede);
		if (hit.collider != null || hit2.collider != null)
		{
			return 0;
		}
		else if (hit3.collider != null || hit4.collider != null)
		{
			return 2;
		}

		return 1;
	}

	public override void AplicaMovimento()
	{
		velFinal.x = inputHorizontal * velMovimento;
		velFinal.y = rb.velocity.y;
		rb.AddForce(velFinal);
		if (inputHorizontal > 0)
		{
			sprite.flipX = false;
		}
		else if (inputHorizontal < 0)
		{
			sprite.flipX = true;
		}
	}

	void AplicaEstilingue()
	{
		if (estaEstilingando)
		{
			rb.AddForce((objetoDirecao.position - tr.position).normalized * forcaEstilingue);
		}
	}

	void CancelaEstilingue()
	{
		estaEstilingando = false;
		forcaEstilingue = 0;
	}

	void AdicionaForcaEstilingue()
	{
		forcaEstilingue += acrescimoDeForca * Time.deltaTime;
		if (forcaEstilingue >= limiteForcaEstilingue)
		{
			forcaEstilingue = limiteForcaEstilingue;
		}
	}

	void AtualizaAnimacao()
	{
		animator.SetFloat("Velocidade", Mathf.Abs(velFinal.x));
	}
}
