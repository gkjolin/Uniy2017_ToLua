﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Q5/Proj/Custom/GradientAplha" {
Properties {
	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	_AlphaFactor ("Alpha Factor", Range(0, 1)) = 0.5
	_radius ("Radius ", float) = 3.5
}

SubShader {
	Tags {"Queue"="Transparent"}
	
	Blend SrcAlpha OneMinusSrcAlpha 
	
	Pass {  
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata_t {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				half2 texcoord : TEXCOORD0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _AlphaFactor;
			float4 _UVCenter = float4(0.5, 0.5, 0, 0);
			float _radius;
			
			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : Color
			{
				fixed4 col = tex2D(_MainTex, i.texcoord);
				float2 center = _UVCenter.xy;
				fixed dis = distance(i.texcoord, center);
				col.a =  (1 - saturate(dis / length(float2(_radius, 0)))) * col.a * _AlphaFactor;
				return col;
			}
		ENDCG
		}
	}
}
