using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/" + nameof(Dialogs))]

    public class Dialogs : ScriptableObject
    {
        [System.Serializable]

        public class Dialog
        {
            [SerializeField] private string _name;
            [SerializeField] private string _text;
            [SerializeField] private ChoiseElement[] _choises;

            public string Name => _name;
            public string Text => _text;
            public ChoiseElement[] choises => _choises;
        }

        [System.Serializable]

        public class ChoiseElement
        {
            [SerializeField] private string _text;
            [SerializeField] private Dialogs _dialogs;

            public string Text => _text;
            public Dialogs Dialogs => _dialogs;
        }

        [SerializeField] private Dialog[] _dialogs;

        public Dialog[] Get => _dialogs;
    }

}
