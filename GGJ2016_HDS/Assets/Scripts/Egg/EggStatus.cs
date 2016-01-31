using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EggStatus : MonoBehaviour {
	private int MaxHP;
	public int EggHP=3;
	public int EggLevel;
	public int Hot=0;
	public int Stres=0;
	private GameObject Egg;
	private GameObject BoilEgg;
	public string name;
	private string[] ChickenList={"Chicken","Pegasus","Greffon","Yatagarasu"};
	private string[] ChickList={"Chick","Pig", "Cow"};

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
		
		MatSearch ();
		LightSearch ();
		i = Hot - Stres;
		if (EggLevel == 1) {
			if (5 <= i) {
				j = 2;
			}else if (i >= 1 && i < 5) {
				j = 0;
			}else  {
				j = 1;
			}
		}
		if (EggLevel == 2) {
			if (5 <= i) {
				j = 3;
			}else if (i >= 1 && i <= 4) {
				j = 2;
			}else if(1<i&&-5>=i){
				j = 1;
			}else{
				j=0;
			}
		}


		if (EggHP<=MaxHP-1) {
			MaxHP = EggHP;
			anime.SetTrigger ("Break");
		}
		if (i < 0) {
			anime.SetTrigger ("BlueChange");
			name = "BlueShake";
		} else if (i > 0) {
			anime.SetTrigger ("RedChange");
			name = "RedShake";
		} else {
			anime.SetTrigger ("White");
			name = "Shake";
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
		


	void MatSearch(){
		GameObject Mat= GameObject.Find ("Mat(Clone)");


		if (Mat != null) {
			
			time += Time.deltaTime;
			Color color=Mat.GetComponent<Image> ().color;
			if (time >= 1) {
				Stres += 1;
				if (color == Color.blue) {
					Stres += 2;
				}
				if (color == Color.red) {
					Stres += 3;
				}
				time = 0;
			}
		}
	}
	void LightSearch(){
		GameObject Light= GameObject.Find ("Light(Clone)");

		if (Light != null) {
			time += Time.deltaTime;
			Color color=Light.GetComponent<Image> ().color;
			if (time >= 1) {
				Hot += 1;
				if (color == Color.blue) {
					Hot += 2;
				}
				if (color == Color.red) {
					Hot += 3;
				}
				time = 0;
			}
		}
	}
}
