
using UnityEngine;

public abstract class EnemyStateBase : IEnemyState
{
    protected IEnemyStateSwitcher StateSwitcher;
    protected ITargetProvider TargetProvider;
    protected EnemyAnimator Animator;


    public EnemyStateBase(
        IEnemyStateSwitcher stateSwitcher, 
        ITargetProvider targetProvider,
        EnemyAnimator enemyAnimator)
    {
        StateSwitcher = stateSwitcher;
        TargetProvider = targetProvider;
        Animator = enemyAnimator;
    }

    public virtual void OnStateEnter() { }

    public virtual void OnStateExit() 
    {

    }

    public virtual void OnStateDestroyed()
    {
 
    }

    public virtual void OnTriggerEnter(Collider other) { }

    public virtual void OnTriggerExit(Collider other) { }

    protected void SwitchState<T>() where T : IEnemyState
    {
        StateSwitcher.SwitchStateTo<T>();
    }

    protected DamageTarget GetTarget()
    {
        return TargetProvider.GetTarget();
    }

    protected void SetTarget(DamageTarget target)
    {
        TargetProvider.SetTarget(target);
    }
}
