using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FightItem : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    private float _speed;
    private float _fadeTime;

    private void Start()
    {
        GetInfo("SwordDestruction", 15, 1.2f);
    }

    public void GetInfo(string keyName, float speed, float attack)
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>(keyName);
        _speed = speed;
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        _fadeTime = 0.1f;
        fillImage.fillAmount = 0;
        for (float i = 0; i < _speed; i += _fadeTime)
        {
            yield return new WaitForSeconds(_fadeTime);
            Debug.Log("2"); //////////////////////////////////////////
            fillImage.fillAmount += _fadeTime;
        }
    }
}
