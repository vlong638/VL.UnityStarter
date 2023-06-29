using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.VLGamingStudy0328
{
    public interface ICloneableObject<T>
    {
        T Clone();
    }
}
