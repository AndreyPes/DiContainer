namespace DIContainer
{
    class A : IA
    {
    }

    class B : IB
    {
        public int Bval1 { get; private set; }

        public string Bval2 { get; private set; }

        public bool Check { get; private set; }

        public B(int val1, string val2)
        {
            Bval1 = val1;
            Bval2 = val2;
        }

        public B(int val1, string val2,bool check)
        {
            Bval1 = val1;
            Bval2 = val2;
            Check = check;
        }

        public B()
        {
        }

        public int GetVal1()
        { return Bval1; }

        public string GetVal2()
        { return Bval2; }

        public bool GetVal3()
        { return Check; }
    }
}
