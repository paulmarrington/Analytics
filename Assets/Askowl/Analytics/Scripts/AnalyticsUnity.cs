namespace Askowl {
  using Decoupled;
  using JetBrains.Annotations;
  using UnityEngine;

  public sealed class AnalyticsUnity : Analytics {
    public override void Event(string                    name,
                               string                    action,
                               string                    result,
		    ){//[NotNull] params object[] more) {
      UnityEngine.Analytics.Analytics.CustomEvent(name, ToDictionary(action, result, more));
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void RegisterService() {
      if (UnityEngine.Analytics.Analytics.enabled) RegisterDefault<AnalyticsUnity>();
    }
  }
}
