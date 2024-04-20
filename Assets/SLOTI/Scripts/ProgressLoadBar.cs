using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _uniqueSlider;
    public float TotalTime { get; set; } = 3f;
    private float _elapsedTime = 0f;

    private void Start()
    {
        StartCoroutine(ExecuteAsynchronously());
    }

    private IEnumerator ExecuteAsynchronously()
    {
        float initialTime = Time.time;

        while (_elapsedTime < TotalTime)
        {
            float progress = _elapsedTime / TotalTime;
            UpdateSliderProgress(progress);
            yield return null;
            _elapsedTime = Time.time - initialTime;
        }

        Destroy(this.gameObject);
    }

    private void UpdateSliderProgress(float progress)
    {
        _uniqueSlider.value = progress;
    }
}
