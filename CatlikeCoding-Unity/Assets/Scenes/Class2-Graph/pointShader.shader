Shader "Graph/PointShader"
{
    Properties
    {
        _Smoothness("_Smoothness",Range(0,1))=0.5
    }
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

        float _Smoothness;
        //inout: 既传递给函数又用于函数的结果
        //saturate():将数值限制在0-1之间
        void ConfigureSurface(Input input, inout SurfaceOutputStandard surface)
        {
            surface.Albedo.rg = saturate(input.worldPos.xy * 0.5 + 0.5); //改变颜色//加rg 消除蓝色
            surface.Smoothness = _Smoothness;
        }
        ENDCG
    }
}
