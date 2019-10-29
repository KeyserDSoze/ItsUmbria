namespace ItsUmbria.Stuff2
{
    public class StuffFactory
    {
        public IPrintable Create(CharacterType type)
        {
            switch (type)
            {
                default:
                case CharacterType.Topolino: return new Topolino();
                case CharacterType.Paperino: return new Paperino();
                case CharacterType.Pippo: return new Pippo();
            }
        }
        public enum CharacterType
        {
            Topolino,
            Paperino = 1,
            Pippo = 2
        }
    }
}
