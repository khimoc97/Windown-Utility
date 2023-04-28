using WindowUtility.Core.Models;

namespace WindowUtility.Core.Providers
{
    public class InMemoryApplicationStateProvider:IApplicationStateProvider
    {
        private static readonly Dictionary<string, string> memory = new();

        public void ClearState(params string[] keys)
        {
            if (keys?.Length > 0)
            {
                foreach (var k in keys)
                {
                    if (memory.ContainsKey(k))
                        memory.Remove(k);
                }
            }
            else
            {
                memory.Clear();
            }
        }

        public ApplicationState GetState()
        {
            return new ApplicationState();
        }

        public void SetState(ApplicationState state)
        {
        }

        public void PatchState(Dictionary<string, string> dic)
        {
            foreach (var pair in dic)
            {
                memory[pair.Key] = pair.Value;
            }
        }
    }
}
