Shader "Graph/PointShader"
{
    SubShader
    {
        CGPROGRAM
        //着色器编译器生成具有标准照明和完全支持阴影的表面着色器
        #pragma surface ConfigureSurface Standard fullforwardshadows
        #pragma target 3.0
        struct Input
        {
            float3 worldPos;
        };

        //inout: 既传递给函数又用于函数的结果
        void ConfigureSurface(Input input,inout SurfaceOutputStandard surface)
        {

        }

        ENDCG
}
}
