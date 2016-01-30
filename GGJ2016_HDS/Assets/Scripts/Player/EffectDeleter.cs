using UnityEngine;
using System.Collections;

public class EffectDeleter : MonoBehaviour {

	//エフェクトの命を司るスクリプト

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine ("DestroyFrag");
		//エフェクトの生存確認
		/*if (!GetComponent<ParticleSystem> ().IsAlive ()) {
			Destroy (gameObject);
		}*/
	}

	public IEnumerator DestroyFrag(){
		yield return new WaitForSeconds (1f);
		Destroy (gameObject);
	}
}
