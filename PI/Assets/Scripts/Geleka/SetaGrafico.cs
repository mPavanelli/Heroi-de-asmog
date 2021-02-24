using UnityEngine;

public class SetaGrafico : MonoBehaviour {

	[SerializeField] Personagem player;
	[SerializeField] Sprite[] sprites;
	public float forca;
	SpriteRenderer spriteRenderer;
	Transform tr;
	Vector3 tamanho;
	// Use this for initialization
	void Start () {
		//forca = player.forcaDoEstilingue / player.limiteDeForcaEstilingue;
		tr = transform;
		spriteRenderer = GetComponent<SpriteRenderer>();
		tamanho.x = 1;
		tamanho.z = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (player.estaEstilingando)
		{
			//forca = player.forcaDoEstilingue / player.limiteDeForcaEstilingue;
			tamanho.y = forca;
		}
		else
		{
			forca = 0;
		}
		if(forca == 0)
		{
			spriteRenderer.sprite = sprites[0];
		}
		else if (forca > 0 && forca <= 0.16f)
		{
			spriteRenderer.sprite = sprites[1];
		}
		else if (forca > 0.16f && forca <= 0.32f)
		{
			spriteRenderer.sprite = sprites[2];
		}
		else if (forca > 0.32f && forca <= 0.48f)
		{
			spriteRenderer.sprite = sprites[3];
		}
		else if (forca > 0.48f && forca <= 0.64f)
		{
			spriteRenderer.sprite = sprites[4];
		}
		else if (forca > 0.64f && forca <= 0.80f)
		{
			spriteRenderer.sprite = sprites[5];
		}
		else if (forca > 0.80 && forca <= 1f)
		{
			spriteRenderer.sprite = sprites[6];
		}

		tr.localScale = tamanho;
		
	}
}
