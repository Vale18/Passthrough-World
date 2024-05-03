Shader "Unluck Software/ReflectiveGlass" {
	{
		Properties
		{
			_BaseMap("Base Texture", 2D) = "white" {}
			_Shininess("Shininess", Range(0.01, 1.0)) = 0.5
			_Cube("Reflection Cubemap", Cube) = "" {}
		}
		SubShader
		{
			Tags { "RenderType"="Opaque" }
			
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows
	
			struct Input
			{
				float2 uv_BaseMap;
				float3 worldNormal;
				float3 worldPos;
			};
	
			sampler2D _BaseMap;
			float _Shininess;
			samplerCUBE _Cube;
	
			void surf(Input IN, inout SurfaceOutputStandard o)
			{
				o.Albedo = tex2D(_BaseMap, IN.uv_BaseMap).rgb;
				o.Smoothness = _Shininess;
				o.Metallic = 0.0; // Assuming no metallic property for now
				o.Alpha = 1.0; // Assuming opaque for now
				o.Normal = float3(0, 0, 1); // Assuming no normal map for now
				o.Emission = float3(0, 0, 0); // Assuming no emission for now
				o.Occlusion = 1.0; // Assuming no ambient occlusion for now
	
				float3 worldViewDir = normalize(IN.worldPos - _WorldSpaceCameraPos);
				o.Specular = texCUBE(_Cube, reflect(-worldViewDir, IN.worldNormal)).rgb;
			}
			ENDCG
		}
		FallBack "Diffuse"
	}