Shader "Depth/Mask"
{
	SubShader
	{
	    //Simple depthmask shader 	
		Tags {"Queue" = "Geometry" }
		
		ColorMask 0
        ZWrite on
        
        Pass {}
	}
}