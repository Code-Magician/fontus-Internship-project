using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region PUBLIC FIELDS

    /// <summary>
    /// Singleton instance of the class.
    /// </summary>
    public static AudioManager instance;

    #endregion


    #region PRIVATE FIELDS

    /// <summary>
    /// Reference to the background audiosource component.
    /// </summary>
    [SerializeField] AudioSource bgAudioSource;

    /// <summary>
    /// Reference to the sfx audio source component.
    /// </summary>
    [SerializeField] AudioSource sfxAudioSource;

    #endregion


    #region PRIVATE FUNCTIONS

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion


    #region PUBLIC FUNCTIONS

    /// <summary>
    /// Plays the background music on loop.
    /// </summary>
    /// <param name="_volume">Volume of background music.</param>
    public void PlayBgMusic(float _volume)
    {
        bgAudioSource.volume = _volume;
        bgAudioSource.loop = true;

        bgAudioSource.Play();
    }

    /// <summary>
    /// Play the sfx clip once.
    /// </summary>
    /// <param name="_clip">Clip to be played.</param>
    /// <param name="_volume">Volume of the audio.</param>
    public void PlaySfx(AudioClip _clip, float _volume)
    {
        sfxAudioSource.volume = _volume;
        sfxAudioSource.PlayOneShot(_clip);
    }

    #endregion
}
