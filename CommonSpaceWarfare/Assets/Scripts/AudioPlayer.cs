using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damaging")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

    public static AudioPlayer instance; // other way to create singelton public or get'er

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        /* other way to create singelton
        if (instance != null)
        {
            gameObject.SetActive(false); // inportant
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        */ 
        int instanceCount = FindObjectsOfType(GetType()).Length; 
        if(instanceCount > 1)
        {
            gameObject.SetActive(false); // inportant
            Destroy(gameObject);
        } 
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    } 

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector2 position = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, position, volume);
        }
    }

}
