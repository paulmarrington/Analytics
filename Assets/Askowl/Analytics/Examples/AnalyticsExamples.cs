using Decoupled;
using JetBrains.Annotations;
using UnityEngine;

public sealed class AnalyticsExamples : MonoBehaviour {
  private static Analytics log;

  private void Awake() { log = Analytics.Instance; }

  [UsedImplicitly]
  public void EventExampleButton() {
    log.Event("AnalyticsExamples", "Test Event", "Shown in Log",
              "button=", "EventExampleButton", "count=", 33, true);
  }

  [UsedImplicitly]
  public void ErrorExampleButton() {
    log.Error("Test Error", "Shown in Log also", "button=", "ErrorExampleButton", 44, false);
  }
}