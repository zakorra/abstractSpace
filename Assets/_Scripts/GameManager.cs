using Unity.Entities;
using UnityEngine;
using _Scripts.entities;

namespace _Scripts
{
    public class GameManager : MonoBehaviour
    {
        public GameObject ResourceCanvas;
        
        private EntityManager _entityManager;

        void Start()
        {
            _entityManager = World.Active.GetOrCreateManager<EntityManager>();
            Entity resourceEntity =  _entityManager.Instantiate(ResourceCanvas);
            
            
            _entityManager.SetComponentData(resourceEntity, new GameResourceData
            {
                GameResourceType = GameResourceType.FOOD,
                Amount = 1f,
                Generation = 0.5f
            });
            
           
        }
    }
}