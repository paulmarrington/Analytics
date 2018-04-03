namespace Askowl {
  using Decoupled;
  using JetBrains.Annotations;

  public sealed class AnalyticsUnity : Singleton<AnalyticsUnity> {
    private void Awake() { Analytics.Load<AnalyticsUnityService>(); }
  }

  public sealed class AnalyticsUnityService : Analytics {
    public override void Event(string                    name,
                               string                    action,
                               string                    result,
                               [NotNull] params object[] more) {
      UnityEngine.Analytics.Analytics.CustomEvent(name, ToDictionary(action, result, more));
    }

    [UsedImplicitly]
    public override string Gender {
      set {
        switch (value) {
          case "Male":
            UnityEngine.Analytics.Analytics.SetUserGender(UnityEngine.Analytics.Gender.Male);
            break;
          case "Female":
            UnityEngine.Analytics.Analytics.SetUserGender(UnityEngine.Analytics.Gender.Female);
            break;
          default:
            UnityEngine.Analytics.Analytics.SetUserGender(UnityEngine.Analytics.Gender.Unknown);
            break;
        }
      }
    }

    [UsedImplicitly]
    public override int BirthYear {
      set { UnityEngine.Analytics.Analytics.SetUserBirthYear(value); }
    }
  }
}