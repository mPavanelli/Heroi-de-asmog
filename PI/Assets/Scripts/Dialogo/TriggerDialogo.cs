using UnityEngine;

public class TriggerDialogo : MonoBehaviour {

	public Dialogo dialogo;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			ManagerDialogo.current.ComecaDialogo(dialogo);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Destroy(this);
		}
	}

}
