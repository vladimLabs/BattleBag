using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Fight
{
    public class HPManager : MonoBehaviour
    {
        [SerializeField] private Slider hpSlider;
        [SerializeField] private TextMeshProUGUI attack;
        [SerializeField] private TextMeshProUGUI power;
        [SerializeField] private TextMeshProUGUI health;
        private Hero _hero;
        private float baseHP = 5;
        private float baseAttack = 8;

        private float nowHp;

        public void GenerateHero(Hero hero)
        {
            _hero = hero;
            _hero.Health += baseHP;
            _hero.Attack += baseAttack;
            attack.text = _hero.Attack.ToString();
            power.text = _hero.Power.ToString();
            health.text = _hero.Health.ToString();
            hpSlider.maxValue = _hero.Health;
            nowHp = _hero.Health;
            hpSlider.value = nowHp;
        }

        public void GetDamage(float hit)
        {
            nowHp -= hit;
            hpSlider.value = nowHp;
            if (nowHp <= 0)
            {
                FightController.instance.EndFight(_hero.NameHero);
                Time.timeScale = 0;
            }
        }
    }
}
