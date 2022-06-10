// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/Line Of Sight Depth RGBA"
{
	Category
	{
		Fog { Mode Off }

		SubShader
		{
			Tags { "RenderType"="Opaque" }

			Pass
			{
				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				struct v2f
				{
					float4 pos : POSITION;					
					float3 worldPos : TEXCOORD0;
				};

				v2f vert( appdata_base v )
				{
					v2f o;

					float4 position = v.vertex;
					position.w = 1.f;

					o.pos = UnityObjectToClipPos(position);
					o.worldPos = mul(unity_ObjectToWorld, position);					

					return o;
				}

				float4 frag(v2f i) : COLOR
				{
					// Calculate depth and bring into 0-1 range for encoding
					float fDepth = length(i.worldPos - _WorldSpaceCameraPos.xyz) / _ProjectionParams.z;

					// Clamp depth to 1 to prevent encoding errors
					fDepth = min(fDepth, 0.999);

					// Compute second moment over the pixel extents.
					float moment = fDepth * fDepth;

					// Encode float values to be stored in RGBA render texture
					float4 encodedOutput;
					encodedOutput.xy = EncodeFloatRG(fDepth);
					encodedOutput.zw = EncodeFloatRG(moment);

					return encodedOutput;
				}

				ENDCG
			}
		}
	}

	Fallback Off
}