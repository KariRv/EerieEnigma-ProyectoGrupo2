using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    float maxHealth;
    float _currentHealth;

    [SerializeField]
    bool isPlayer;

    public Image healthBar;
    public AudioSource audioSource;
    public AudioClip damageSonido;
    public float volumen = 1f;

    private void Awake()
    {
        _currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= Mathf.Abs(damage);
        audioSource.PlayOneShot(damageSonido, volumen);
        UpdateHealthBar();
        if (_currentHealth <= 0.0F)
        {
            if (isPlayer)
            {
                Cursor.visible = true;
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void Heal(float repair)
    {
        _currentHealth += Mathf.Abs(repair);
        _currentHealth = Mathf.Min(_currentHealth, maxHealth);
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            float healthPercent = _currentHealth / maxHealth;
            healthBar.transform.localScale = new Vector3(healthPercent, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }
    }
}
