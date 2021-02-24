using UnityEngine;

public class MudaAlpha : MonoBehaviour {

	[SerializeField] float valor = 3f;
	Color sprite;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>().color;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			sprite.a = Mathf.Lerp(1f, 0, valor);
			GetComponent<SpriteRenderer>().color = sprite;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			sprite.a = Mathf.Lerp(0, 1f, valor);
			GetComponent<SpriteRenderer>().color = sprite;
		}
	}
}
