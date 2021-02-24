using UnityEngine;

public class Paralax : MonoBehaviour {

	[SerializeField] Vector2[] vel;
	[SerializeField] Transform[] transforms;
    [SerializeField] Transform trCamera;
    Vector3[] posDelta;
    Vector3 posAnterior;

	void Start()
	{
		posDelta = new Vector3[transforms.Length];

	}
	// Update is called once per frame
	void Update () {

        posAnterior = trCamera.position;
	}

    void LateUpdate()
    {
		for (int i = 0; i < transforms.Length; i++)
		{
			posDelta[i] = trCamera.position - posAnterior;
			posDelta[i].x *= vel[i].x;
			posDelta[i].y *= vel[i].y;
			transforms[i].position += posDelta[i];
		}

		//Debug.Log("GameObject nome," + gameObject.name);
           
    }
}
