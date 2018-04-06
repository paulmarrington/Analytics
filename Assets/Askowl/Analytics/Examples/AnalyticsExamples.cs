using Decoupled;
using JetBrains.Annotations;
using UnityEngine;

public sealed class AnalyticsExamples : MonoBehaviour {
  private static Analytics Log { get { return Analytics.Instance; } }

  [UsedImplicitly]
  public void EventExampleButton() {
    Log.Event("AnalyticsExamples", "Test Event", "Shown in Log",
              "button=", "EventExampleButton", "count=", 33, true);
  }

  [UsedImplicitly]
  public void ErrorExampleButton() {
    Log.Error("Test Error", "Shown in Log also", "button=", "ErrorExampleButton", 44, false);
  }
}