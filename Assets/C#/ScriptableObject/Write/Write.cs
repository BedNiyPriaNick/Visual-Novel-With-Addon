using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

namespace Game
{
    public class Write
    {
        public enum Status
        {
            Enabled,
            Disabled
        }

        public event Action<string> SelfWrite;
        public event Action EndWrite;

        public Status SelfStatus = Status.Disabled;

        private StringBuilder _builder;
        private WaitForSeconds _wait;

        public Write(float time)
        {
            _builder = new StringBuilder();
            _wait = new WaitForSeconds(time);
        }

        public IEnumerator Get(string str)
        {
            SelfStatus = Status.Enabled;
            _builder.Clear();
            int wordIndex = 0;

            while (SelfStatus == Status.Enabled)
            {
                yield return _wait;
                if (wordIndex == str.Length) break;

                _builder.Append(str.Substring(wordIndex, 1));
                SelfWrite?.Invoke(_builder.ToString());
                wordIndex++;
            }

            SelfStatus = Status.Disabled;
            EndWrite?.Invoke();
        }
    }
}
