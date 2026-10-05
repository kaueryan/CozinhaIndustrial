namespace CozinhaIndustrial
{
    public class Item
    {
        private int id;
        private string descricao;
        private double preco;

        public Item(int id, string descricao, double preco)
        {
            this.id = id;
            this.descricao = descricao;
            this.preco = preco;
        }

        public int Id
        {
            get { return id; }
        }

        public string Descricao
        {
            get { return descricao; }
        }

        public double Preco
        {
            get { return preco; }
        }

        public override string ToString()
        {
            return id + " - " + descricao + " - R$ " + preco.ToString("F2");
        }
    }
}
