namespace YankeesCodeChallenge.Models.Core
{
    public class IdNamePair
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IdNamePair(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            var right = obj as IdNamePair;

            return right != null
                && Id == right.Id
                && Name == right.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}