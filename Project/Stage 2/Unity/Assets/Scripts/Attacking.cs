using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
	[SerializeField] LayerMask m_CoalLayer;
	[SerializeField] LayerMask m_mineCartLayer;
	[SerializeField] GameObject m_CoalPrefab;
	[SerializeField] Transform m_RaycastPoint;

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Debug.Log("Attack");

			Ray ray = new()
			{
				origin = m_RaycastPoint.position,
				direction = m_RaycastPoint.forward
			};
			if (!Physics.Raycast(ray, out RaycastHit hit, 2, m_CoalLayer, QueryTriggerInteraction.Collide))
			{
				Debug.Log("No hit");
				return;
			}

			Debug.Log("Hit");

			GameObject coal = Instantiate(m_CoalPrefab);
			coal.transform.position = hit.point;
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			Ray ray = new()
			{
				origin = m_RaycastPoint.position,
				direction = m_RaycastPoint.forward
			};
			if (!Physics.Raycast(ray, out RaycastHit hit, 2, m_mineCartLayer, QueryTriggerInteraction.Collide))
			{
				Debug.Log("No hit");
				return;
			}

			print("Attach to minecart");
			CubicInterpolation minecart = hit.transform.parent.GetComponent<CubicInterpolation>();
			minecart.IsPlayerRiding = true;
			gameObject.GetComponent<PlayerController>().enabled = false;
			gameObject.GetComponent<CharacterController>().enabled = false;
			
			transform.SetParent(minecart.transform);
			transform.localPosition = new Vector3(0, 0.5f, 0);
		}
	}

	void RideMineCart()
	{
		
	}
}
