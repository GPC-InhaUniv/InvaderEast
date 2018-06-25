using UnityEngine;


public enum SoundType
{
    BossDead,
    EnemyAttack,
    EnemyDead,
    GetItem,
    PlayerAttack,
    PlayerDead,
    PlayerHit,
    PlayerMove,
    UseItem,

}

public class SoundManager : Singleton<SoundManager>
{
    const int effectSoundIndex = 9;

    AudioSource audioSource;
    AudioClip[] effectSound;
    AudioClip backgroundSound;
    

    SoundManager()
    { }

	void Awake ()
    {
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSource = GetComponent<AudioSource>();

        effectSound = new AudioClip[effectSoundIndex];

        effectSound[0] = Resources.Load("Sound/BossDead") as AudioClip;
        effectSound[1] = Resources.Load("Sound/EnemyAttack") as AudioClip;
        effectSound[2] = Resources.Load("Sound/EnemyDead") as AudioClip;
        effectSound[3] = Resources.Load("Sound/GetItem") as AudioClip;
        effectSound[4] = Resources.Load("Sound/PlayerAttack") as AudioClip;
        effectSound[5] = Resources.Load("Sound/PlayerDead") as AudioClip;
        effectSound[6] = Resources.Load("Sound/PlayerHit") as AudioClip;
        effectSound[7] = Resources.Load("Sound/PlayerMove") as AudioClip;
        effectSound[8] = Resources.Load("Sound/UseItem") as AudioClip;
        backgroundSound = Resources.Load("Sound/BackgroundSound") as AudioClip;

        DontDestroyOnLoad(gameObject);

    }

    public void PlayBackgroundSound()
    {
        audioSource.loop = true;
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(backgroundSound, 0.5f);
    }

    public void PlayEffectSound(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.BossDead:
                
                audioSource.PlayOneShot(effectSound[0], 0.5f);
                break;
            case SoundType.EnemyAttack:
                audioSource.PlayOneShot(effectSound[1], 0.5f);
                break;
            case SoundType.EnemyDead:
               
                audioSource.PlayOneShot(effectSound[2], 1f);
                break;
            case SoundType.GetItem:
                audioSource.PlayOneShot(effectSound[3], 0.5f);
                break;
            case SoundType.PlayerAttack:
                audioSource.PlayOneShot(effectSound[4], 0.5f);
                break;
            case SoundType.PlayerDead:
                audioSource.PlayOneShot(effectSound[5], 0.5f);
                break;
            case SoundType.PlayerHit:
                audioSource.PlayOneShot(effectSound[6], 1f);
                break;
            case SoundType.PlayerMove:
                audioSource.PlayOneShot(effectSound[7], 0.5f);
                break;
            case SoundType.UseItem:
                audioSource.PlayOneShot(effectSound[8], 0.5f);
                break;
            default:
                break;
        }
    }
  /*
    public void PlayEffectSound(string soundName)
    {
        if(soundName == "BossDead")
        {
            audioSource.PlayOneShot(effectSound[0], 0.5f);
        }

        else if(soundName == "EnemyAttack")
        {
            audioSource.PlayOneShot(effectSound[1], 0.5f);
        }

        else if(soundName == "EnemyDead")
        {
            audioSource.PlayOneShot(effectSound[2], 0.5f);
        }

        else if(soundName == "GetItem")
        {
            audioSource.PlayOneShot(effectSound[3], 0.5f);
        }

        else if(soundName == "PlayerAttack")
        {
            audioSource.PlayOneShot(effectSound[4], 0.5f);
        }

        else if(soundName == "PlayerDead")
        {
            audioSource.PlayOneShot(effectSound[5], 0.5f);
        }

        else if(soundName == "PlayerHit")
        {
            audioSource.PlayOneShot(effectSound[6], 0.5f);
        }

        else if (soundName == "PlayerMove")
        {
            audioSource.PlayOneShot(effectSound[7], 0.5f);
        }

        else if(soundName == "UseItem")
        {
            audioSource.PlayOneShot(effectSound[8], 0.5f);
        }
    }*/
}
