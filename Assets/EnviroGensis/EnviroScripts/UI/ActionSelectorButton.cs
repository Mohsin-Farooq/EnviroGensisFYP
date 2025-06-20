using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace EnviroGenesis
{
   

    public class ActionSelectorButton : UISlot
    {
        [Header("Selector Button")]
        public Text title;
        public Image highlight;

        private SAction action;

        protected override void Awake()
        {
            base.Awake();

            if (highlight != null)
                highlight.enabled = false;
        }

        protected override void Update()
        {
            base.Update();

            if (highlight != null)
                highlight.enabled = key_hover;
        }

        public void SetButton(SAction action)
        {
            this.action = action;
            title.text = action.title;
            Show();
        }

        public SAction GetAction()
        {
            return action;
        }

    }

}