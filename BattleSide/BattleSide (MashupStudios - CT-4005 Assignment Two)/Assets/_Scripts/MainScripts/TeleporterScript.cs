// Teleporter Script
// Written by Iain Farlow
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour {
	public GameObject Bullets;
	public GameObject Gun;
	public GameObject Health;
	public GameObject Knife;
	public GameObject Shield;
	public GameObject TeleportFlash;

	void Start() {
        //random number to choose pickup to spawn
		int rnd = Random.Range(1, 6);
        //get the teleporters position and add 0.3 to y
		float tpPosX = this.transform.position.x;
		float tpPosY = this.transform.position.y + 0.3f;
		Vector2 tpVec = new Vector2(tpPosX, tpPosY);
		if (rnd == 1) {
            //Create the object
			GameObject BulletPickUp = (GameObject)Instantiate(Bullets, tpVec, Quaternion.identity);
            //Set the name
			BulletPickUp.name = "Bullets";
            //Set the tag to the teleports name
            BulletPickUp.tag = this.gameObject.name;
            //turn collider on and off incase player is already on that position
			BulletPickUp.gameObject.GetComponent<Collider2D>().enabled = false;
			BulletPickUp.gameObject.GetComponent<Collider2D>().enabled = true;
			BulletPickUp.tag = this.name.ToString();
            //Create teleporter flash
			GameObject Flash = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);

            //Do again 4 times for all pickups
            tpVec.x += 30.0f;
            GameObject BulletPickUp2 = (GameObject)Instantiate(Bullets, tpVec, Quaternion.identity);
            BulletPickUp2.name = "Bullets";
            BulletPickUp2.tag = this.gameObject.name;
            BulletPickUp2.gameObject.GetComponent<Collider2D>().enabled = false;
            BulletPickUp2.gameObject.GetComponent<Collider2D>().enabled = true;
            BulletPickUp2.tag = this.name.ToString();
            GameObject Flash2 = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);

            tpVec.x += 30.0f;
            GameObject BulletPickUp3 = (GameObject)Instantiate(Bullets, tpVec, Quaternion.identity);
            BulletPickUp3.name = "Bullets";
            BulletPickUp3.tag = this.gameObject.name;
            BulletPickUp3.gameObject.GetComponent<Collider2D>().enabled = false;
            BulletPickUp3.gameObject.GetComponent<Collider2D>().enabled = true;
            BulletPickUp3.tag = this.name.ToString();
            GameObject Flash3 = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);

            tpVec.x += 30.0f;
            GameObject BulletPickUp4 = (GameObject)Instantiate(Bullets, tpVec, Quaternion.identity);
            BulletPickUp4.name = "Bullets";
            BulletPickUp4.tag = this.gameObject.name;
            BulletPickUp4.gameObject.GetComponent<Collider2D>().enabled = false;
            BulletPickUp4.gameObject.GetComponent<Collider2D>().enabled = true;
            BulletPickUp4.tag = this.name.ToString();
            GameObject Flash4 = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);
        } else if (rnd == 2) {
			GameObject GunPickUp = (GameObject)Instantiate(Gun, tpVec, Quaternion.identity);
			GunPickUp.name = "Gun";
            GunPickUp.tag = this.gameObject.name;
            GunPickUp.gameObject.GetComponent<Collider2D>().enabled = false;
			GunPickUp.gameObject.GetComponent<Collider2D>().enabled = true;
			GunPickUp.tag = this.name.ToString();
			GameObject Flash = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);

            tpVec.x += 30.0f;
            GameObject GunPickUp2 = (GameObject)Instantiate(Gun, tpVec, Quaternion.identity);
            GunPickUp2.name = "Gun";
            GunPickUp2.tag = this.gameObject.name;
            GunPickUp2.gameObject.GetComponent<Collider2D>().enabled = false;
            GunPickUp2.gameObject.GetComponent<Collider2D>().enabled = true;
            GunPickUp2.tag = this.name.ToString();
            GameObject Flash2 = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);

            tpVec.x += 30.0f;
            GameObject GunPickUp3 = (GameObject)Instantiate(Gun, tpVec, Quaternion.identity);
            GunPickUp3.name = "Gun";
            GunPickUp3.tag = this.gameObject.name;
            GunPickUp3.gameObject.GetComponent<Collider2D>().enabled = false;
            GunPickUp3.gameObject.GetComponent<Collider2D>().enabled = true;
            GunPickUp3.tag = this.name.ToString();
            GameObject Flash3 = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);

            tpVec.x += 30.0f;
            GameObject GunPickUp4 = (GameObject)Instantiate(Gun, tpVec, Quaternion.identity);
            GunPickUp4.name = "Gun";
            GunPickUp4.tag = this.gameObject.name;
            GunPickUp4.gameObject.GetComponent<Collider2D>().enabled = false;
            GunPickUp4.gameObject.GetComponent<Collider2D>().enabled = true;
            GunPickUp4.tag = this.name.ToString();
            GameObject Flash4 = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);
        } else if (rnd == 3) {
			GameObject HealthPickUp = (GameObject)Instantiate(Health, tpVec, Quaternion.identity);
			HealthPickUp.name = "Health";
            HealthPickUp.tag = this.gameObject.name;
            HealthPickUp.gameObject.GetComponent<Collider2D>().enabled = false;
			HealthPickUp.gameObject.GetComponent<Collider2D>().enabled = true;
			HealthPickUp.tag = this.name.ToString();
			GameObject Flash = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);

            tpVec.x += 30.0f;
            GameObject HealthPickUp2 = (GameObject)Instantiate(Health, tpVec, Quaternion.identity);
            HealthPickUp2.name = "Health";
            HealthPickUp2.tag = this.gameObject.name;
            HealthPickUp2.gameObject.GetComponent<Collider2D>().enabled = false;
            HealthPickUp2.gameObject.GetComponent<Collider2D>().enabled = true;
            HealthPickUp2.tag = this.name.ToString();
            GameObject Flash2 = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);

            tpVec.x += 30.0f;
            GameObject HealthPickUp3 = (GameObject)Instantiate(Health, tpVec, Quaternion.identity);
            HealthPickUp3.name = "Health";
            HealthPickUp3.tag = this.gameObject.name;
            HealthPickUp3.gameObject.GetComponent<Collider2D>().enabled = false;
            HealthPickUp3.gameObject.GetComponent<Collider2D>().enabled = true;
            HealthPickUp3.tag = this.name.ToString();
            GameObject Flash3 = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);

            tpVec.x += 30.0f;
            GameObject HealthPickUp4 = (GameObject)Instantiate(Health, tpVec, Quaternion.identity);
            HealthPickUp4.name = "Health";
            HealthPickUp4.tag = this.gameObject.name;
            HealthPickUp4.gameObject.GetComponent<Collider2D>().enabled = false;
            HealthPickUp4.gameObject.GetComponent<Collider2D>().enabled = true;
            HealthPickUp4.tag = this.name.ToString();
            GameObject Flash4 = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);
        } else if (rnd == 4) {
			GameObject KnifePickUp = (GameObject)Instantiate(Knife, tpVec, Quaternion.identity);
			KnifePickUp.name = "Knife";
            KnifePickUp.tag = this.gameObject.name;
            KnifePickUp.gameObject.GetComponent<BoxCollider2D>().enabled = false;
			KnifePickUp.gameObject.GetComponent<BoxCollider2D>().enabled = true;
			KnifePickUp.tag = this.name.ToString();
			GameObject Flash = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);

            tpVec.x += 30.0f;
            GameObject KnifePickUp2 = (GameObject)Instantiate(Knife, tpVec, Quaternion.identity);
            KnifePickUp2.name = "Knife";
            KnifePickUp2.tag = this.gameObject.name;
            KnifePickUp2.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            KnifePickUp2.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            KnifePickUp2.tag = this.name.ToString();
            GameObject Flash2 = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);

            tpVec.x += 30.0f;
            GameObject KnifePickUp3 = (GameObject)Instantiate(Knife, tpVec, Quaternion.identity);
            KnifePickUp3.name = "Knife";
            KnifePickUp3.tag = this.gameObject.name;
            KnifePickUp3.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            KnifePickUp3.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            KnifePickUp3.tag = this.name.ToString();
            GameObject Flash3 = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);

            tpVec.x += 30.0f;
            GameObject KnifePickUp4 = (GameObject)Instantiate(Knife, tpVec, Quaternion.identity);
            KnifePickUp4.name = "Knife";
            KnifePickUp4.tag = this.gameObject.name;
            KnifePickUp4.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            KnifePickUp4.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            KnifePickUp4.tag = this.name.ToString();
            GameObject Flash4 = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);
        } else if (rnd == 5) {
			GameObject ShieldPickUp = (GameObject)Instantiate(Shield, tpVec, Quaternion.identity);
			ShieldPickUp.name = "Shield";
            ShieldPickUp.tag = this.gameObject.name;
            ShieldPickUp.gameObject.GetComponent<Collider2D>().enabled = false;
			ShieldPickUp.gameObject.GetComponent<Collider2D>().enabled = true;
			ShieldPickUp.tag = this.name.ToString();
			GameObject Flash = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);

            tpVec.x += 30.0f;
            GameObject ShieldPickUp2 = (GameObject)Instantiate(Shield, tpVec, Quaternion.identity);
            ShieldPickUp2.name = "Shield";
            ShieldPickUp2.tag = this.gameObject.name;
            ShieldPickUp2.gameObject.GetComponent<Collider2D>().enabled = false;
            ShieldPickUp2.gameObject.GetComponent<Collider2D>().enabled = true;
            ShieldPickUp2.tag = this.name.ToString();
            GameObject Flash2 = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);

            tpVec.x += 30.0f;
            GameObject ShieldPickUp3 = (GameObject)Instantiate(Shield, tpVec, Quaternion.identity);
            ShieldPickUp3.name = "Shield";
            ShieldPickUp3.tag = this.gameObject.name;
            ShieldPickUp3.gameObject.GetComponent<Collider2D>().enabled = false;
            ShieldPickUp3.gameObject.GetComponent<Collider2D>().enabled = true;
            ShieldPickUp3.tag = this.name.ToString();
            GameObject Flash3 = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);

            tpVec.x += 30.0f;
            GameObject ShieldPickUp4 = (GameObject)Instantiate(Shield, tpVec, Quaternion.identity);
            ShieldPickUp4.name = "Shield";
            ShieldPickUp4.tag = this.gameObject.name;
            ShieldPickUp4.gameObject.GetComponent<Collider2D>().enabled = false;
            ShieldPickUp4.gameObject.GetComponent<Collider2D>().enabled = true;
            ShieldPickUp4.tag = this.name.ToString();
            GameObject Flash4 = (GameObject)Instantiate(TeleportFlash, tpVec, Quaternion.identity);
        }
	}
}
