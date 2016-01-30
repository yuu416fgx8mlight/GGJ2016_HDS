using UnityEngine;
using System.Collections;

public class EffectSenter : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GetComponent<ParticleRenderer> ().sortingLayerName = "Particle";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
