using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFilling;
    [SerializeField] private HealthFromEnemy _health;
    [SerializeField] private Gradient _gradient;
    private Camera _camera;



    private void Awake()
    {
        _health.HealthChanged += OnHealthChanged;
        _camera = Camera.main;
        _gradient.Evaluate(1);
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float valueAsPercantage)
    {
        _healthBarFilling.fillAmount = valueAsPercantage;
        _healthBarFilling.color = _gradient.Evaluate(valueAsPercantage);
    }

    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
    }
}
 