using System;
using eRede;
using eRede.Service.Error;
using Environment = eRede.Environment;

namespace Sample
{
    class Samples
    {
        static void Main(string[] args)
        {
            var pv = "";
            var token = "";
            var environment = Environment.Sandbox();
            
            Credit(pv, token, environment);
        }

        /// <summary>
        /// Mostra uma integração com cartão de crédito
        /// </summary>
        /// 
        /// <param name="pv"></param>
        /// <param name="token"></param>
        /// <param name="environment"></param>
        private static void Credit(string pv, string token, Environment environment)
        {
            var store = new Store(pv, token, environment);
            var transaction = new Transaction
            {
                amount = 20,
                reference = "pedido" + new Random().Next(200, 10000)
            }.CreditCard(
                "5448280000000007",
                "123",
                "12",
                "2020",
                "Fulano de tal"
            );

            try
            {
                var response = new eRede.eRede(store).create(transaction);

                if (response.returnCode == "00")
                {
                    Console.WriteLine("Tudo certo. TID: {0}", response.tid);
                }
            }
            catch (RedeException e)
            {
                Console.WriteLine("Opz[{0}]: {1}", e.error.returnCode, e.error.returnMessage);
            }
        }

        /// <summary>
        /// Mostra uma integração com cartão de débito e autenticação.
        /// </summary>
        /// 
        /// <param name="pv"></param>
        /// <param name="token"></param>
        /// <param name="environment"></param>
        private static void Debit(string pv, string token, Environment environment)
        {
            var store = new Store(pv, token, environment);
            var transaction = new Transaction
            {
                amount = 20,
                reference = "pedido" + new Random().Next(200, 10000)
            }.DebitCard(
                "2223000148400010",
                "123",
                "12",
                "2020",
                "Fulano de tal"
            );

            transaction.AddUrl("http://example.org/success", Url.THREE_D_SECURE_SUCCESS);
            transaction.AddUrl("http://example.org/failure", Url.THREE_D_SECURE_FAILURE);

            try
            {
                var response = new eRede.eRede(store).create(transaction);

                if (response.returnCode == "220")
                {
                    Console.WriteLine("Tudo certo. Redirecione o cliente para autenticação\n{0}", response.threeDSecure.url);
                }
            }
            catch (RedeException e)
            {
                Console.WriteLine("Opz[{0}]: {1}", e.error.returnCode, e.error.returnMessage);
            }
        }
    }
}