using UnityEngine;

public abstract class Switchable : MonoBehaviour {
    public SwitchableState State => state;
    private SwitchableState state = SwitchableState.Off;
    public enum SwitchableState { On, Off, Transitioning }

    public System.Action OnTurnOn, OnTurnOff, OnStartTransitioning;
    public bool IsOn => state == SwitchableState.On;
    public bool IsOff => state == SwitchableState.Off;
    public bool IsTransitioning => state == SwitchableState.Transitioning;

    protected virtual void Start() {
        OnTurnOn += TurnOnAction;
        OnTurnOff += TurnOffAction;
        OnStartTransitioning += StartTransitioningAction;
    }

    protected abstract void TurnOnAction();
    protected abstract void TurnOffAction();
    protected abstract void StartTransitioningAction();

    public abstract void TurnOn();
    public abstract void TurnOff();

    public void SetState(SwitchableState state) {
        this.state = state;
    }
}
