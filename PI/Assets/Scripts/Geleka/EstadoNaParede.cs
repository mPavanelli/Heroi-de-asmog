using UnityEngine;

public class EstadoNaParede : EstadoPersonagem
{
	float inputHorizontal, forcaDoPulo, velMovimento;
	Rigidbody2D rb;
	public Vector2 velFinal;
	Transform tr, groundCheck1, groundCheck2, checaParedeDireita, checaParedeEsquerda;
	SpriteRenderer sprite;
	LayerMask layerChao, layerParede;
	RaycastHit2D hit, hit2, hit3, hit4;
	bool estaNaParedeDireita, estaNaParedeEsquerda;
	Personagem player;

	public EstadoNaParede(GameObject gobj, float inputHorizontal, float forcaDoPulo, float velMovimento, Rigidbody2D rb, Vector2 velFinal,
		Transform tr, Transform groundCheck1, Transform groundCheck2, Transform checaParedeDireita, Transform checaParedeEsquerda, SpriteRenderer sprite,
		LayerMask layerChao, LayerMask layerParede, RaycastHit2D hit, RaycastHit2D hit2, RaycastHit2D hit3, RaycastHit2D hit4) : base(gobj)
	{
		this.inputHorizontal = inputHorizontal;
		this.forcaDoPulo = forcaDoPulo;
		this.velMovimento = velMovimento;
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
		player = gobj.GetComponent<Personagem>();
	}

	public override void EstadoUpdate()
	{
		if (!ManagerDialogo.current.emDialogo)
		{
			LeInput();
            VerificaParede();
		}
	}

	public override void EstadoFixedUpdate()
	{
		EstaNoChaoParede();
		if (!ManagerDialogo.current.emDialogo)
		{
			AplicaMovimento();
		}
	}

	public override void LeInput()
	{
		inputHorizontal = Input.GetAxisRaw("Horizontal");

		if (Input.GetKeyDown(KeyCode.Space) && player.estaNaParedeDir)
		{
			rb.velocity = Vector2.zero;
			rb.AddForce(Vector2.up * forcaDoPulo + Vector2.left * forcaDoPulo / 3);
		}
		else if (Input.GetKeyDown(KeyCode.Space) && player.estaNaParedeEsq)
		{
			rb.velocity = Vector2.zero;
			rb.AddForce(Vector2.up * forcaDoPulo + Vector2.right * forcaDoPulo / 3);
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
			player.estaNaParedeDir = false;
			player.estaNaParedeEsq = false;
			return 0;
		}
		else if (hit3.collider != null)
		{
			player.estaNaParedeDir = true;
			return 2;
		}
		else if (hit4.collider != null)
		{
			player.estaNaParedeEsq = true;
			return 2;
		}
		player.estaNaParedeDir = false;
		player.estaNaParedeEsq = false;
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

		if (player.estaNaParedeDir)
		{
			sprite.flipX = false;
		}
		else if (player.estaNaParedeEsq)
		{
			sprite.flipX = true;
		}
	}

    void VerificaParede()
    {
        if (player.estaNaParedeDir && inputHorizontal < 0)
        {
            player.estaNaParedeDir = false;
        }
        if (player.estaNaParedeEsq && inputHorizontal > 0)
        {
            player.estaNaParedeEsq = false;
        }
    }
}
