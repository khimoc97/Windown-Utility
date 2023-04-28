using WindowUtility.Core.Models;

namespace WindowUtility.Core.Providers
{
    public interface IApplicationStateProvider
    {
        ApplicationState GetState();
        void SetState(ApplicationState state);
        void PatchState(Dictionary<string, string> dic);
        void ClearState(params string[] keys);
    }
}
