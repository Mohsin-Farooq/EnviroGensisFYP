using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EnviroGenesis
{
    public class GameOverPanel : UISlotPanel
    {
        private static GameOverPanel _instance;

        protected override void Awake()
        {
            base.Awake();
            _instance = this;
        }

        protected override void Start()
        {
            base.Start();

        }

        protected override void Update()
        {
            base.Update();

        }

        public void OnClickLoad()
        {
            if (PlayerData.HasLastSave())
            {
                SceneFader.Instance.FadeInOut(() =>
                {
                    TheGame.Load();
                });
            }

            else
                OnClickNew();
        }

        public void OnClickNew()
        {
            SceneFader.Instance.FadeInOut(() =>
            {
                TheGame.NewGame();
            });
        }

      

        public static GameOverPanel Get()
        {
            return _instance;
        }
    }

}
