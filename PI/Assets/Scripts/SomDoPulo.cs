using UnityEngine;

public class SomDoPulo : MonoBehaviour {

	[SerializeField] AudioSource somPulo;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!Input.GetKey(KeyCode.Space))
		{
			//somPulo.pitch = 1;
			return;
		}
		if(!somPulo.isPlaying)
			somPulo.Play();
        somPulo.pitch = Random.Range(1.1f, 1.3f);
	}
}
