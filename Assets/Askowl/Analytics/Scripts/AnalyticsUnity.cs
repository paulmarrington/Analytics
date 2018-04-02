namespace Askowl {
  using System.Collections;
  using System.Collections.Generic;
  using Decoupled;
  using JetBrains.Annotations;

  public sealed class AnalyticsUnity : Singleton<AnalyticsUnity> {
    private IEnumerator Start() {
      yield return AnalyticsUnityService.Register<AnalyticsUnityService>();
    }
  }

  public sealed class AnalyticsUnityService : Analytics {
    public override void
      Event(string name, string action, string result, [NotNull] params object[] more) {
      UnityEngine.Analytics.Analytics.CustomEvent(name, new Dictionary<string, object> {
        {"action", action},
        {"result", result},
        {"more", More(more)}
      });
    }

    [UsedImplicitly]
    public override Genders Gender {
      set {
        switch (value) {
          case Genders.Male:
            UnityEngine.Analytics.Analytics.SetUserGender(UnityEngine.Analytics.Gender.Male);
            break;
          case Genders.Female:
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