using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IMGPowerUp : MonoBehaviour
{
    public Texture[] PowerUpSprites;
    public DevNoobEdit DevNoobEdit;
    public float waitTime = 0.1f;

    private void Start()
    {
        GetComponent<RawImage>().enabled = false;
    }

    public IEnumerator PowerUpAnim()
    {
        GetComponent<RawImage>().enabled = true;
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(waitTime);
            GetComponent<RawImage>().texture = PowerUpSprites[Random.Range(0, PowerUpSprites.Length)];
        }
        yield return new WaitForSeconds(waitTime);
        GetComponent<RawImage>().texture = PowerUpSprites[Random.Range(0, PowerUpSprites.Length)];
        DevNoobEdit.ActivePowerUp = GetComponent<RawImage>().texture.name;
        if (GetComponent<RawImage>().texture.name == "PowerupGun")
        {
            DevNoobEdit.Ammo = 5;
        }
    }
}
