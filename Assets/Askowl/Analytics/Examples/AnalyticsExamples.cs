using System.Collections;
using Decoupled;
using JetBrains.Annotations;
using UnityEngine;

public class AnalyticsExamples : MonoBehaviour {
  private Analytics log;

  private IEnumerator Start() {
    yield return new WaitForSeconds(0.2f);

    log = Analytics.Instance;
  }

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