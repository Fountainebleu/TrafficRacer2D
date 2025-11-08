using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Синглтон для доступа из любой точки игры
    public static AudioManager Instance;

    // Аудиоклипы
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioClip coinSound;

    // Аудиоисточники
    private AudioSource musicSource;
    private AudioSource sfxSource;

    // Переменная для хранения громкости (0-1)
    private float volume = 1f;

    void Awake()
    {
        // Проверяем, есть ли уже экземпляр этого объекта
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Не уничтожать при смене сцены

        // Создаем аудиоисточники
        musicSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        // Загружаем громкость из PlayerPrefs
        LoadVolume();

        // Устанавливаем начальную громкость
        SetVolume(volume);

        // Начинаем проигрывать музыку главного меню
        PlayMenuMusic();
    }

    // Методы для управления музыкой
    public void PlayMenuMusic()
    {
        if (menuMusic != null)
        {
            musicSource.clip = menuMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlayGameMusic()
    {
        if (gameMusic != null)
        {
            musicSource.clip = gameMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    // Методы для управления звуковыми эффектами
    public void PlayCrashSound()
    {
        if (crashSound != null)
        {
            sfxSource.PlayOneShot(crashSound);
        }
    }

    public void PlayCoinSound()
    {
        if (coinSound != null)
        {
            sfxSource.PlayOneShot(coinSound);
        }
    }

    // Управление громкостью
    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp(newVolume, 0f, 1f);
        musicSource.volume = volume;
        sfxSource.volume = volume;

        // Сохраняем в PlayerPrefs
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        return volume;
    }

    // Загрузка громкости из PlayerPrefs
    private void LoadVolume()
    {
        volume = PlayerPrefs.GetFloat("MasterVolume", 1f); // По умолчанию 100%
    }
}
