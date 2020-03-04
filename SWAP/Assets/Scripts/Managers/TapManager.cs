using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyBox;

namespace Manager {
    public class TapManager : MonoSingleton<TapManager> {
        protected override void OnAwake() {}

        private void Update() {
            if (UserTapped()) {
                InvokeUserTapped(GetUserTapPosition());
            }

            #region Local_Function

            bool UserTapped() {
                if (Application.isEditor) {
                    return Input.GetKeyDown(KeyCode.Mouse0);
                } else { 
                    return Input.touchCount >= 1;
                }
            }

            Vector2 GetUserTapPosition() {
                if (Application.isEditor) {
                    return Input.mousePosition;
                } else {
                    return Input.GetTouch(0).position;
                }

            }

            #endregion
        }

        private void InvokeUserTapped(Vector2 tapPosition) {
            RaycastHit2D hit = Physics2D.Raycast(tapPosition, Vector2.zero);

            if (RaycastHitTappableObject(out TappableObject tappableObject)) {
                tappableObject.Tap();
            }

            #region Local_Function

            bool RaycastHitTappableObject(out TappableObject tappableObject) {
                tappableObject = null;

                if (hit.collider != null) {
                    tappableObject = hit.collider.gameObject.GetComponent<TappableObject>();
                }

                return tappableObject != null;
            }

            #endregion
        }
    }
}
