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
	private string[] ChickenList={"Chicken","Dragon","Phonix","Yatagarasu","Basilisk"};

	private string[] ChickList={"Chick","Pig", "Cow","Pegasus","Greffon"};

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


		if (EggLevel == 1) {
			if (i == 0)
				j = 0;
			else if (i > 0 && 5 <= i)
				j = 1;
			else if (i >= 6)
				j = 3;
			else if (j <= -1 && -5 >= i)
				j = 2;
			else
				j = 4;
		}
		if (EggLevel == 2) {
			if (i == 0)
				j = 0;
			else if (i > 0 && 5 <= i)
				j = 3;
			else if (i >= 6)
				j = 4;
			else if (j <= -1 && -5 >= i)
				j = 2;
			else
				j = 1;
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

		MatSearch ();
		LightSearch ();
		i = Hot - Stres;

	}

	void LevelUP(){
		EggLevel++;
		anime.Play (name);
		anime.SetInteger("WhiteShake",EggHP);
	}
		


	void MatSearch(){
			time += Time.deltaTime;
			if (time >= 1) {
				if (EquipmentController.GetLag != null) {
				Stres+=EquipmentController.GetLag.GetComponent<Equipment> ().parametor.stress;
				}
				time = 0;
			}
	}
	void LightSearch(){
			time += Time.deltaTime;
			if (time >= 1) {
				if (EquipmentController.GetLight != null) {
					Hot += EquipmentController.GetLight.GetComponent<Equipment> ().parametor.hot;
				}
				time = 0;
			}
	}
}
