using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform barTransform;
    [SerializeField] private float fadeTime;
    private int currentHealth;
    private int maxHealth;

    private void Awake()
    {
        Slider bar = GetComponent<Slider>();
    }

    public void Init(int currentHealth, int maxHealth)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
    }

    public void HealthChanged(int value)
    {
        currentHealth = value;
        StartCoroutine(UpdateBar());
    }

    public void MaxHealthChanged(int value)
    {
        maxHealth = value;
        StartCoroutine(UpdateBar());
    }

    private IEnumerator UpdateBar()
    {
        float elapsedTime = 0;
        Vector3 newScale = new Vector3((float)currentHealth / maxHealth, 1, 1);
        Vector3 currentScale = barTransform.localScale;

        while (elapsedTime < fadeTime)
        {
            barTransform.localScale = Vector2.Lerp(currentScale, newScale, (elapsedTime /fadeTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        barTransform.localScale = newScale;
    }
}
