using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NavGame.Core
{
    [RequireComponent(typeof(DamageableGameObject))]
    public class HealthUIController : MonoBehaviour
    {
        public GameObject healthUIPrefab;
        public Transform healthPosition;
        GameObject healthUI;
        Transform cam;
        DamageableGameObject damagealbe;
        Image healthSlider;

        void Awake ()
        {
            Canvas canvas = FindWorldCanvas();
            if (canvas == null)
            {
                throw new Exception("A WorldSpace canvas was needed");
            }
            cam = Camera.main.transform;
            healthUI = Instantiate(healthUIPrefab, canvas.transform);
            healthSlider = healthUI.transform.GetChild(0).GetComponent<Image>();
            damagealbe = GetComponent<DamageableGameObject>();

            damagealbe.onHealthChanged += UpdateHealth;
            damagealbe.onDied += DestroyHealth;
        }

        void LateUpdate()
        {
            if (healthUI != null)
            {
                healthUI.transform.position = healthPosition.position;
                healthUI.transform.forward = -cam.forward;
            }
        }

        Canvas FindWorldCanvas()
        {
            foreach (Canvas c in FindObjectsOfType<Canvas>())
            {
                if (c.renderMode == RenderMode.WorldSpace)
                {
                    return c;
                }
            }
            return null;
        }

        void UpdateHealth(int maxHealth, int currenthHealth)
        {
            if (healthUI != null)
            {
                float healthPercent = (float) currenthHealth / maxHealth;
                healthSlider.fillAmount=healthPercent;
            }
        }

        void DestroyHealth()
        {
            Destroy(healthUI);
        }

    }
}