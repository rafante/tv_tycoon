using UnityEngine;
public abstract class ManagerBase : MonoBehaviour, IScreenHandler
{
    public abstract void beginGoToScreen(string screenName);
    public abstract void endGoToScreen(string screenName);
}
public interface IScreenHandler
{
    void beginGoToScreen(string screenName);
    void endGoToScreen(string screenName);
}