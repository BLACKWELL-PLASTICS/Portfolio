// TP Selector
// Written by Iain Farlow
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpSelector : MonoBehaviour {
	float SpawnTime = 5.0f;

	GameObject[] Teleporters;

	[SerializeField]
	public GameObject Bullets;
	[SerializeField]
	public GameObject Gun;
	[SerializeField]
	public GameObject Health;
	[SerializeField]
	public GameObject Knife;
	[SerializeField]
	public GameObject Shield;
	[SerializeField]
	public GameObject TeleportFlash;

	void Update() {
        //Every 5 seconds 
		SpawnTime -= Time.deltaTime;
		if (SpawnTime <= 0.0f) {
            //random number 1, 2 or 3
			int rnd = Random.Range(1, 4);

            //Find all the player one area teleporters
			Teleporters = GameObject.FindGameObjectsWithTag("TP");

            //Foreach of these
            foreach (GameObject Teleporter in Teleporters) {
                //use random number to select the pickup (as long as it doesn't have teleporter script)
				if (Teleporter.name == "Pickup (" + rnd.ToString() + ")" && Teleporter.GetComponent<TeleporterScript>() == null) {
                    //add teleporter script
					Teleporter.gameObject.AddComponent<TeleporterScript>();

                    //Assign gameobjects
					Teleporter.GetComponent<TeleporterScript>().Bullets = Bullets;
					Teleporter.GetComponent<TeleporterScript>().Gun = Gun;
					Teleporter.GetComponent<TeleporterScript>().Health = Health;
					Teleporter.GetComponent<TeleporterScript>().Knife = Knife;
					Teleporter.GetComponent<TeleporterScript>().Shield = Shield;
					Teleporter.GetComponent<TeleporterScript>().TeleportFlash = TeleportFlash;
					SpawnTime = 5.0f;
				}
			}
		}
	}
}
