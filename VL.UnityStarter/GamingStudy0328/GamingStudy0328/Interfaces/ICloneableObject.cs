using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.GamingStudy0328
{
    public interface ICloneableObject<T>
    {
        T Clone();
    }
}
