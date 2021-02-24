using UnityEngine;

public class FazDeslizar : MonoBehaviour
{

	[SerializeField] Personagem player;
	[SerializeField] bool desliza;

	void OnTriggerEnter2D(Collider2D outro)
	{
		if (outro.CompareTag("Player"))
		{
			if (desliza)
				Desliza();
			else
				Slow();
		}
	}
	void OnTriggerExit2D(Collider2D outro)
	{
		if (outro.CompareTag("Player"))
		{
			if (desliza)
				Desliza();
			else
				Slow();
		}
	}

	void Desliza()
	{
		player.estaDeslizando = !player.estaDeslizando;
		player.Desliza();
	}
	void Slow()
	{
		player.estaNoSlow = !player.estaNoSlow;
		player.Slow();
	}


}

