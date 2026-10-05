namespace CozinhaIndustrial
{
    public class Restaurante
    {
        private int proxPedido;
        private Pedido?[] pedidos;

        public Restaurante()
        {
            proxPedido = 1;
            pedidos = new Pedido?[50];
        }

        public bool novoPedido(Pedido pedido)
        {
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] == null)
                {
                    pedidos[i] = pedido;
                    proxPedido++;
                    return true;
                }
            }

            return false;
        }

        public Pedido? buscarPedido(Pedido pedido)
        {
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null &&
                    pedidos[i]!.Id == pedido.Id)
                {
                    return pedidos[i];
                }
            }

            return null;
        }

        public bool cancelarPedido(Pedido pedido)
        {
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null &&
                    pedidos[i]!.Id == pedido.Id)
                {
                    pedidos[i] = null;
                    return true;
                }
            }

            return false;
        }

        public int ProxPedido
        {
            get { return proxPedido; }
        }

        public Pedido?[] Pedidos
        {
            get { return pedidos; }
        }
    }
}
