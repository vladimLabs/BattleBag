using UnityEngine;

namespace Fight {
    public class FightController : MonoBehaviour
    {
        public static FightController instance;

        [SerializeField] private BagInFight _bagInFight;
        [SerializeField] private EnemyBag _enemyBag;

        [SerializeField] private HPManager _heroHPManager;
        [SerializeField] private HPManager _enemyHPManager;

        [SerializeField] private GameObject panelEndFight;

        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            panelEndFight.SetActive(false);
            //Загружаем предметы рюкзака персоонажа
            //и генерируем врага
            _bagInFight.LoadHeroBag();
            _bagInFight.CalcPowerHero();

            //Формируем карточку здоровья для системы боя персонажа
            _heroHPManager.GenerateHero(_bagInFight.GetHero());
            _enemyHPManager.GenerateHero(_enemyBag.GetHero());
        }

        public void FightProcess(string nameHero, float hit)
        {
            switch (nameHero)
            {
                case "enemy":
                    _enemyHPManager.GetDamage(hit);
                    break;
                case "person":
                    _heroHPManager.GetDamage(hit);
                    break;
            }
        }

        public void EndFight(string nameLose)
        {
            panelEndFight.SetActive(true);
            panelEndFight.GetComponent<PanelEndFight>().ShowInfo(nameLose);
        }
    }
}
