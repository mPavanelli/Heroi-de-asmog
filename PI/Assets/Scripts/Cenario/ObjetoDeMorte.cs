using UnityEngine;

public class ObjetoDeMorte : Respawn
{
	Transform tr;

	void Start()
	{
		tr = GetComponent<Transform>();
	}

	void Update()
	{
		tr.Rotate(0, 0, 500f * Time.deltaTime);

		if (tr.position.y < -10)
		{
			Destroy(gameObject);
		}
	}
	
	
}
