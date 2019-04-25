# SDK C#

SDK de integração eRede

# Utilizando

## Autorizando uma transação

```csharp
// Configuração da loja
var store = new Store(pv, token, environment);

// Transação que será autorizada
var transaction = new Transaction
{
    amount = 20,
    reference = "pedido123"
}.CreditCard(
    "5448280000000007",
    "235",
    "12",
    "2020",
    "Fulano de tal"
);

// Autoriza a transação
var response = new eRede.eRede(store).create(transaction);

if (response.returnCode == "00")
{
    Console.WriteLine("Transação autorizada com sucesso: " + response.tid);
}
```

Por padrão, a transação é capturada automaticamente; caso seja necessário apenas autorizar a transação, o método `Transaction::capture()` deverá ser chamado com o parâmetro `false`:

```csharp
// Configuração da loja
var store = new Store(pv, token, environment);

// Transação que será autorizada
var transaction = new Transaction
{
    amount = 20,
    reference = "pedido123"
}.CreditCard(
    "5448280000000007",
    "235",
    "12",
    "2020",
    "Fulano de tal"
).Capture(false);

// Autoriza a transação
var response = new eRede.eRede(store).create(transaction);

if (response.returnCode == "00")
{
    Console.WriteLine("Transação autorizada com sucesso: " + response.tid);
}
```

## Autorizando uma transação IATA

```csharp
// Configuração da loja
var store = new Store(pv, token, environment);

// Transação que será autorizada
var transaction = new Transaction
{
    amount = 20,
    reference = "pedido123"
}.CreditCard(
    "5448280000000007",
    "235",
    "12",
    "2020",
    "Fulano de tal"
).Iata("code123", "250");

// Autoriza a transação
var response = new eRede.eRede(store).create(transaction);

if (response.returnCode == "00")
{
    Console.WriteLine("Transação autorizada com sucesso: " + response.tid);
}
```

## Autorizando uma transação com autenticação

O 3DS é um serviço de autenticação que é obrigatório em transações de débito e opcional em transações de crédito. Saiba mais através [da documentação](https://www.userede.com.br/desenvolvedores/pt/produto/e-Rede#documentacao-3ds)

```csharp
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

var response = new eRede.eRede(store).create(transaction);
```

Assim que a transação for criada, o cliente precisará ir até a página do banco para autenticar. O código de status `220` indica que o cliente precisará ser redirecionado:

```csharp
if (response.returnCode == "220")
{
    Console.Write(response.threeDSecure.url);
}
```

Os códigos de [Retorno 3DS](https://www.userede.com.br/desenvolvedores/pt/produto/e-Rede#documentacao-ret3ds) também estão disponíveis na documentação.


