using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
	[SerializeField] Transform m_CameraPivot;
	[SerializeField] float m_Sensitivity = 2;

	float m_Pitch = 50;
	float m_Yaw;

	void Update()
	{
		m_Pitch -= Input.GetAxisRaw("Mouse Y") * m_Sensitivity;
		m_Yaw += Input.GetAxisRaw("Mouse X") * m_Sensitivity;

		m_Pitch = Mathf.Clamp(m_Pitch, -20, 89);

		m_CameraPivot.localEulerAngles = new Vector3(m_Pitch, m_Yaw, 0);
	}

	public Vector3 RotateYaw(Vector3 input)
	{
		float s = Mathf.Sin(Mathf.Deg2Rad * m_Yaw);
		float c = Mathf.Cos(Mathf.Deg2Rad * m_Yaw);

		Vector3 output = new()
		{
			x = c * input.x + s * input.z,
			y = input.y,
			z = -s * input.x + c * input.z
		};

		return output;
	}
}
