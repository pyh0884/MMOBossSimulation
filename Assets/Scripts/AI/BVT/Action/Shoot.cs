using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MMO_WorkSpace
{
    public class Shoot : Action
    {
        public override TaskStatus OnUpdate()
        {
            Debug.Log("Shoot");
            return TaskStatus.Success;
        }
    }
}
