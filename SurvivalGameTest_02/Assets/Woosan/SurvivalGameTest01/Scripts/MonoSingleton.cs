using UnityEngine;

/// <summary>
/// 기본이 되는 싱글톤 패턴
/// Awake부분에서 Find Object를 사용하기 때문에 빨리 메모리에 할당해야하는 스크립트는 직접 만들어 사용 해야함.
/// </summary>

namespace Woosan.Common
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static T instance;

        void Awake()
        {
            instance = GameObject.FindObjectOfType(typeof(T)) as T;
            instance.Init();
        }

        public virtual void Init() { }

        private void OnApplicateQuit()
        {
            instance = null;
        }
    }
}
