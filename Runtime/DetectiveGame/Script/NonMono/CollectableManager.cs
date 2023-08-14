using System.Collections.Generic;

namespace InteractionSystem
{
    public class CollectableManager
    {
        public static Dictionary<int, ICollectable> Collectables { get; private set; } =
            new Dictionary<int, ICollectable>();
        public static List<ICollectable> Collected { get; private set; } = new List<ICollectable>();
        public static void Collect(ICollectable collectable)
        {
            if (!IsCollected(collectable))
            {
                Collected.Add(collectable);
            }
        }
        
        public static void AddCollectable(ICollectable collectable)
        {
            Collectables.Add(collectable.ID,collectable);
        }

        public static bool IsCollected(ICollectable collectable)
        {
            return Collected.Contains(collectable);
        }        
        
        public static bool IsCollected(int collectableID)
        {
            if (!Collectables.ContainsKey(collectableID))
            {
                return false;
            }

            return IsCollected(Collectables[collectableID]);
        }        

    }
}