using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using Items;
using Fight;

public class FightItem : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private Image imageItem;
    [SerializeField] private TextMeshProUGUI levelItem;
    private GameItem _gameItem;
    private float _fadeTime;
    private float duration;
    private string _nameHero;

    public void GetInfo(GameItem gameItem, string nameHero)
    {
        if (gameItem != null)
        {
            _nameHero = nameHero;
            _gameItem = gameItem;
            imageItem.sprite = Resources.Load<Sprite>(_gameItem.KeyItem + _gameItem.Level.ToString());
            GetComponent<Image>().sprite = Resources.Load<Sprite>(_gameItem.KeyItem);
            levelItem.text = _gameItem.Level.ToString();

            _fadeTime = _gameItem.Speed;
            // Умножаем на 1/ fillSpeed, чтобы увеличить скорость при увеличении значения
            duration = 1f / _fadeTime;
            StartCoroutine(Attack(duration));
        }
        else
        {
            levelItem.text = "";
        }
    }

    public float GetPowerItem()
    {
        return _gameItem.Power;
    }

    private IEnumerator Attack(float duration)
    {
        float elapsedTime = 0f;
        float targetValue = 1f;

        while (fillImage.fillAmount < targetValue)
        {
            fillImage.fillAmount += Mathf.Lerp(elapsedTime, targetValue, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
        }

        fillImage.fillAmount = 0;
        FightController.instance.FightProcess(_nameHero, _gameItem.Attack);
        StartCoroutine(Attack(duration));
    }

    public float GetHealthBonus()
    {
        return _gameItem.Health;
    }
    public float GetAttackBonus()
    {
        return _gameItem.Attack;
    }
    public bool GetNotNullGameItem()
    {
        return _gameItem != null;
    }
}
