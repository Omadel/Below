using UnityEngine;

public abstract class Switchable : MonoBehaviour {
    public bool Manual => manual;
    protected bool manual;
    public void ToggleManual() => manual = !manual;


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
    protected virtual void TurnOnAction() {
        SetState(SwitchableState.On);
    }

    protected virtual void TurnOffAction() {
        SetState(SwitchableState.Off);
    }

    protected virtual void StartTransitioningAction() {
        SetState(SwitchableState.Transitioning);
    }

    public abstract void TurnOn();
    public abstract void TurnOff();

    public void SetState(SwitchableState state) {
        this.state = state;
    }
}
