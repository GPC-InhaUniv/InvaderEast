using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    AudioSource audioSource;

    [SerializeField]
    AudioClip[] effectSound;
    

    SoundManager()
    { }

	void Start ()
    {
        audioSource = GetComponent<AudioSource>();

        effectSound = new AudioClip[9];

        effectSound[0] = Resources.Load("Sound/BossDead") as AudioClip;
        effectSound[1] = Resources.Load("Sound/EnemyAttack") as AudioClip;
        effectSound[2] = Resources.Load("Sound/EnemyDead") as AudioClip;
        effectSound[3] = Resources.Load("Sound/GetItem") as AudioClip;
        effectSound[4] = Resources.Load("Sound/PlayerAttack") as AudioClip;
        effectSound[5] = Resources.Load("Sound/PlayerDead") as AudioClip;
        effectSound[6] = Resources.Load("Sound/PlayerHit") as AudioClip;
        effectSound[7] = Resources.Load("Sound/PlayerMove") as AudioClip;
        effectSound[8] = Resources.Load("Sound/UseItem") as AudioClip;

    }

    public void PlayEffectSound(string soundName)
    {
        if(soundName == "BossDead")
        {
            audioSource.clip = effectSound[0];
            audioSource.Play();

        }

        else if(soundName == "EnemyAttack")
        {
            audioSource.clip = effectSound[1];
            audioSource.Play();
        }

        else if(soundName == "EnemyDead")
        {
            audioSource.clip = effectSound[2];
            audioSource.Play();
        }

        else if(soundName == "GetItem")
        {
            audioSource.clip = effectSound[3];
            audioSource.Play();
        }

        else if(soundName == "PlayerAttack")
        {
            audioSource.clip = effectSound[4];
            audioSource.Play();
        }

        else if(soundName == "PlayerDead")
        {
            audioSource.clip = effectSound[5];
            audioSource.Play();
        }

        else if(soundName == "PlayerHit")
        {
            audioSource.clip = effectSound[6];
            audioSource.Play();
        }

        else if (soundName == "PlayerMove")
        {
            audioSource.clip = effectSound[7];
            audioSource.Play();
        }

        else if(soundName == "UseItem")
        {
            audioSource.clip = effectSound[8];
            audioSource.Play();
        }
    }
}
