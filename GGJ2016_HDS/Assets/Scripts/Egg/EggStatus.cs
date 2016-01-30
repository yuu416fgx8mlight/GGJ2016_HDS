using UnityEngine;
using System.Collections;

public class EggStatus : MonoBehaviour {
	private int MaxHP;
	public int EggHP=3;
	public int EggLevel;
	public int Hot=0;
	public int Stres=0;
	public GameObject Egg;
	public GameObject BoilEgg;
	public string name;
	private string[] ChickenList={"Chicken", "Chicken", "Chicken"};
	private string[] ChickList={"Chick", "Chick", "Chick"};
	private string[] EggList={"Chicken", "bb", "ccc"};

	private int i;

	private float time;
	 Animator anime;
	// Use this for initialization
	void Start () {
		name = "Shaking";
		MaxHP = EggHP;
		EggLevel = 0;
		EggLevel = Mathf.Clamp (EggLevel, 0, 3);
		Mathf.Clamp (EggHP, 0, MaxHP);
		anime = GetComponent<Animator> ();
		InvokeRepeating ("LevelUP",9,9);
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		i = Hot - Stres;
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
			
			if (EggLevel == 0) {
				Instantiate (Egg,gameObject.transform.position, Quaternion.identity);
				Destroy (gameObject);
			}
			if (EggLevel == 1) {
				GameObject prefab = (GameObject)Resources.Load ("Character/" + ChickList[i]);
				Instantiate (prefab,gameObject.transform.position, Quaternion.identity);
				Destroy (gameObject);
			}
			if (EggLevel == 2) {
				GameObject prefab = (GameObject)Resources.Load ("Character/" + ChickenList[i]);
				Instantiate (prefab, transform.position, transform.rotation);
				Destroy (gameObject);
			}
			if (EggLevel >=3) {
				Instantiate (BoilEgg,gameObject.transform.position, Quaternion.identity);
				Destroy (gameObject);
			}
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			EggHP--;
		}
	}

	void LevelUP(){
		EggLevel++;
		anime.Play (name);
		anime.SetInteger("WhiteShake",EggHP);
	}
}
