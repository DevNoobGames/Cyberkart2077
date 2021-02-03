using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPowerUps : MonoBehaviour
{
    public bool Enabled;
    public bool HasPowerUp;
    public string ActivePowerUp;
    [Header("Including player")]
    public GameObject[] Enemies;

    [Header("Random things")]
    public GameObject Bullet;
    public GameObject ShotSpawn;
    public GameObject Lego;
    public GameObject LegoSpawn;
    public GameObject boobyTrap;
    public int Ammo;
    public Positioning rankList;
    public Thunder thunder;
    public GameObject Missile;

    public Animation FrozenAnim;

    public AudioSource FreezeAudio;
    public AudioSource ThunderAudio;
    public AudioSource ShotAudio;

    void Start()
    {
        //HasPowerUp = true;
        ActivePowerUp = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enabled)
        {
            if (other.tag == "PowerUp" && enabled == true)
            {
                if (!HasPowerUp)
                {
                    HasPowerUp = true;
                    other.GetComponent<MeshRenderer>().enabled = false;
                    other.GetComponent<MeshCollider>().enabled = false;
                    other.GetComponent<PowerUpScript>().Active = false;
                    StartCoroutine(other.GetComponent<PowerUpScript>().SetActive());

                    float randVal = Random.value;
                    if (randVal < 0.16)
                    {
                        ActivePowerUp = "PowerupBox";
                    }
                    else if (randVal < 0.25)
                    {
                        ActivePowerUp = "powerupFreeze";
                    }
                    else if (randVal < 0.48)
                    {
                        ActivePowerUp = "PowerupGun";
                    }
                    else if (randVal < 0.66)
                    {
                        ActivePowerUp = "PowerupLego";
                    }
                    else if (randVal < 0.83)
                    {
                        ActivePowerUp = "PowerupMissile";
                    }
                    else
                    {
                        ActivePowerUp = "PowerupThunder";
                    }

                    float WaitForAttack = Random.Range(0.5f, 15);
                    StartCoroutine(Attack(WaitForAttack));
                }
            }
        }
    }

    IEnumerator Attack(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (ActivePowerUp == "PowerupBox")
        {
            GameObject BoobyTrap = Instantiate(boobyTrap, LegoSpawn.transform.position, Quaternion.identity) as GameObject;
            BoobyTrap.transform.eulerAngles = new Vector3(-90, 0, 0);
            BoobyTrap.transform.position = new Vector3(LegoSpawn.transform.position.x, 1.04f, LegoSpawn.transform.position.z);
        }
        if (ActivePowerUp == "powerupFreeze")
        {
            FrozenAnim.Play();
            foreach (GameObject Enemy in Enemies)
            {
                StartCoroutine(Enemy.GetComponent<RVP.VehicleDebug>().Frozen());
            }
            FreezeAudio.Play();
        }
        if (ActivePowerUp == "PowerupGun")
        {
            StartCoroutine(Shooting());
        }
        if (ActivePowerUp == "PowerupLego")
        {
            GameObject lego = Instantiate(Lego, LegoSpawn.transform.position, Quaternion.identity) as GameObject;
            lego.transform.eulerAngles = new Vector3(LegoSpawn.transform.eulerAngles.x - 90, transform.eulerAngles.y + 90, 0);
        }
        if (ActivePowerUp == "PowerupMissile")
        {
            int Position = findNumberInList() + 1;
            if (Position - 1 != 0)
            {
                Vector3 DriverAtk = new Vector3(rankList.ScoreList[Position - 2].Driver.transform.position.x, rankList.ScoreList[Position - 2].Driver.transform.position.y + 3, rankList.ScoreList[Position - 2].Driver.transform.position.z);
                GameObject missile = Instantiate(Missile, DriverAtk, Quaternion.identity);
                missile.transform.eulerAngles = new Vector3(-90, 0, 0);
                missile.GetComponent<MissileScript1>().target = rankList.ScoreList[Position - 2].Driver;
            }
            if (Position - 1 == 0)
            {
                Vector3 DriverAtk = new Vector3(rankList.ScoreList[Position].Driver.transform.position.x, rankList.ScoreList[Position].Driver.transform.position.y + 3, rankList.ScoreList[Position].Driver.transform.position.z);
                GameObject missile = Instantiate(Missile, DriverAtk, Quaternion.identity);
                missile.transform.eulerAngles = new Vector3(-90, 0, 0);
                missile.GetComponent<MissileScript1>().target = rankList.ScoreList[Position].Driver;
            }
        }
        if (ActivePowerUp == "PowerupThunder")
        {
            foreach (GameObject Enemy in Enemies)
            {
                StartCoroutine(Enemy.GetComponent<RVP.VehicleDebug>().ResetRotation());
            }
            thunder.enabled = true;
            ThunderAudio.Play();
        }

        ActivePowerUp = "";
        HasPowerUp = false;
    }

    int findNumberInList()
    {
        for (int i = 0; i < rankList.ScoreList.Count; i++)
        {
            if (rankList.ScoreList[i].Driver == gameObject)
            {
                return i;
            }
        }
        return -1;
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject bullet = Instantiate(Bullet, ShotSpawn.transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 5000);
        bullet.GetComponent<DestroyAfterTime>().RunCour();

        yield return new WaitForSeconds(0.4f);
        GameObject bullet1 = Instantiate(Bullet, ShotSpawn.transform.position, Quaternion.identity) as GameObject;
        bullet1.GetComponent<Rigidbody>().AddForce(transform.forward * 5000);
        bullet1.GetComponent<DestroyAfterTime>().RunCour();

        yield return new WaitForSeconds(0.9f);
        GameObject bullet2 = Instantiate(Bullet, ShotSpawn.transform.position, Quaternion.identity) as GameObject;
        bullet2.GetComponent<Rigidbody>().AddForce(transform.forward * 5000);
        bullet2.GetComponent<DestroyAfterTime>().RunCour();

        yield return new WaitForSeconds(1.4f);
        GameObject bullet3 = Instantiate(Bullet, ShotSpawn.transform.position, Quaternion.identity) as GameObject;
        bullet3.GetComponent<Rigidbody>().AddForce(transform.forward * 5000);
        bullet3.GetComponent<DestroyAfterTime>().RunCour();

        yield return new WaitForSeconds(1.6f);
        GameObject bullet4 = Instantiate(Bullet, ShotSpawn.transform.position, Quaternion.identity) as GameObject;
        bullet4.GetComponent<Rigidbody>().AddForce(transform.forward * 5000);
        bullet4.GetComponent<DestroyAfterTime>().RunCour();

    }
}
