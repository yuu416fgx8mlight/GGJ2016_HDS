using UnityEngine;
using System.Collections;

public class EggStatus : MonoBehaviour {
	private int MaxHP;
	public int EggHP=3;
	public int EggLevel;
	public int Hot=0;
	public int Stres=0;
	private GameObject Egg;
	private GameObject BoilEgg;
	public string name;
	private string[] ChickenList={"Chicken", "Pegasus", "Chicken"};
	private string[] ChickList={"Chick", "Pig", "Cow"};

	public int i;
	private int j;
	private float time;
	 Animator anime;
	// Use this for initialization
	void Start () {
		name = "Shaking";
		MaxHP = EggHP;
		EggLevel = 0;
		anime = GetComponent<Animator> ();
		BoilEgg=(GameObject)Resources.Load ("Character/yude_egg");
		Egg = (GameObject)Resources.Load ("Character/nama_egg");
		InvokeRepeating ("LevelUP",9,9);
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		i = Hot - Stres;
		if (EggLevel == 1) {
			if (i >= 1 && i <= 5) {
				j = 1;
			}
			if (i <= -1 ) {
				j = 2;
			}
		}
		if (EggLevel == 2) {
			if (i >= 1 && i <= 5) {
				j = 1;
			}
		}


		if (EggHP<=MaxHP-1) {
			MaxHP = EggHP;
			anime.SetTrigger ("Break");
		}
		if (i < 0) {
			anime.SetTrigger ("BlueChange");
			name = "BlueShake";
		}
		if (i > 0) {
			anime.SetTrigger ("RedChange");
			name = "RedShake";
		}

		if (EggHP <= 0) {
			EggHP = 0;
			if (EggLevel == 0) {
				Instantiate (Egg,gameObject.transform.position, Quaternion.identity);
				Destroy (gameObject);
			}else if (EggLevel == 1) {
				GameObject prefab = (GameObject)Resources.Load ("Character/" + ChickList[j]);
				Instantiate (prefab,gameObject.transform.position, Quaternion.identity);
				Destroy (gameObject);
			}else if (EggLevel == 2) {
				GameObject prefab = (GameObject)Resources.Load ("Character/" + ChickenList[j]);
				Instantiate (prefab, gameObject.transform.position,Quaternion.identity);
				Destroy (gameObject);
			}else{
				Instantiate (BoilEgg,gameObject.transform.position, Quaternion.identity);
				Destroy (gameObject);
			}
		}

	}

	void LevelUP(){
		EggLevel++;
		anime.Play (name);
		anime.SetInteger("WhiteShake",EggHP);
	}
}
