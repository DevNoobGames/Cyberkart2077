using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class DevNoobEdit : MonoBehaviour
{
    public RVP.VehicleDebug VehicleDebug;
    public bool HasPowerUp;
    public IMGPowerUp IMGPowerUp;
    public string ActivePowerUp;
    public GameObject[] Enemies;
    public GameObject PowerUpCanvas;
    public GameObject Bullet;
    public GameObject ShotSpawn;
    public GameObject Lego;
    public GameObject LegoSpawn;
    public GameObject boobyTrap;
    public int Ammo;
    public Positioning rankList;
    public Thunder thunder;
    public GameObject Missile;

    public Text TargetText;
    public Text RankText;

    public AudioSource Checkpoint;
    public AudioSource TeleportAudio;
    public AudioSource PowerupAudio;
    public AudioSource HopAudio;
    public AudioSource FreezeAudio;
    public AudioSource ShotAudio;
    public AudioSource ThunderAudio;
    //public GameObject target;

    private void Start()
    {
        ActivePowerUp = "";
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Teleport1")
        {
            transform.position = new Vector3(-25f, 60, -32);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            TeleportAudio.Play();
        }

        if (other.tag == "Teleport2")
        {
            transform.position = new Vector3(-36, 1, 46);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            TeleportAudio.Play();
        }

        if (other.tag == "Checkpoint1")
        {
            VehicleDebug.spawnPos = other.transform.position;
            VehicleDebug.spawnRot = transform.rotation.eulerAngles;
            Checkpoint.Play();
        }

        if (other.tag == "PowerUp")
        {
            if (!HasPowerUp)
            {
                HasPowerUp = true;
                other.GetComponent<MeshRenderer>().enabled = false;
                other.GetComponent<MeshCollider>().enabled = false;
                other.GetComponent<PowerUpScript>().Active = false;
                StartCoroutine(other.GetComponent<PowerUpScript>().SetActive());
                StartCoroutine(IMGPowerUp.PowerUpAnim());
                PowerupAudio.Play();
            }
        }
        if (other.tag == "lego")
        {
            StartCoroutine(GetComponent<RVP.VehicleDebug>().ResetRotation());
            Destroy(other.gameObject);
            HopAudio.Play();
        }
        if (other.tag == "boobyTrap")
        {
            StartCoroutine(GetComponent<RVP.VehicleDebug>().ResetRotation());
            Destroy(other.gameObject);
            HopAudio.Play();
        }
    }





    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (ActivePowerUp != "")
            {
                if (ActivePowerUp == "powerupFreeze")
                {
                    foreach (GameObject Enemy in Enemies)
                    {
                        StartCoroutine(Enemy.GetComponent<RVP.VehicleDebug>().Frozen());
                    }
                    ActivePowerUp = "";
                    PowerUpCanvas.GetComponent<RawImage>().enabled = false;
                    HasPowerUp = false;
                    FreezeAudio.Play();
                }
                if (ActivePowerUp == "PowerupGun")
                {
                    if (Ammo > 0)
                    {
                        //Shoot
                        GameObject bullet = Instantiate(Bullet, ShotSpawn.transform.position, Quaternion.identity) as GameObject;
                        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 5000);
                        bullet.GetComponent<DestroyAfterTime>().RunCour();
                        Ammo -= 1;
                        ShotAudio.Play();
                        if (Ammo == 0)
                        {
                            ActivePowerUp = "";
                            PowerUpCanvas.GetComponent<RawImage>().enabled = false;
                            HasPowerUp = false;
                        }
                    }
                }
                if (ActivePowerUp == "PowerupMissile")
                {
                    int Position = findNumberInList() + 1;
                    if (Position - 1 != 0)
                    {
                        Vector3 DriverAtk = new Vector3(rankList.ScoreList[Position - 2].Driver.transform.position.x, rankList.ScoreList[Position - 2].Driver.transform.position.y + 3, rankList.ScoreList[Position - 2].Driver.transform.position.z);
                        GameObject missile = Instantiate(Missile, DriverAtk, Quaternion.identity);
                        missile.transform.eulerAngles = new Vector3(-90, 0, 0);
                        //missile.GetComponent<Rigidbody>().useGravity = true;
                        missile.GetComponent<MissileScript1>().target = rankList.ScoreList[Position - 2].Driver;
                        //StartCoroutine(rankList.ScoreList[Position - 2].Driver.GetComponent<RVP.VehicleDebug>().ResetRotation());
                    }
                    if (Position - 1 == 0)
                    {
                        Vector3 DriverAtk = new Vector3(rankList.ScoreList[Position].Driver.transform.position.x, rankList.ScoreList[Position].Driver.transform.position.y + 3, rankList.ScoreList[Position].Driver.transform.position.z);
                        GameObject missile = Instantiate(Missile, DriverAtk, Quaternion.identity);
                        missile.transform.eulerAngles = new Vector3(-90, 0, 0);
                        missile.GetComponent<MissileScript1>().target = rankList.ScoreList[Position].Driver;
                    }
                    ActivePowerUp = "";
                    TargetText.text = "";
                    ShotAudio.Play();
                    PowerUpCanvas.GetComponent<RawImage>().enabled = false;
                    HasPowerUp = false;
                }
                if (ActivePowerUp == "PowerupLego")
                {
                    GameObject lego = Instantiate(Lego, LegoSpawn.transform.position, Quaternion.identity) as GameObject;
                    lego.transform.eulerAngles = new Vector3(LegoSpawn.transform.eulerAngles.x - 90, transform.eulerAngles.y + 90, 0);
                    ActivePowerUp = "";
                    PowerUpCanvas.GetComponent<RawImage>().enabled = false;
                    HasPowerUp = false;
                    ShotAudio.Play();
                }
                if (ActivePowerUp == "PowerupThunder")
                {
                    foreach (GameObject Enemy in Enemies)
                    {
                        StartCoroutine(Enemy.GetComponent<RVP.VehicleDebug>().ResetRotation());
                    }
                    ActivePowerUp = "";
                    PowerUpCanvas.GetComponent<RawImage>().enabled = false;
                    HasPowerUp = false;
                    thunder.enabled = true;
                    ThunderAudio.Play();
                    //StartCoroutine(thunderRun());
                }
                if (ActivePowerUp == "PowerupBox")
                {
                    GameObject BoobyTrap = Instantiate(boobyTrap, LegoSpawn.transform.position, Quaternion.identity) as GameObject;
                    BoobyTrap.transform.eulerAngles = new Vector3(-90, 0, 0);
                    BoobyTrap.transform.position = new Vector3(LegoSpawn.transform.position.x, 1.04f, LegoSpawn.transform.position.z);
                    ActivePowerUp = "";
                    PowerUpCanvas.GetComponent<RawImage>().enabled = false;
                    HasPowerUp = false;
                    ShotAudio.Play();
                }
            }
        }

        if (ActivePowerUp == "PowerupMissile")
        {
            //TargetText.text = rankList.ScoreList.Where(x => x.Driver == transform.gameObject).SingleOrDefault().
            int Position = findNumberInList() + 1;

            if (Position - 1 != 0)
            {
                TargetText.text = "TARGET:" + "\n" + rankList.ScoreList[Position - 2].Driver.name.ToString();
            }
            if (Position - 1 == 0)
            {
                TargetText.text = "TARGET:" + "\n" + rankList.ScoreList[Position].Driver.name.ToString();
            }
        }

        int Pos = findNumberInList() + 1;
        RankText.text = Pos.ToString();
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

    
}


/*private void FixedUpdate()
{
    if (ActivePowerUp == "powerupMissile")
    {
        RaycastHit hit;
        if (Physics.Raycast(ShotSpawn.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.transform.name == "Enemy")
            {
                Debug.Log(hit.transform.name);
                target.SetActive(true);
                Debug.DrawRay(ShotSpawn.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                //target.transform.position = hit.transform.position; 
            }
        }
        else
        {
            target.SetActive(false);
        }
    }
}*/