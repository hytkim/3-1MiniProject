using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(BaseEntity e) : base(e) { }

    public override void OnStateEnter()
    {
        entity.StartCoroutine(entity.UpdateTarget());
    }

    public override void OnStateUpdate()
    {
    }

    public override void OnStateExit()
    {
    }
}