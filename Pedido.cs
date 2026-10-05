namespace CozinhaIndustrial
{
    public class Pedido
    {
        private int id;
        private string cliente;
        private Item?[] itens;

        public Pedido(int id, string cliente)
        {
            this.id = id;
            this.cliente = cliente;
            itens = new Item?[10];
        }

        public int Id
        {
            get { return id; }
        }

        public string Cliente
        {
            get { return cliente; }
        }

        public bool adicionarItem(Item item)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] == null)
                {
                    itens[i] = item;
                    return true;
                }
            }

            return false;
        }

        public bool removerItem(Item item)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null && itens[i]!.Id == item.Id)
                {
                    itens[i] = null;
                    return true;
                }
            }

            return false;
        }

        public double calcularTotal()
        {
            double total = 0;

            foreach (Item? item in itens)
            {
                if (item != null)
                    total += item.Preco;
            }

            return total;
        }

        public string dadosDoPedido()
        {
            string dados = "";

            dados += "ID do pedido: " + id + "\n";
            dados += "Cliente: " + cliente + "\n";
            dados += "Itens:\n";

            bool possuiItens = false;

            foreach (Item? item in itens)
            {
                if (item != null)
                {
                    dados += "- " + item.Descricao +
                             " - R$ " + item.Preco.ToString("F2") + "\n";
                    possuiItens = true;
                }
            }

            if (!possuiItens)
                dados += "- Nenhum item\n";

            dados += "Valor total: R$ " +
                     calcularTotal().ToString("F2") + "\n";

            return dados;
        }

        public Item?[] Itens
        {
            get { return itens; }
        }
    }
}
