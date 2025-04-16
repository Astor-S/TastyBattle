using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSoundPlayer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ButtonSoundData _buttonSoundData;

    public void OnPointerClick(PointerEventData eventData) =>
        PlayClip(_buttonSoundData.ClickClip);

    private void PlayClip(AudioClip clip)
    {
        if (_buttonSoundData.AudioSource.isPlaying)
        {
            _buttonSoundData.AudioSource.Stop();
            _buttonSoundData.AudioSource.PlayOneShot(clip);
        }

        _buttonSoundData.AudioSource.PlayOneShot(clip);
    }
}
