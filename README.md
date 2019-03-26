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
