using UnityEngine;

public class EstadoNoAr : EstadoPersonagem
{
	float inputHorizontal, velMovimento, velDesaceleracao;
	Rigidbody2D rb;
	public Vector2 velFinal;
	Transform tr, groundCheck1, groundCheck2, checaParedeDireita, checaParedeEsquerda;
	SpriteRenderer sprite;
	LayerMask layerChao, layerParede;
	RaycastHit2D hit, hit2, hit3, hit4;

	public EstadoNoAr(GameObject gobj, float inputHorizontal, float velMovimento, Rigidbody2D rb, Vector2 velFinal,
		Transform tr, Transform groundCheck1, Transform groundCheck2, Transform checaParedeDireita, Transform checaParedeEsquerda, SpriteRenderer sprite,
		LayerMask layerChao, LayerMask layerParede, RaycastHit2D hit, RaycastHit2D hit2, RaycastHit2D hit3, RaycastHit2D hit4) : base(gobj)
	{
		this.inputHorizontal = inputHorizontal;
		this.velMovimento = velMovimento;
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
	}

	public override void EstadoUpdate()
	{
		if(!ManagerDialogo.current.emDialogo)
			LeInput();
	}

	public override void EstadoFixedUpdate()
	{
		EstaNoChaoParede();
		if(!ManagerDialogo.current.emDialogo)
			AplicaMovimento();
	}

	public override void LeInput()
	{
		inputHorizontal = Input.GetAxisRaw("Horizontal");
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
}
