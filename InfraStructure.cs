namespace DIContainer
{
    interface IA
    {

    }

    interface IB
    {
        int Bval1 { get; }

        string Bval2 { get; }

        bool Check { get; }

        int GetVal1();

        string GetVal2();

        bool GetVal3();
    }
}
