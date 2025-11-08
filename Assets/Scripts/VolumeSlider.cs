using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // Устанавливаем значение слайдера в соответствии с текущей громкостью
        volumeSlider.value = AudioManager.Instance.GetVolume();
        // Подписываемся на изменение значения слайдера
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float value)
    {
        AudioManager.Instance.SetVolume(value);
    }
}
