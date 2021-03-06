using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    Slider slider;
    Player player;
    SoundFXManager audioManager;
    public AudioClip bulletMusic;
    float startTime;
    float freq;


    // Start is called before the first frame update
    void Start()
    {
        
        player = (Player) Resources.FindObjectsOfTypeAll(typeof(Player))[0];
        slider = GameObject.FindGameObjectsWithTag("HealthBar")[0].GetComponent<Slider>();
        audioManager = GameObject.FindGameObjectsWithTag("SoundFX")[0].GetComponent<SoundFXManager>();
        startTime = Time.time;
        freq = 2.0f;
        InvokeRepeating("Shoot", 2.0f, freq);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > 10)
        {
            freq = freq/2;
            CancelInvoke("Shoot");
            InvokeRepeating("Shoot", 0.0f, freq);
            startTime = Time.time;
        }
        
        if (slider.value == 0 || !player.alive)
        {
            CancelInvoke("Shoot");
        }
    }

    void Shoot()
    {
        //shooting logic
        Instantiate(bulletPrefab, new Vector3(transform.position.x - 0.925f, transform.position.y + 0.4f, transform.position.z), transform.rotation);
        audioManager.playFX(bulletMusic);
    }
}