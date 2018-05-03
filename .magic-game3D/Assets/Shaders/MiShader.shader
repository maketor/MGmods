shader "nice/miShader"{
	SubShader
	{
		pass 
		{
			tags{"RenderType"="Opaque"}

				CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.Cginc"
				struct v2f {
				float4 pos : SV_POSITION;
};
			v2f vert(appdata.base v) {
				v2f o;
				float4 vert : float4(v.vertex.xyz * sin(_Time.y), v.vertex.w);

					o.pos = nul(UNITY_MATRIX_MVP, vert);
					return o;
			}
			half4 frag(v2f i) :COLOR{
				return half4(1,1,1,1);

			}
				ENDCG
		}
	}
}