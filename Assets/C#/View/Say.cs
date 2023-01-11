using UnityEngine;
using Game.Data;
using TMPro;
using MyDialogs = Game.Data.Dialogs;

namespace Game.View
{
    public class Say : MonoBehaviour
    {
        [SerializeField] private Commander _commander;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Choise _choise;
        [Header("Time write")]
        [SerializeField] private float _time;

        public MyDialogs Dialogs { get; set;}

        private int _index = 0;
        private Write _write;
        private Coroutine _coroutineWrite;

        private void Awake() => _write = new Write(_time);

        private void OnEnable()
        {
            _write.SelfWrite += Write;
            _write.EndWrite += ChoiseCreate;
        }

        private void OnDisable()
        {
            _write.SelfWrite -= Write;
            _write.EndWrite -= ChoiseCreate;
        }

        public void NextDialog()
        {
            if (_index == Dialogs.Get.Length)
            {
                _commander.ExecuteCommand();
                return;
            }

            if (_write.SelfStatus == Game.Write.Status.Enabled)
            {
                StopCoroutine(_coroutineWrite);
                _write.SelfStatus = Game.Write.Status.Disabled;
            }
            if (_write.SelfStatus == Game.Write.Status.Disabled) _coroutineWrite = StartCoroutine(_write.Get(Dialogs.Get[_index].Text));

            Debug.Log("Есть нажатие на текст!");

            _name.SetText(Dialogs.Get[_index].Name);
            if (Dialogs.Get[_index].choises.Length >= 1) return;
            _index++;
        }

        private void Write(string str) => _text.SetText(str);

        public void ChoiseCreate()
        {
            if (_index == Dialogs.Get.Length) return;
            if (Dialogs.Get[_index].choises.Length == 0) return;

            MyDialogs.ChoiseElement[] choiseElement = Dialogs.Get[_index].choises;
            _choise.Show();

            for (int i = 0; i < choiseElement.Length; i++)
            {
                _choise.Add(choiseElement[i], this);
            }
        }

        public void Choise(ChoiseButton choiseButton)
        {
            _index = 0;
            Dialogs = choiseButton.Dialogs;
            NextDialog();
            choiseButton.Hide();
            _choise.Hide();
        }
    }
}
