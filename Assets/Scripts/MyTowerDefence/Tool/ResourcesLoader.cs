
using UnityEngine;

namespace Tool
{
    internal static class ResourcesLoader 
    {
        public static Sprite LoadSprite(ResourcePath path)
        {
           return Resources.Load<Sprite>(path.PathResource);
        }

        public static GameObject LoadPrefab(ResourcePath path)
        {
            return Resources.Load<GameObject>(path.PathResource); 
        }
    }
}
